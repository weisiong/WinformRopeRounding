using Emgu.CV;
using Newtonsoft.Json;
using WinformRopeRounding.Modules.VideoStreaming;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormConfigEditor : Form
    {
        public string LastSelectedNode { get; internal set; }
        private Dictionary<string, Utilities.Action> Actions;
        private Dictionary<string, ProductTemplate> Templates = new();
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
            Templates = GlobalVars.AppSetting.Templates;
            PTZRenderTreeView(cbShowValue.Checked);
        }

        private void btnSnapshoot_Click(object sender, EventArgs e)
        {
            var idx = cboCamera.SelectedIndex;
            if (idx >= 0)
            {
                var cam = Cams.Values.ElementAt(idx);
                string url = string.Format(GlobalVars.SNAPSHOT_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
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
                    if (paths.Contains("CalibrationParas"))
                    {
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"CalibrationParas|{idx}";
                    }
                    if (paths.Contains("MeasurementRatio"))
                    {
                        var cam = Cams[idx];
                        pbImage.DrawMode = 1;
                        pbImage.DrawShape(cam.MeasurementRatio, Color.Magenta);
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"MeasurementRatio|{idx}";
                    }
                    break;
                case "Templates":
                    if (paths.Length > 3)
                    {
                        var roiName = paths[3];
                        var tpl = Templates[idx];
                        var roi = tpl.HoleROIs[roiName];
                        pbImage.DrawMode = 1;
                        pbImage.DrawShape(roi.BBOX, Color.Pink);
                        btnEdit.Enabled = true;
                        LastSelectedNode = $"HoleROIs|{idx}|{roiName}";
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
                case "CalibrationParas":
                    {
                        var camId = selectedNodes[1];
                        var cam = Cams[selectedNodes[1]];                        
                        string url = string.Format(GlobalVars.SNAPSHOT_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
                        var frm = new FormCamCalibration(camId, url);
                        frm.ShowDialog();
                    }                    
                    break;
                case "MeasurementRatio":
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
                        var cam = Actions[selectedNodes[1]];
                        var frm = new FormSelectCam();
                        var result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            cam.CameraId = frm.GetSelectedCamName;
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
                    {
                        var roiName = selectedNodes[2];
                        var roi = pbImage.SaveNewROI();
                        Templates[idx].HoleROIs[roiName].BBOX = roi;
                    }                    
                    break;
                case "TargetROI":
                    {
                        var roi = pbImage.SaveNewROI();
                        Actions[idx].BBox = roi;
                    }                    
                    break;
                case "Position":
                    //Actions[idx].Position = "";
                    break;
                case "MeasurementRatio":
                    {
                        var roi = pbImage.SaveNewROI();
                        var frm = new FormInputBox()
                        {
                            Caption = "Measurement Ratio",
                            Question = "The width is equal to how many milimeter(mm)?"
                        };
                        var result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var inpVal = frm.GetInputValue;
                            if (int.TryParse(inpVal, out int num))
                            {
                                roi.Height = num;
                                Cams[idx].MeasurementRatio = roi;
                                PTZRenderTreeView(cbShowValue.Checked);
                            }
                            else
                                MessageBox.Show("Invalid Input!");
                        }
                    }                    
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

        private static TreeNode AddNode(TreeNode RootNode, string Key, string Val, bool ShowValue = false)
        {
            TreeNode newNode = new(Key);
            RootNode.Nodes.Add(newNode);
            newNode.Tag = Val;
            if (ShowValue)
                newNode.Nodes.Add($"{Key}-val", Val);

            return newNode;
        }

        private void PTZRenderTreeView(bool ShowValue = false)
        {
            var appSetting = GlobalVars.AppSetting;
            TreeNode rootNode = new("AppSetting");

            TreeNode cameraNode = new("Cameras");
            rootNode.Nodes.Add(cameraNode);
            for (var i = 0; i < appSetting.Cams.Count; i++)
            {
                var kv = appSetting.Cams.ElementAt(i);
                var val = kv.Value;
                TreeNode subNode = new(kv.Key);
                cameraNode.Nodes.Add(subNode);
                AddNode(subNode, $"Position", val.Position, ShowValue);
                //var paraNode = AddNode(subNode, $"CalibrationParas", val.IntrinsicParas, ShowValue);
                //if(ShowValue) paraNode.Nodes.Add($"DistCoeffParas-val", val.DistCoeffParas);
                //AddNode(subNode, $"MeasurementRatio", val.MeasurementRatio.ToString(), ShowValue);
            }

            TreeNode actionNode = new("Actions");
            rootNode.Nodes.Add(actionNode);
            for (var i = 0; i < appSetting.Actions.Count; i++)
            {
                var kv = appSetting.Actions.ElementAt(i);
                var val = kv.Value;
                TreeNode subNode = new(kv.Key);
                actionNode.Nodes.Add(subNode);
                AddNode(subNode, $"CamId", val.CameraId, ShowValue);
                AddNode(subNode, $"Position", val.Position, ShowValue);
                //AddNode(subNode, $"TargetROI", val.BBox.ToString(), ShowValue);
            }

            //if(appSetting.Templates is not null)
            //{
            //    TreeNode templateNode = new("Templates");
            //    rootNode.Nodes.Add(templateNode);
            //    for (var i = 0; i < appSetting.Templates.Count; i++)
            //    {
            //        var kv = Templates.ElementAt(i);
            //        var val = kv.Value;
            //        var holeROIs = val.HoleROIs;
            //        TreeNode subNode = new(kv.Key);
            //        templateNode.Nodes.Add(subNode);
            //        for (var j = 0; j < holeROIs.Count; j++)
            //        {
            //            var kv1 = holeROIs.ElementAt(j);
            //            AddNode(subNode, kv1.Key, kv1.Value.BBOX.ToString(), ShowValue);
            //        }
            //    }
            //}

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
