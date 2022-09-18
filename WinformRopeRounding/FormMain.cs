using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Serilog;
using SimpleTCP;
using System.Net.Sockets;
using WinformRopeRounding.Modules.ArucoTag;
using WinformRopeRounding.Modules.CamCalibration;
using WinformRopeRounding.Modules.ObjectDetection;
using WinformRopeRounding.Modules.PtzController;
using WinformRopeRounding.Modules.Tags;
using WinformRopeRounding.Modules.VideoStreaming;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormMain : Form
    {
        //const string url = "rtsp://admin:joseph12345@192.168.1.64:554/Streaming/Channels/0101";
        //const string url = "http://admin:joseph12345@192.168.1.64/ISAPI/Streaming/channels/101/picture";
        //const string url = @"C:\SourceCodes\samples\BlueBgdWithLight01_002";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight04.mp4"; //YellowBgdWithLight01.mp4"; // BlackBgd.mp4"; //BlueBgdWithLight01.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd01.jpg";        
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight03.mp4";
        const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813165506163.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190942145.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_2022082319074257.mp4";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";
        //const string url = @"C:\SourceCodes\samples\20220917-ApirlTag";

        private static readonly SimpleTcpServer tcp = new();
        private VideoProcessor vp;
        private Dictionary<string,PtzCamControl> ptzCtrs = new();
        ObjectDetector? det;
        private Apriltag aptag = new("canny", false, "tag36h11");
        private Arucotag actag = new(Emgu.CV.Aruco.Dictionary.PredefinedDictionaryName.Dict4X4_50);
        private CameraCalibrator camCal;
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

        #region "PTZ"
        private async Task InitPTZAsync()
        {
            var camSettings = GlobalVars.AppSetting.Cams;
            foreach (var kv in camSettings)
            {
                var key = kv.Key;
                var cam = kv.Value;
                if (!cam.Enable) continue;
                var ptz = new PtzCamControl();
                ptzCtrs.Add(key, ptz);
                Log.Information($"Initialize {key}...");
                var success = await ptz.InitialiseAsync(cam.IPAddress, cam.Username , cam.Password);
                if (success)
                {
                    await ptz.SetPositionAsync(cam.Position);
                    Log.Information($"Set {key} position success.");
                }
                else
                {
                    Log.Information($"Initialize {key} failed.");
                }
            }
        }
        #endregion

        #region "TCP"
        private void InitTCP()
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
                    var HeadFound = col.FirstOrDefault(c => c.Label.Equals("Head"));
                    if (HeadFound is not null)
                    {
                        if (HeadFound.Rect.IntersectsWith(bbox)) isPass = true;
                    }
                    var BodyFound = col.FirstOrDefault(c => c.Label.Equals("Body"));
                    if (BodyFound is not null)
                    {
                        if (BodyFound.Rect.IntersectsWith(bbox)) isPass = true;
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
        private async void btnInitialize_Click(object sender, EventArgs e)
        {
            await InitPTZAsync();
            InitTCP();
            cameraImageBox1.Image = vp.Snapshot();
            Log.Information("Initialization fully complete.");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var txt = btnStart.Text;
            if(txt.Equals("Start"))
            {
                vp.OnFrameReceived += Vp_OnFrameReceived;
                vp.Run();
                btnStart.Text = "Stop";
            }
            else
            {
                vp.OnFrameReceived -= Vp_OnFrameReceived;
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
                    var col = det.Inference(ref frame, true, 0.3f, 0.1f);
                    OnUpdate(ref frame, col);
                }

                //if (aptag is not null)
                //{
                //    DrawAprilTag(frame);
                //}

                //if (actag is not null)
                //{
                //    actag.Detect(frame);
                //}

                //if (camCal is not null)
                //{
                //    frame = camCal.GetUndistortedImage(frame);
                //}

                cameraImageBox1.Image = frame;
            }
        }

        private void DrawAprilTag(Mat? frame)
        {
            if (frame is null) return;
            var result = aptag.detect(frame);
            foreach (TagDetection tag in result)
            {
                Point[] points = tag.points;
                int X = (points[0].X + points[1].X + points[2].X + points[3].X) / 4;
                int Y = (points[0].Y + points[1].Y + points[2].Y + points[3].Y) / 4;
                //CvInvoke.Circle(frame, new Point(X, Y), 14, new MCvScalar(0, 0, 255), 4, LineType.EightConnected, 0);
                for (int i = 0; i < 4; i++)
                {
                    CvInvoke.Line(frame, points[i], points[(i + 1) % 4], new MCvScalar(255, 255, 0), 2);
                }
                CvInvoke.PutText(frame, tag.id.ToString(), new Point(X, Y), FontFace.HersheySimplex, 1, new MCvScalar(255, 255, 0), 3);
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
        private void configEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigEditor frm = new();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion

        private void btnStartCalibrate_Click(object sender, EventArgs e)
        {
            camCal = new(url);
            camCal.Start();
        }


    }
}