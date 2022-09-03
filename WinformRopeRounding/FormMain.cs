using Emgu.CV;
using Emgu.CV.Structure;
using Serilog;
using SimpleTCP;
using System.Net.Sockets;
using WinformRopeRounding.Modules.ObjectDetection;
using WinformRopeRounding.Modules.VideoProcessor;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormMain : Form
    {
        //const string url = "rtsp://admin:joseph12345@192.168.1.64:554/Streaming/Channels/0101";
        //const string url = "http://admin:joseph12345@192.168.1.64/ISAPI/Streaming/channels/101/picture";
        //const string url = @"C:\Users\U\Web\CaptureFiles\2022-07-23\";
        //const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813162052323.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd01.jpg";        
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight03.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgd01.jpg";
        //const string url = @"C:\SourceCodes\samples\20220723\192.168.125.64_01_20220723153920285.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_2022082319074257.mp4";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";

        private static readonly SimpleTcpServer tcp = new();
        private VideoProcessor vp;
        ObjectDetector? det;
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            var cams = GlobalVars.AppSetting.Cams;
            var cam = cams.Values.ElementAt(0);
            string url = string.Format(GlobalVars.VIDEO_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
            vp = new VideoProcessor(url, EnumMediaInput.HTTP);
            //foreach (var kv in cams)
            //{
            //    var cam = kv.Value;
            //    string url = string.Format(GlobalVars.VIDEO_SOURCE, cam.Username, cam.Password, cam.IPAddress);
            //    vp = new VideoProcessor(url, EnumMediaInput.HTTP);
            //    vp.OnFrameReceived += Vp_OnFrameReceived;
            //}
            det = new ObjectDetector();
        }

        #region "TCP"
        public void InitTCP()
        {
            var tcpPortNo = GlobalVars.AppSetting.TcpPort;
            tcp.Start(tcpPortNo);
            tcp.ClientConnected += Server_ClientConnected;
            tcp.ClientDisconnected += Server_ClientDisconnected;
            tcp.DataReceived += Server_DataReceived;
            Log.Information($"TCP started at port: {tcpPortNo}");
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            string str = e.MessageString;
            Log.Information($"Data received: {str}");
            if (str == "0")
            {
                tcp.Broadcast("Repeat");
            }
            if (str == "A")
            {
                var locX = 123; var locY = 456;
                tcp.Broadcast($"{locX}:{locY}");
            }
            if (str == "B")
            {
                //VideoCapture cam = new(url);
                //Mat refMat = cam.QueryFrame();
                //var isPass = State1(ref refMat);  //CheckHole1(ref refMat, ROI, 0.2);
                //if (isPass)
                //    tcp.Broadcast("Y");
                //else
                //    tcp.Broadcast("N");
            }
        }
        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Log.Information($"Client disconnected: {e.Client.RemoteEndPoint}");
        }
        private static void Server_ClientConnected(object sender, TcpClient e)
        {
            Log.Information($"Client connected: {e.Client.RemoteEndPoint}");
        }
        #endregion

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var txt = btnStart.Text;
            if(txt.Equals("Start"))
            {
                InitTCP();
                //vp.Run();
                cameraImageBox1.Image = vp.Snapshot();
                btnStart.Text = "Stop";
            }
            else
            {
                vp.Stop();
                btnStart.Text = "Start";
            }

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            var txt = btnPause.Text;
            if (txt.Equals("Pause"))
            {
                vp.Pause();
                btnPause.Text = "Resume";
            }
            else
            {
                vp.Pause();
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
                cameraImageBox1.Image = frame;
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
            FormColorSpacePicker frm = new(vp.CurrentFrame);
            frm.ShowDialog();
        }

        private void cameraCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigEditor frm = new();
            var curFrame = vp.CurrentFrame;
            if(curFrame is not null && curFrame.Ptr != IntPtr.Zero)
            {
                Image img = vp.CurrentFrame.ToBitmap();
                frm.SetImage(img);
            }            
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}