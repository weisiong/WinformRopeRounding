using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormRoiEditor : Form
    {
        private Image imgOrg;
        public void SetImage(Image image)
        {
            imgOrg = (Image)image.Clone();
        }

        public FormRoiEditor()
        {
            InitializeComponent();
        }

        private void FormRoiEditor_Load(object sender, EventArgs e)
        {
            //const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813172820698.jpg";
            //var img = Image.FromFile(url);
            ucEditor.LoadSetting();
            ucEditor.SetImage(imgOrg);
        }
    }
}
