using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Serilog;
using SimpleTCP;
using System.Net.Sockets;
using WinformRopeRounding.Modules.ObjectDetection;
using WinformRopeRounding.Modules.VideoProcessor;
using WinformRopeRounding.Utilities;
using static Emgu.CV.DepthAI.Camera;

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
        const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813143001761.jpg";
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
            //string url = string.Format(GlobalVars.VIDEO_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
            vp = new VideoProcessor(url, EnumMediaInput.PIC);
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
        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Log.Information($"Client disconnected: {e.Client.RemoteEndPoint}");
        }
        private static void Server_ClientConnected(object sender, TcpClient e)
        {
            Log.Information($"Client connected: {e.Client.RemoteEndPoint}");
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            string req = e.MessageString;
            Log.Information($"RX: {req}");
            switch (req)
            {
                case "0":
                    PerformAction0();
                    break;
                case "A":
                    PerformActionA();
                    break;
                case "B":
                    PerformActionB();
                    break;
                default:
                    PerformActionUndefined();
                    break;
            }
        }
        #endregion


        #region "Perform Actions"
        private void PerformActionUndefined()
        {
            Mat frame = vp.Snapshot();
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                cameraImageBox1.Image = frame;
            }
            var msg = "Undefined";
            tcp.Broadcast(msg);
            Log.Information($"TX: {msg}");
        }
        private void PerformAction0()
        {
            Mat frame = vp.Snapshot();
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                cameraImageBox1.Image = frame;
            }
            var msg = "Repeat";
            tcp.Broadcast(msg);
            Log.Information($"TX: {msg}");
        }
        private void PerformActionB()
        {
            bool isPass = false;
            var bbox = GlobalVars.AppSetting.Actions["B"].BBox;
            Mat frame = vp.Snapshot();
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                if (det is not null)
                {
                    var col = det.Inference(ref frame, true, 0.3f, 0.1f);
                    var firstHead = col.FirstOrDefault(c => c.Label.Equals("Head"));
                    if (firstHead is not null)
                    {
                        if (firstHead.Rect.IntersectsWith(bbox))
                        {
                            isPass = true;
                        }
                    }
                }
                CvInvoke.Rectangle(frame, bbox, new Bgr(Color.White).MCvScalar);
                cameraImageBox1.Image = frame;
            }
            var msg = isPass ? "Y" : "N";
            tcp.Broadcast(msg);
            Log.Information($"TX: {msg}");
        }
        private void PerformActionA()
        {
            int locX = 0; int locY = 0;
            var bbox = GlobalVars.AppSetting.Actions["A"].BBox;

            Mat frame = vp.Snapshot();
            //frame = new(frame, bbox);
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                if (det is not null)
                {
                    var col = det.Inference(ref frame, true, 0.3f, 0.1f);
                    var firstHole = col.FirstOrDefault(c => c.Label.Equals("Base"));
                    var firstHead = col.FirstOrDefault(c => c.Label.Equals("Head"));
                    if (firstHole is not null && firstHead is not null)
                    {
                        var holeX = firstHole.Rect.X + firstHole.Rect.Width;
                        var headX = firstHead.Rect.X + firstHead.Rect.Width;
                        var dist = headX - holeX;
                        if (dist > 0)
                        {
                            CvInvoke.Line(frame, new Point(headX, firstHead.Rect.Y), new Point(headX, firstHole.Rect.Y), new MCvScalar(255, 255, 0), 3); //right line
                            CvInvoke.PutText(frame, $"X:{dist}px", new Point(30, 80), FontFace.HersheySimplex, 1, new MCvScalar(0, 255, 255), 3);// distance pixels
                            locX = dist;
                        }

                        dist = firstHead.Rect.Y - firstHole.Rect.Y;
                        if (dist < 5000)
                        {
                            CvInvoke.Line(frame, new Point(holeX, firstHole.Rect.Y), new Point(headX, firstHole.Rect.Y), new MCvScalar(255, 255, 0), 3); //top line 
                            CvInvoke.PutText(frame, $"Y:{dist}px", new Point(30, 120), FontFace.HersheySimplex, 1, new MCvScalar(0, 255, 255), 3);// distance pixels
                            locY = dist;
                        }
                    }
                }
                cameraImageBox1.Image = frame;
            }
            var msg = $"{locX}:{locY}";
            tcp.Broadcast(msg);
            Log.Information($"TX: {msg}");
        }

        #endregion


        #region "UI Related"
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
            var curFrame = vp.Snapshot(); // .CurrentFrame;
            if(curFrame.DataPointer != IntPtr.Zero)
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
        #endregion
    }
}