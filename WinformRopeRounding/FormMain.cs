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

        private static readonly SimpleTcpServer tcp = new();
        private readonly List<VideoProcessor> vps = new();
        ObjectDetector? det;
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            var cams = GlobalVars.AppSetting.Cams;
            foreach (var kv in cams)
            {
                var cam = kv.Value;
                var uri = $"http://{cam.Username}:{cam.Password}@{cam.IPAddress}/ISAPI/Streaming/channels/101/picture";
                var vp = new VideoProcessor(uri, EnumMediaInput.HTTP);
                vp.OnFrameReceived += Vp_OnFrameReceived;
                vps.Add(vp);
            }
        }

        #region "TCP"
        public void InitTCP()
        {
            tcp.Start(GlobalVars.AppSetting.TcpPort);
            tcp.ClientConnected += Server_ClientConnected;
            tcp.ClientDisconnected += Server_ClientDisconnected;
            tcp.DataReceived += Server_DataReceived;
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
                VideoCapture cam = new(url);
                Mat refMat = cam.QueryFrame();
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
                det = new ObjectDetector();
                vps[0].Run();
                btnStart.Text = "Stop";
            }
            else
            {
                vps[0].Stop();
                btnStart.Text = "Start";
            }

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            var txt = btnPause.Text;
            if (txt.Equals("Pause"))
            {
                vps[0].Pause();
                btnPause.Text = "Resume";
            }
            else
            {
                vps[0].Pause();
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
            FormColorSpacePicker frm = new(vps[0].CurrentFrame);
            frm.ShowDialog();
        }

        private void cameraCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormCamControl frm = new("Calibration", string.Empty)
            //{
            //    CameraIP = GlobalVars.AppSetting.Cams.Values.ElementAt(0).IPAddress,
            //    CamUsername = GlobalVars.AppSetting.Cams.Values.ElementAt(0).Username,
            //    CamPassword = GlobalVars.AppSetting.Cams.Values.ElementAt(0).Password
            //};
            FormRoiEditor frm = new();
            var curFrame = vps[0].CurrentFrame;
            if(curFrame is not null && curFrame.Ptr != IntPtr.Zero)
            {
                Image img = vps[0].CurrentFrame.ToBitmap();
                frm.SetImage(img);
            }            
            frm.ShowDialog();
        }


    }
}