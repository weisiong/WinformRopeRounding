namespace WinformRopeRounding
{
    public partial class FormInputBox : Form
    {
        public FormInputBox()
        {
            InitializeComponent();
        }

        public string Caption { get; set; }
        public string Question { get; set; }
        private void FormInputBox_Load(object sender, EventArgs e)
        {
            Text = Caption;
            label1.Text = Question;
        }

        public string GetInputValue
        {
            get
            {
                return textBox1.Text;
            }
        }

    }
}
