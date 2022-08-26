using Emgu.CV;
using Emgu.CV.Structure;
using WinformRopeRounding.Modules.ObjectDetection;
using WinformRopeRounding.Modules.VideoProcessor;

namespace WinformRopeRounding
{
    public partial class FormMain : Form
    {
        //const string url = "rtsp://admin:joseph12345@192.168.125.64:554/Streaming/Channels/0101";
        const string url = "http://admin:joseph12345@192.168.1.64/ISAPI/Streaming/channels/101/picture";
        //const string url = @"C:\Users\U\Web\CaptureFiles\2022-07-23\";
        //const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813162052323.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd01.jpg";        
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight03.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgd01.jpg";
        //const string url = @"C:\SourceCodes\samples\20220723\192.168.125.64_01_20220723153920285.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_2022082319074257.mp4";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";
        
        VideoProcessor? vp;
        ObjectDetector? det;
        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var txt = btnStart.Text;
            if(txt.Equals("Start"))
            {
                det = new ObjectDetector();
                vp = new(url, EnumMediaInput.HTTP);
                vp.OnFrameReceived += Vp_OnFrameReceived;
                vp.Run();
                btnStart.Text = "Stop";
            }
            else
            {
                vp?.Stop();
                btnStart.Text = "Start";
            }

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            var txt = btnPause.Text;
            if (txt.Equals("Pause"))
            {
                vp?.Pause();
                btnPause.Text = "Resume";
            }
            else
            {
                vp?.Pause();
                btnPause.Text = "Pause";
            }   
        }
        
        private void Vp_OnFrameReceived(object? sender, VideoProcessorEventArgs e)
        {
            var frame = e.MatSrc;           
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {               
                if (det is not null)
                { 
                    var col = det.Inference(ref frame, false, 0.3f, 0.1f);
                    OnUpdate(ref frame, col);
                }
                cameraImageBox.Image = frame;
            }
        }
        
        private static void OnUpdate(ref Mat frame, IEnumerable<Result> col)
        {
            foreach (Result itm in col)
            {
                if (itm.Label.Equals("Base") || itm.Label.Equals("Head"))
                {
                    CvInvoke.Rectangle(frame, itm.Rect, new Bgr(Color.White).MCvScalar);
                }
            }
        }

        private void colorSpacePickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormColorSpacePicker frm = new(vp?.CurrentFrame);
            frm.ShowDialog();
        }
    }
}