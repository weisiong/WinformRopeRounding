using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WinformRopeRounding
{
    public partial class FormColorSpacePicker : Form
    {
        private Mat _curFrame;
        //const string url = @"C:\SourceCodes\samples\20220723\192.168.125.64_01_20220723153920285.jpg";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd01.jpg";
        //const string url = @"C:\SourceCodes\samples\20220723\BlueBgd01.jpg";
        const string url = @"C:\SourceCodes\samples\20220723\GreenBgd01.jpg";
        public FormColorSpacePicker(Mat? currentFrame = null)
        {
            InitializeComponent();
            if (currentFrame is null)
            {
                var cam = new VideoCapture(url);
                _curFrame = cam.QueryFrame();
            }                
            else
                _curFrame = currentFrame;

            imgBoxSrc.Image = _curFrame;
        }

        private void Process()
        {
            imgBoxSrc.Image = _curFrame;
            Mat matSrc = _curFrame;
            Mat matHsv = new();
            Mat matDst = new();

            MCvScalar lowerLimit = new(tbHmin.Value, tbSmin.Value, tbVmin.Value);
            MCvScalar upperLimit = new(tbHmax.Value, tbSmax.Value, tbVmax.Value);

            var img_roi = matSrc.ToImage<Bgr, byte>();
            CvInvoke.CvtColor(img_roi, matHsv, ColorConversion.Bgr2Hsv);
            CvInvoke.InRange(matHsv, new ScalarArray(lowerLimit), new ScalarArray(upperLimit), matDst);
            CvInvoke.BitwiseNot(matDst, matDst);

            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(matDst, matDst, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);
            CvInvoke.Dilate(matDst, matDst, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);

            imgBoxDst.Image = matDst;
        }
        
        private void nudHmin_ValueChanged(object sender, EventArgs e)
        {
            tbHmin.Value =(int) nudHmin.Value; Process();
        }

        private void tbHmin_ValueChanged(object sender, EventArgs e)
        {
            nudHmin.Value = tbHmin.Value; Process();
        }

        private void tbSmin_ValueChanged(object sender, EventArgs e)
        {
            nudSmin.Value = tbSmin.Value; Process();
        }

        private void nudSmin_ValueChanged(object sender, EventArgs e)
        {
            tbSmin.Value = (int)nudSmin.Value; Process();
        }

        private void tbVmin_ValueChanged(object sender, EventArgs e)
        {
            nudVmin.Value = tbVmin.Value; Process();
        }

        private void nudVmin_ValueChanged(object sender, EventArgs e)
        {
            tbVmin.Value = (int)nudVmin.Value; Process();
        }

        private void tbHmax_ValueChanged(object sender, EventArgs e)
        {
            nudHmax.Value = tbHmax.Value; Process();
        }

        private void nudHmax_ValueChanged(object sender, EventArgs e)
        {
            tbHmax.Value = (int)nudHmax.Value; Process();
        }

        private void tbSmax_ValueChanged(object sender, EventArgs e)
        {
            nudSmax.Value = tbSmax.Value; Process();
        }

        private void nudSmax_ValueChanged(object sender, EventArgs e)
        {
            tbSmax.Value = (int)nudSmax.Value; Process();
        }

        private void tbVmax_ValueChanged(object sender, EventArgs e)
        {
            nudVmax.Value = tbVmax.Value; Process();
        }

        private void nudVmax_ValueChanged(object sender, EventArgs e)
        {
            tbVmax.Value = (int)nudVmax.Value; Process();
        }

        private void FormColorSpacePicker_Load(object sender, EventArgs e)
        {
            imgBoxSrc.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBoxDst.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //var msg = $"H:({nudHmin.Value},{nudHmax.Value}),S:({nudSmin.Value},{nudSmax.Value}),V:({nudVmin.Value},{nudVmax.Value})";
            //Clipboard.SetText(msg);

            var code = $"MCvScalar lowerLimit = new({nudHmin.Value}, {nudSmin.Value}, {nudVmin.Value});" + Environment.NewLine;
               code += $"MCvScalar upperLimit = new({nudHmax.Value}, {nudSmax.Value}, {nudVmax.Value});";
            Clipboard.SetText(code);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            nudHmin.Value = nudHmin.Minimum; nudSmin.Value = nudSmin.Minimum; nudVmin.Value = nudVmin.Minimum;
            nudHmax.Value = nudHmax.Maximum; nudSmax.Value = nudSmax.Maximum; nudVmax.Value = nudVmax.Maximum;
        }
    }
}
