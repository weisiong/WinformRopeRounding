using Emgu.CV;
using Newtonsoft.Json;
using WinformRopeRounding.Modules.VideoProcessor;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormConfigEditor : Form
    {
        public string LastSelectedNode { get; internal set; }
        private Dictionary<string, Utilities.Action> Actions;
        private Dictionary<string, ROI> HoleROIs = new();
        private Dictionary<string, Camera> Cams = new();
        public FormConfigEditor()
        {
            InitializeComponent();
            lblLocation.Text = string.Empty;
            pbImage.MouseMove += PbImage_OnMouseMove;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
        }
        ~FormConfigEditor()
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
            PTZRenderTreeView(cbShowValue.Checked);
        }

        private void btnSnapshoot_Click(object sender, EventArgs e)
        {
            var idx = cboCamera.SelectedIndex;
            if (idx >= 0)
            {
                var cam = Cams.Values.ElementAt(idx);
                string url = string.Format(GlobalVars.VIDEO_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
                VideoProcessor vp = new(url, EnumMediaInput.HTTP);
                SetImage(vp.Snapshot().ToBitmap());
            }
        }
        private void btnCamControl_Click(object sender, EventArgs e)
        {
            var idx = cboCamera.SelectedIndex;
            if (idx >= 0)
            {
                var cam = Cams.Values.ElementAt(idx);
                var strPtz = string.Empty;
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
                    this.SetImage(img);
                }

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
                case "Cameras":
                    if(paths.Contains("Position"))
                    {
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"CamPosition|{idx}";
                    }
                    break;
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
                    if (paths.Contains("Position"))
                    {
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"ActPosition|{idx}";
                    }
                    if (paths.Contains("CamId"))
                    {
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"CamId|{idx}";
                    }
                    break;
            }
        }

        private void Edit_Region(object sender, EventArgs e)
        {
            pbImage.ResetSelectedRegion();

            var selectedNodes = LastSelectedNode.Split('|');

            switch (selectedNodes[0])
            {
                case "CamPosition":
                    {
                        var cam = Cams[selectedNodes[1]];
                        var strPtz = cam.Position;
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
                            this.SetImage(img);
                            var locInfo = frm.InputValue;
                            cam.Position = locInfo;
                            PTZRenderTreeView(cbShowValue.Checked);
                        }
                    }
                    break;
                case "HoleROIs":
                case "TargetROI":
                    pbImage.EnabledEditMode = true;
                    btnSave.Enabled = true;
                    btnEdit.Enabled = false;
                    break;
                case "ActPosition":
                    {
                        var idx = cboCamera.SelectedIndex;
                        var cam = Cams.Values.ElementAt(idx);
                        var strPtz = Actions[selectedNodes[1]].Position;
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
                            this.SetImage(img);
                            var locInfo = frm.InputValue;
                            Actions[selectedNodes[1]].Position = locInfo;
                            PTZRenderTreeView(cbShowValue.Checked);
                        }
                    }
                    break;
                case "CamId":
                    {
                        var cam1 = Actions[selectedNodes[1]];
                        var frmCam = new FormSelectCam();
                        var result1 = frmCam.ShowDialog();
                        if (result1 == DialogResult.OK)
                        {
                            cam1.CameraId = frmCam.GetSelectedCamName;
                            PTZRenderTreeView(cbShowValue.Checked);
                        }
                    }
                    break;
            }
            btnSaveFile.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedNodes = LastSelectedNode.Split('|');
            var selectedKey = selectedNodes[0];
            var idx = selectedNodes[1];
            switch (selectedKey)
            {
                case "HoleROIs":
                    var roi1 = pbImage.SaveNewROI();
                    HoleROIs[idx].BBOX = roi1;
                    break;
                case "TargetROI":
                    var roi2 = pbImage.SaveNewROI();
                    Actions[idx].BBox = roi2;
                    break;
                case "Position":
                    //Actions[idx].Position = "";
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

        private static void AddNode(TreeNode RootNode, string Key, string Val, bool ShowValue = false)
        {
            TreeNode newNode = new(Key);
            RootNode.Nodes.Add(newNode);
            newNode.Tag = Val;
            if (ShowValue)
                newNode.Nodes.Add($"{Key}-val", Val);
        }

        private void PTZRenderTreeView(bool ShowValue = false)
        {
            var appSetting = GlobalVars.AppSetting;

            TreeNode rootNode = new("AppSetting");

            TreeNode camsNode = new("Cameras");
            rootNode.Nodes.Add(camsNode);
            for (var i = 0; i < appSetting.Cams.Count; i++)
            {
                var kv = appSetting.Cams.ElementAt(i);
                var cam = kv.Value;
                TreeNode camNode = new(kv.Key);
                camsNode.Nodes.Add(camNode);
                AddNode(camNode, $"Position", cam.Position, ShowValue);
            }

            TreeNode tplNode = new("Template");
            rootNode.Nodes.Add(tplNode);
            for (var i = 0; i < HoleROIs.Count; i++)
            {
                var kv = HoleROIs.ElementAt(i);
                AddNode(tplNode, kv.Key, kv.Value.BBOX.ToString(), ShowValue);
            }

            TreeNode actsNode = new("Actions");
            rootNode.Nodes.Add(actsNode);
            for (var i = 0; i < appSetting.Actions.Count; i++)
            {
                var kv = appSetting.Actions.ElementAt(i);
                var act = kv.Value;
                TreeNode actNode = new(kv.Key);
                actsNode.Nodes.Add(actNode);
                AddNode(actNode, $"CamId", act.CameraId, ShowValue);
                AddNode(actNode, $"Position", act.Position, ShowValue);
                AddNode(actNode, $"TargetROI", act.BBox.ToString(), ShowValue);
            }
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add(rootNode);
            TreeView.ExpandAll();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                var appSetting = GlobalVars.AppSetting;
                appSetting.Actions = Actions;
                appSetting.Template.HoleROIs = HoleROIs;
                var json = JsonConvert.SerializeObject(appSetting, Formatting.Indented);
                File.WriteAllText("Config.json", json);
                MessageBox.Show("Setting Save Successfully.");
                btnSaveFile.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
