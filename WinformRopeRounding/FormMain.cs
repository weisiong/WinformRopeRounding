using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Rapid;
using Emgu.CV.Structure;
using Serilog;
using SimpleTCP;
using System.Drawing;
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
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight03.mp4"; //YellowBgdWithLight01.mp4"; // BlackBgd.mp4"; //BlueBgdWithLight01.mp4";
        //const string url = "rtsp://admin:Heliotech@192.168.125.64:554/Streaming/Channels/0101";
        const string url = "http://admin:Heliotech@192.168.125.64/ISAPI/Streaming/channels/101/picture";
        //const string url = "http://admin:Heliotech@192.168.125.65/ISAPI/Streaming/channels/101/picture";
        //const string url = "http://admin:Heliotech@192.168.125.66/ISAPI/Streaming/channels/101/picture";
        //const string url = "http://admin:Heliotech@192.168.125.67/ISAPI/Streaming/channels/101/picture";
        //const string url = @"C:\SourceCodes\samples\BlueBgdWithLight01_002";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight04.mp4"; //YellowBgdWithLight01.mp4"; // BlackBgd.mp4"; //BlueBgdWithLight01.mp4";
        //const string url = @"C:\SourceCodes\samples\20220723\BlackBgd01.jpg";        
        //const string url = @"C:\SourceCodes\samples\20220723\GreenBgdWithLight03.mp4";
        //const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813165506163.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190942145.jpg";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_2022082319074257.mp4";
        //const string url = @"C:\SourceCodes\samples\20220823\192.168.125.64_01_20220823190947761.mp4";
        //const string url = @"C:\SourceCodes\samples\20220813\192.168.125.64_01_20220813162052323.mp4";
        //const string url = @"C:\SourceCodes\samples\20220917-ApirlTag";
        //const string url = @"C:\SourceCodes\samples\20230117";
        

        private System.Windows.Forms.Timer timer = new();

        private SimpleTcpServer tcp;
        private Dictionary<string, VideoProcessor> vps = new();
        private Dictionary<string, PtzCamControlSDK> ptzCtrs = new();
        private Dictionary<string, ObjectDetector>? dets = new();
        private Dictionary<string, Emgu.CV.UI.ImageBox>? imgBoxes= new();
        private Apriltag aptag = new("canny", false, "tag36h11");
        private Arucotag actag = new(Emgu.CV.Aruco.Dictionary.PredefinedDictionaryName.Dict4X4_50);
        private CameraCalibrator camCal;
        public FormMain()
        {
            InitializeComponent();
            Text = "Rope Rounding, ver.20230401_1700";
            cboModel.SelectedIndex = 0;
            lblWarning.Visible = false;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            cboModel.Items.Clear();
            var products = GlobalVars.AppSetting.Products;
            foreach ( var product in products ) { 
                cboModel.Items.Add(product.Name);
            }
            cboModel.SelectedIndex = 0;

            //var cams = GlobalVars.AppSetting.Cams;
            //var cam = cams.Values.ElementAt(0);
            //string url = string.Format(GlobalVars.VIDEO_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
            //vp = new VideoProcessor(url, EnumMediaInput.HTTP);
            //det = new ObjectDetector();
        }

        #region "PTZ"
        private async Task InitPTZAsync()
        {
            if (ptzCtrs.Count() > 0) return;

            var camSettings = GlobalVars.AppSetting.Cams;
            foreach (var kv in camSettings)
            {
                var key = kv.Key;
                var cam = kv.Value;
                if (!cam.Enable) continue;
                var ptz = new PtzCamControlSDK();
                ptzCtrs.Add(key, ptz);
                Log.Information($"Initialize {key}...");
                var success = await ptz.InitialiseAsync(cam.IPAddress, cam.Username, cam.Password);
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
            if (tcp is not null)
            {
                tcp.ClientConnected -= Server_ClientConnected;
                tcp.ClientDisconnected -= Server_ClientDisconnected;
                tcp.DataReceived -= Server_DataReceived;
                tcp.Stop();
                var clients = tcp.GetListeningIPs();
                clients.Clear();
            }
            var tcpPortNo = GlobalVars.AppSetting.TcpPort;
            tcp = new();
            tcp.Start(tcpPortNo);
            tcp.ClientConnected += Server_ClientConnected;
            tcp.ClientDisconnected += Server_ClientDisconnected;
            tcp.DataReceived += Server_DataReceived;
            Log.Information($"TCP started at port: {tcpPortNo}");
        }

        private void InitTimer()
        {
            if (timer is not null)
            {
                timer.Enabled = false;
                timer.Tick -= Timer_Tick;
                timer.Dispose();
            }
            timer = new();
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private int offlineCounter = 0;
        private string lastReq = string.Empty;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (curState == 0)
            {
                if (lastReq == string.Empty)
                    WaitForResponse();
                else
                {
                    PerformActionIdle();
                    lastReq = string.Empty;
                }
            }
            else if (curState == 1)
            {
                PerformAction0();
                curState = 2;
            }
            else if (curState == 2)
            {
                PerformStartTask();
                curState = 3;
            }
            else if (curState == 3)
            {
                switch (lastReq)
                {
                    case "A":
                        {
                            PerformActionA();
                        }
                        break;
                    case "B":
                        {
                            PerformActionB();
                        }
                        break;
                    case ">":
                        if (txtStatus.Text == "Stop")
                        {
                            PerformActionIdle();
                        }
                        else
                        {
                            PerformContinueTask();
                        }
                        break;
                    case "+":
                        {
                            curUnitCompleted++;
                            txtCounter.Text = curUnitCompleted.ToString();
                            if (stopAfterThisUnit == 1)
                            {
                                stopAfterThisUnit = 0;
                                curState = 4;
                                btnStart.PerformClick();
                                PerformActionIdle();
                            }
                            else if(unitToComplete > curUnitCompleted)
                            {
                                curState = 4;
                            }
                            else
                            {
                                curState = 0;
                                btnStart.PerformClick();
                                PerformActionIdle();
                            }
                            txtCounter.Text = curUnitCompleted.ToString();
                        }
                        break;
                    case "!":
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = "Cannot measure image XY. Please Acknowledge!";
                            btnAcknowledge.Visible = true;
                        }
                        break;
                    case "^":
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = "Robot cannot grip the wire. Please Acknowledge!";
                            btnAcknowledge.Visible = true;
                        }
                        break;
                        //default:
                        //    PerformActionUndefined();
                        //    break;
                }

            }
            else if (curState == 4)
            {
                PerformActionIdle();
                curState = 2;
            }
            
            if (--offlineCounter <= 0)
            {
                lblABBStatus.Text = "ABB OFFLINE";
                lblABBStatus.BackColor = Color.Red;
            }
            else
            {
                lblABBStatus.Text = "ABB ONLINE";
                lblABBStatus.BackColor = Color.Green;
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

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            lastReq = e.MessageString;
            Log.Information($"RX: {lastReq}");
            offlineCounter = 5;
        }
        #endregion

        #region "Perform Actions"

        private void PerformContinueTask()
        {
            var resp = ">";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }

        private void PerformStartTask()
        {
            var resp = "1";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }

        private void PerformActionIdle()
        {
            var resp = "?";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }

        private void WaitForResponse()
        {
            var resp = "Waiting Response...";
            Log.Information($"{resp}");
        }

        private void PerformActionUndefined()
        {
            var vp = vps["Cam1"];
            Mat frame = vp.Snapshot();
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                cameraImageBox1.Image = frame;
            }
            var resp = "Undefined";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }
        private void PerformAction0()
        {
            var modelId = selectedModel;
            var resp = $"01234{modelId}ThisIsTestingData";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }
        private void PerformAction2()
        {
            var resp = $"2";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}, Turn Left.");
        }
        private void PerformAction3()
        {
            var resp = $"3";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}, Turn Right");
        }
        private void PerformActionZ()
        {
            bool isPass = false;
            var camId = GlobalVars.AppSetting.Actions["B"].CameraId;
            var bbox = GlobalVars.AppSetting.Actions["B"].BBox;
            var vp = vps[camId];
            var det = dets[camId];
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
                var imgBox = imgBoxes[camId];
                imgBox.Image = frame;
            }
            var resp = isPass ? "Y" : "N";
            tcp.Broadcast(resp);
            Log.Information($"TX: {resp}");
        }

        private void PerformActionA()
        {
            var camId = GlobalVars.AppSetting.Actions["A"].CameraId;
            string resp = DisplayHeadPoints(camId);
            tcp.Broadcast(resp);
            Draw4SidePolygonROI(camId);
        }

        private void PerformActionB()
        {
            var camId = GlobalVars.AppSetting.Actions["B"].CameraId;
            string resp = DisplayHeadPoints(camId);
            tcp.Broadcast(resp);
            Draw4SidePolygonROI(camId);
        }

        private string DisplayHeadPoints(string camId)
        {
            var vp = vps[camId];
            Mat frame = vp.Snapshot();
            List<Tuple<Point, float>> headPoints = new();
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                headPoints = GetBaseToHeadsPos(camId, ref frame);
                var imgBox = imgBoxes[camId];
                imgBox.Image = frame;
                //cameraImageBox1.Image = frame;
            }

            var resp = string.Empty; //$"{locX}:{locY}";
            foreach (var tuple in headPoints)
            {
                var pt = tuple.Item1;
                var cl = Math.Round(tuple.Item2 * 100, 0);
                resp += $"{pt.X}:{pt.Y}:{cl},";
            }

            resp = resp.TrimEnd(',');
            Log.Information($"TX: {resp}");
            return resp;
        }

        private void Draw4SidePolygonROI(string camId)
        {
            var imgBox = imgBoxes[camId];
            using Graphics g = imgBox.CreateGraphics();

            float rH = imgBox.Height * 1.0f / imgBox.PreferredSize.Height;
            float rW = imgBox.Width * 1.0f / imgBox.PreferredSize.Width;

            var px =Convert.ToInt16( Convert.ToInt16(nudOffsetX.Value) * rW);
            var py = Convert.ToInt16(Convert.ToInt16(nudOffsetY.Value) * rH);
            var pt = new Point(px, py);
            var offsetPt = new Point(px, py);

            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle { X = offsetPt.X-5, Y=offsetPt.Y-5, Width = 10, Height= 10});

            var Pts = new List<Point>();
            px = Convert.ToInt16(Convert.ToInt16(nudPt1X.Value) * rW);
            py = Convert.ToInt16(Convert.ToInt16(nudPt1Y.Value) * rH);
            pt = new Point(px, py);
            pt.Offset(offsetPt);
            Pts.Add(pt);
            
            px = Convert.ToInt16(Convert.ToInt16(nudPt2X.Value) * rW);
            py = Convert.ToInt16(Convert.ToInt16(nudPt2Y.Value) * rH);
            pt = new Point(px, py);
            pt.Offset(offsetPt);
            Pts.Add(pt);

            px = Convert.ToInt16(Convert.ToInt16(nudPt3X.Value) * rW);
            py = Convert.ToInt16(Convert.ToInt16(nudPt3Y.Value) * rH);
            pt = new Point(px, py);
            pt.Offset(offsetPt);
            Pts.Add(pt);

            px = Convert.ToInt16(Convert.ToInt16(nudPt4X.Value) * rW);
            py = Convert.ToInt16(Convert.ToInt16(nudPt4Y.Value) * rH);
            pt = new Point(px, py);
            pt.Offset(offsetPt);
            Pts.Add(pt);

            g.DrawPolygon(new Pen(Color.Red), Pts.ToArray());
        }

        private List<Result> RemoveNegHead(IEnumerable<Result> col)
        {
            List<Result> newCol = new ();
            var metalBase = col.FirstOrDefault(c => c.Label.Equals("Base"));
            if(metalBase is not null)
            {
                foreach (var obj in col)
                {
                    if(obj.Label.Equals("Head"))
                    {
                        if (obj.Rect.X > metalBase.Rect.X)
                        {
                            newCol.Add(obj);
                        }
                    }
                    else
                    {
                        newCol.Add(obj);
                    }
                }
            }
            return newCol;
        }

        private Point BasePoint = new();
        private List<Tuple<Point, float>> GetBaseToHeadsPos(string camId, ref Mat frame)
        {
            List<Tuple<Point,float>> headPoints = new();
            var det = dets[camId];
            if (det is not null)
            {
                var objs = det.Inference(ref frame, false, 0.1f, 0.1f);
                var col = RemoveNegHead(objs);
                var firstBase = col.FirstOrDefault(c => c.Label.Equals("Base"));
                var firstHead = col.FirstOrDefault(c => c.Label.Equals("Head"));
                if (firstBase is not null && firstHead is not null)
                {
                    foreach (Result itm in col)
                    {
                        if (itm.Label.Equals("Hole")) continue;

                        if (itm.Label.Equals("Base"))
                        {
                            CvInvoke.Rectangle(frame, itm.Rect, new Bgr(Color.Pink).MCvScalar, 3);
                        }
                        if (itm.Label.Equals("Head"))
                        {
                            
                            CvInvoke.Rectangle(frame, itm.Rect, new Bgr(Color.Blue).MCvScalar, 3);

                            var baseX = firstBase.Rect.X + firstBase.Rect.Width;
                            var headX = itm.Rect.X + itm.Rect.Width;
                            var distX = headX - baseX;

                            BasePoint.X= baseX; 
                            BasePoint.Y= firstBase.Rect.Y + firstBase.Rect.Height;

                            if (distX > 0)
                            {
                                CvInvoke.Line(frame, new Point(headX, itm.Rect.Y), new Point(headX, firstBase.Rect.Y), new MCvScalar(255, 255, 0), 3); //right line
                                //CvInvoke.PutText(frame, $"X:{distX}px", new Point(30, 100), FontFace.HersheySimplex, 1, new MCvScalar(0, 255, 255), 3);// distance pixels
                            }

                            var distY = itm.Rect.Y - firstBase.Rect.Y;
                            if (0 < distY && distY < 5000)
                            {
                                CvInvoke.Line(frame, new Point(baseX, firstBase.Rect.Y), new Point(headX, firstBase.Rect.Y), new MCvScalar(255, 255, 0), 3); //top line 
                                //CvInvoke.PutText(frame, $"Y:{distY}px", new Point(30, 140), FontFace.HersheySimplex, 1, new MCvScalar(0, 255, 255), 3);// distance pixels
                            }

                            if(distX > 0  && 0 <  distY && distY < 5000)
                            {
                                headPoints.Add(new Tuple<Point, float>(new Point(distX, distY),itm.Confidence));
                            }
                        }
                        //if (itm.Label.Equals("Hole"))
                        //{
                        //    CvInvoke.Rectangle(frame, itm.Rect, new Bgr(Color.White).MCvScalar, 3);
                        //}
                    }                    
                }                
            }

            return headPoints;
        }

        #endregion

        #region "UI Related"
        private async void btnInitialize_Click(object sender, EventArgs e)
        {
            var modelName = cboModel.Text;
            if(string.IsNullOrEmpty(modelName)) { MessageBox.Show("Please select a model.");return;}
            var product = GlobalVars.AppSetting.Products.FirstOrDefault(x => x.Name == modelName);
            if(product is null) { MessageBox.Show("The model not exist!"); return; }

            vps.Clear();
            dets.Clear();
            var modelFiles = product.ModelFiles.Split(',');
            foreach( var file in modelFiles) { 
                Console.Write(file);
                var act = GlobalVars.AppSetting.Actions[file];
                var cam = GlobalVars.AppSetting.Cams[act.CameraId];                
                var url = string.Format(GlobalVars.SNAPSHOT_SOURCE_FORMAT, cam.Username, cam.Password, cam.IPAddress);
                var vp = new VideoProcessor(url, EnumMediaInput.HTTP);
                vp.CamId = act.CameraId;
                vps.Add(act.CameraId, vp);
                dets.Add(act.CameraId, new ObjectDetector(file));                
            }
            await InitPTZAsync();
            InitValues();
            InitTCP();
            InitTimer();

            imgBoxes.Clear();   
            imgBoxes.Add("Cam1", cameraImageBox1);
            imgBoxes.Add("Cam2", cameraImageBox2);

            cameraImageBox1.Image = vps["Cam1"].Snapshot();
            cameraImageBox2.Image = vps["Cam2"].Snapshot();

            Log.Information("Initialization fully complete.");
        }

        private void InitValues()
        {
            lastReq = string.Empty;
            curState = 0;
            unitToComplete = 0;
            stopAfterThisUnit = 0;
            curUnitCompleted = 0;
            selectedModel = string.Empty;
            lblWarning.Visible = false;
            lblWarning.Text = string.Empty;
            btnAcknowledge.Visible = false;
        }

        private int stopAfterThisUnit = 0;
        private int unitToComplete = 0;
        private int curUnitCompleted = 0;
        private int curState = 0;
        private string selectedModel = string.Empty;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                selectedModel = cboModel.Text;
                curState = 1;
                btnStart.Text = "Stop";
                txtStatus.Text = "Running";
                unitToComplete = Convert.ToInt16(nudUnit.Value);
                curUnitCompleted = 0;
                txtCounter.Text = curUnitCompleted.ToString();
                btnStop.Enabled = true;
            }
            else
            {
                curState = 0;
                btnStart.Text = "Start";
                txtStatus.Text = "Standby";
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            stopAfterThisUnit = 1;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            PerformAction2();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            PerformAction3();
        }

        private void BtnStartTestA_Click(object sender, EventArgs e)
        {
            var txt = btnStartTestA.Text;
            if (txt.Equals("Start Test Left"))
            {
                //btnInitialize.PerformClick();
                curState = 3;
                lastReq = "A";
                btnStartTestA.Text = "Stop Test Left";
            }
            else
            {
                curState = 0;
                lastReq = string.Empty;
                btnStartTestA.Text = "Start Test Left";
            }
        }

        private void btnStartTestB_Click(object sender, EventArgs e)
        {
            var txt = btnStartTestB.Text;
            if (txt.Equals("Start Test Right"))
            {
                //btnInitialize.PerformClick();
                curState = 3;
                lastReq = "B";
                btnStartTestB.Text = "Stop Test Right";
            }
            else
            {
                curState = 0;
                lastReq = string.Empty;
                btnStartTestB.Text = "Start Test Right";
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            var txt = btnPause.Text;
            if (txt.Equals("Pause"))
            {
                foreach (var kv in vps)
                {
                    var vp = kv.Value;
                    vp.Pause();
                }                
                btnPause.Text = "Resume";
            }
            else
            {
                foreach (var kv in vps)
                {
                    var vp = kv.Value;
                    vp.Pause();
                }
                btnPause.Text = "Pause";
            }
        }

        private void Vp_OnFrameReceived(object? sender, VideoProcessorEventArgs e)
        {
            var camId = e.CamId;
            var det = dets[camId];

            var frame = e.MatSrc;
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                if (det is not null)
                {
                    //int locX = 0; int locY = 0;
                    //GetBaseToHeadPos(ref locX, ref locY, ref frame);

                    //var col = det.Inference(ref frame, false, 0.1f, 0.1f);
                    //OnUpdate(ref frame, col);

                    _ = GetBaseToHeadsPos(camId, ref frame);
                    DisplayHeadPoints(camId);
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
                    CvInvoke.Rectangle(frame, itm.Rect, new Bgr(Color.White).MCvScalar, 3);
                }
            }
        }

        private void colorSpacePickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormColorSpacePicker frm = new(vp.CurrentFrame);
            //frm.ShowDialog();
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

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            lblWarning.Text = string.Empty;
            lblWarning.Visible = false;
            btnAcknowledge.Visible = false;
            btnStart.PerformClick();
            btnInitialize.PerformClick();                            
        }

    }
}