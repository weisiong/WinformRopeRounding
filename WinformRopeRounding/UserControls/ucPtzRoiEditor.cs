using System.Diagnostics;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding.UserControls
{
    //public partial class ucPtzRoiEditor : UserControl
    //{
    //}

    public partial class ucPtzRoiEditor : UserControl
    {
        public event EventHandler<string> RetakePicture;

        private string ConfigFullFileName = string.Empty;

        public string CameraIP { get; set; }
        public string ControllerIP { get; set; }
        public string LotName { get; set; }
        public string ControllerType { get; set; }

        public string RtspPath { get; set; }
        public string CamUsername { get; set; }
        public string CamPassword { get; set; }
        public int CameraId { get; set; }

        public ucPtzRoiEditor()
        {
            InitializeComponent();
            lblLocation.Text = string.Empty;
            pbImage.MouseMove += PbImage_OnMouseMove;
            btnSave.Enabled = false;
        }

        ~ucPtzRoiEditor()
        {
            pbImage.MouseMove -= PbImage_OnMouseMove;
        }

        public void LoadSetting()
        {
            var actions = GlobalVars.AppSetting.Actions;
            foreach (Utilities.Action act in actions)
            {
                pbImage.Actions.Add(act.ActId, act);
            }
            PTZRenderTreeView(true);
        }

        private void PbImage_OnMouseMove(object sender, MouseEventArgs e)
        {
            lblLocation.Text = $"Pointer: ({e.X},{e.Y})";
        }

        public void SetImage(Image image)
        {
            pbImage.SetImage(image);
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

        private void tvMain_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Name.Contains("-val")) e.Cancel = true;
        }

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var key = TreeView.SelectedNode.Name.Split('-')[1];

                pbImage.LastSelectedNode = TreeView.SelectedNode.Name;

                //if (TreeView.SelectedNode.Name.Contains("MotionROI"))
                //{
                //    var roi = pbImage.Movements[key];
                //    pbImage.ResetSelectedRegion();
                //    pbImage.DrawMode = 2;
                //    DrawRectROI(roi.MotionROI, Color.Yellow);
                //    btnEdit.Enabled = true;
                //}
                //if (TreeView.SelectedNode.Name.Contains("LotROI"))
                //{
                //    pbImage.ResetSelectedRegion();
                //    pbImage.DrawMode = 1;

                //    var movs = pbImage.Movements;
                //    foreach (var mov in movs)
                //    {
                //        var lot = mov.Value.LotROIs
                //        .FirstOrDefault(a => a.SeqId.ToString() == key);
                //        if (lot != null)
                //        {
                //            DrawRectROI(lot.Lot, Color.Orange);
                //            btnEdit.Enabled = true;
                //            break;
                //        }
                //    }
                //    return;
                //}
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

        }

        private void DrawRectROI(Rectangle Roi, Color color)
        {
            pbImage.DrawShape(new List<Point>()
                {
                    new Point(Roi.X,Roi.Y),
                    new Point(Roi.X + Roi.Width, Roi.Y + Roi.Height)
                }, color);
        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    System.Windows.Forms.ContextMenu cm = new ContextMenu();
            //    cm.MenuItems.Add("Change", new EventHandler(Edit_Region));
            //    cm.MenuItems.Add("Clear", new EventHandler(Clear_Region));
            //    TreeView.ContextMenu = cm;
            //}
        }

        private void Clear_Region(object sender, EventArgs e)
        {
            pbImage.ResetSelectedRegion();
        }

        private void Edit_Region(object sender, EventArgs e)
        {
            pbImage.ResetSelectedRegion();

            var frm = new FormCamControl("Position View", string.Empty)
            {
                //RtspPath = RtspPath,
                CameraIP = CameraIP,
                CamUsername = CamUsername,
                CamPassword = CamPassword
            };
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var img = frm.SnapshootImage;
                //var newImg = new Bitmap(img, new Size(1920, 1080));
                this.SetImage(img);
                //mov.LocInfo = frm.InputValue;
                var locInfo = frm.InputValue;
                PTZRenderTreeView(cbShowValue.Checked);
            }

            pbImage.EnabledEditMode = true;

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pbImage.SaveNewROI();
            pbImage.DrawMode = 0;
            PTZRenderTreeView(cbShowValue.Checked);
            btnSave.Enabled = false;
        }

        private void cbShowValue_CheckedChanged(object sender, EventArgs e)
        {
            PTZRenderTreeView(cbShowValue.Checked);
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var key = TreeView.SelectedNode.FullPath; // .Name.Split('-')[1];
            Debug.WriteLine("Key:" + key);

            pbImage.LastSelectedNode = TreeView.SelectedNode.Name;
        }

        private static void AddNode(TreeNode RootNode,string Key, string Val, bool ShowValue = true)
        {
            TreeNode newNode = new(Key);
            RootNode.Nodes.Add(newNode);
            if(ShowValue)
                newNode.Nodes.Add($"{Key}-val", Val);
        }

        private void PTZRenderTreeView(bool ShowValue = false)
        {
            var appSetting = GlobalVars.AppSetting;

            TreeNode rootNode = new("AppSetting");
            TreeNode tplNode = new("Template");
            rootNode.Nodes.Add(tplNode);

            var baseROI = appSetting.Template.BaseROI;
            AddNode(tplNode, baseROI.Name, baseROI.BBOX.ToString());

            foreach (var hole in appSetting.Template.HoleROIs)
            {
                AddNode(tplNode, hole.Name, hole.BBOX.ToString());
            }

            TreeNode actsNode = new("Actions");
            rootNode.Nodes.Add(actsNode);
            foreach (var act in appSetting.Actions)
            {
                TreeNode actNode = new(act.ActId);
                actsNode.Nodes.Add(actNode);

                AddNode(actNode, $"CamId", act.CamId.ToString());
                AddNode(actNode, $"PTZInfo", act.PtzInfo.ToString());
                AddNode(actNode, $"TargetROI", act.BBox.ToString());
            }
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add(rootNode);
            TreeView.ExpandAll();
        }


    }

}