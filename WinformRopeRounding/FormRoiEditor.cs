﻿using Emgu.CV;
using Newtonsoft.Json;
using WinformRopeRounding.Modules.VideoProcessor;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormRoiEditor : Form
    {
        public string LastSelectedNode { get; internal set; }
        private Dictionary<string, Utilities.Action> Actions;
        private Dictionary<string, ROI> HoleROIs = new();
        private Dictionary<string, Camera> Cams = new();
        public FormRoiEditor()
        {
            InitializeComponent();
            lblLocation.Text = string.Empty;
            pbImage.MouseMove += PbImage_OnMouseMove;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
        }
        ~FormRoiEditor()
        {
            pbImage.MouseMove -= PbImage_OnMouseMove;
        }

        private void FormRoiEditor_Load(object sender, EventArgs e)
        {
            Cams = GlobalVars.AppSetting.Cams;
            foreach (var kv in Cams)
            {
                _ = cboCamera.Items.Add(kv.Key);
            }
            cboCamera.SelectedIndex = 0;
            Actions = GlobalVars.AppSetting.Actions;
            HoleROIs = GlobalVars.AppSetting.Template.HoleROIs;
            PTZRenderTreeView(true);
        }

        private void btnSnapshoot_Click(object sender, EventArgs e)
        {
            var idx = cboCamera.SelectedIndex;
            if (idx >= 0)
            {
                var cam = Cams.Values.ElementAt(idx);
                string url = $"http://{cam.Username}:{cam.Password}@{cam.IPAddress}/ISAPI/Streaming/channels/101/picture";
                VideoProcessor vp = new(url, EnumMediaInput.HTTP);
                SetImage(vp.Snapshot().ToBitmap());
            }
        }

        public void SetImage(Image image)
        {
            pbImage.SetImage(image);
            btnAutoFit.PerformClick();
        }

        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Name.Contains("-val")) e.Cancel = true;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnEdit.Enabled = false;
            LastSelectedNode = TreeView.SelectedNode.FullPath;
            var paths = TreeView.SelectedNode.FullPath.Split('\\');
            if (paths.Length <= 2) return;

            pbImage.ResetSelectedRegion();
            var idx = paths[2];
            switch (paths[1])
            {
                case "Template":
                    if (paths.Length > 2)
                    {
                        var roi = HoleROIs[idx];
                        pbImage.DrawMode = 1;
                        pbImage.DrawShape(roi.BBOX, Color.Pink);
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"HoleROIs|{idx}";
                    }
                    break;
                case "Actions":
                    if (paths.Contains("TargetROI"))
                    {
                        var act = Actions[idx];
                        pbImage.DrawMode = 1;
                        pbImage.DrawShape(act.BBox, Color.Yellow);
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"TargetROI|{idx}";
                    }
                    if (paths.Contains("PTZInfo"))
                    {
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"PTZInfo|{idx}";
                    }
                    break;
            }
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    System.Windows.Forms.ContextMenu cm = new ContextMenu();
            //    cm.MenuItems.Add("Change", new EventHandler(Edit_Region));
            //    cm.MenuItems.Add("Clear", new EventHandler(Clear_Region));
            //    TreeView.ContextMenu = cm;
            //}
        }

        private void Edit_Region(object sender, EventArgs e)
        {
            pbImage.ResetSelectedRegion();

            var selectedNodes = LastSelectedNode.Split('|');

            switch (selectedNodes[0])
            {
                case "HoleROIs":
                case "TargetROI":
                    pbImage.EnabledEditMode = true;
                    break;
                case "PTZInfo":
                    var idx = cboCamera.SelectedIndex;
                    var cam = Cams.Values.ElementAt(idx);
                    var ptz = Actions[selectedNodes[1]].PtzInfo;
                    var strPtz = $"{ptz.Pan} {ptz.Tilt} {ptz.Zoom}";
                    var frm = new FormCamControl("Position View", strPtz)
                    {
                        CameraIP = cam.IPAddress,
                        CamUsername = cam.Username,
                        CamPassword = cam.Password
                    };
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var img = frm.SnapshootImage;
                        //var newImg = new Bitmap(img, new Size(1920, 1080));
                        this.SetImage(img);
                        //mov.LocInfo = frm.InputValue;
                        var locInfo = frm.InputValue;
                        ptz.Pan =Convert.ToSingle(locInfo.Split()[0]);
                        ptz.Tilt = Convert.ToSingle(locInfo.Split()[1]);
                        ptz.Zoom = Convert.ToSingle(locInfo.Split()[2]);
                        PTZRenderTreeView(cbShowValue.Checked);
                    }
                    break;
            }
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var roi = pbImage.SaveNewROI();

            var selectedNodes = LastSelectedNode.Split('|');
            var selectedKey = selectedNodes[0];
            var idx = selectedNodes[1];
            switch (selectedKey)
            {
                case "HoleROIs":
                    HoleROIs[idx].BBOX = roi;
                    break;
                case "TargetROI":
                    Actions[idx].BBox = roi;
                    break;
                case "PTZInfo":

                    break;
            }

            pbImage.DrawMode = 0;
            PTZRenderTreeView(cbShowValue.Checked);
            btnSave.Enabled = false;
        }

        private void cbShowValue_CheckedChanged(object sender, EventArgs e)
        {
            PTZRenderTreeView(cbShowValue.Checked);
        }

        private static void AddNode(TreeNode RootNode, string Key, string Val, string idx = "", bool ShowValue = true)
        {
            TreeNode newNode = new(Key);
            RootNode.Nodes.Add(newNode);
            newNode.Name = $"{Key}-{idx}";
            newNode.Tag = Val;
            if (ShowValue)
                newNode.Nodes.Add($"{Key}-val", Val);
        }

        private void PTZRenderTreeView(bool ShowValue = false)
        {
            var appSetting = GlobalVars.AppSetting;

            TreeNode rootNode = new("AppSetting");

            TreeNode tplNode = new("Template");
            rootNode.Nodes.Add(tplNode);
            for (var i = 0; i < HoleROIs.Count; i++)
            {
                var kv = HoleROIs.ElementAt(i);
                AddNode(tplNode, kv.Key, kv.Value.BBOX.ToString(), i.ToString());
            }

            TreeNode actsNode = new("Actions");
            rootNode.Nodes.Add(actsNode);
            for (var i = 0; i < appSetting.Actions.Count; i++)
            {
                var kv = appSetting.Actions.ElementAt(i);
                var act = kv.Value;
                TreeNode actNode = new(kv.Key);
                actsNode.Nodes.Add(actNode);
                AddNode(actNode, $"CamId", act.CameraName, i.ToString());
                AddNode(actNode, $"PTZInfo", act.PtzInfo.ToString(), i.ToString());
                AddNode(actNode, $"TargetROI", act.BBox.ToString(), i.ToString());
            }
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add(rootNode);
            TreeView.ExpandAll();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            var appSetting = GlobalVars.AppSetting;
            appSetting.Actions = Actions;
            appSetting.Template.HoleROIs = HoleROIs;
            var json = JsonConvert.SerializeObject(appSetting, Formatting.Indented);
            File.WriteAllText("Config.json", json);
        }

        private void PbImage_OnMouseMove(object sender, MouseEventArgs e)
        {
            lblLocation.Text = $"Pointer: ({e.X},{e.Y})";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbImage.ResetSelectedRegion();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pbImage.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pbImage.ZoomOut();
        }

        private void btnAutoFit_Click(object sender, EventArgs e)
        {
            pbImage.ZoomToFit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Region(null, EventArgs.Empty);
        }


    }
}
