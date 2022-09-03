using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormSelectCam : Form
    {
        public FormSelectCam()
        {
            InitializeComponent();
        }

        private void FormSelectCam_Load(object sender, EventArgs e)
        {
            var Cams = GlobalVars.AppSetting.Cams;
            foreach (var kv in Cams)
            {
                _ = cboCamera.Items.Add(kv.Key);
            }
            cboCamera.SelectedIndex = 0;
        }

        public string GetSelectedCamName { 
            get
            {
                return cboCamera.Text;
            }        
        }
    }
}
