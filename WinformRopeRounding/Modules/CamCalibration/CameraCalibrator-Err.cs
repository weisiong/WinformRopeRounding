using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System.Globalization;
using WinformRopeRounding.Modules.VideoStreaming;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WinformRopeRounding.Modules.CamCalibration
{
    public class CameraCalibrator
    {
        EnumCalMode _currentMode = EnumCalMode.View;
        #region Display and aquaring chess board info
        //const string url = "rtsp://admin:joseph12345@192.168.1.64:554/Streaming/Channels/0101";
        const string url = "http://admin:joseph12345@192.168.1.64/ISAPI/Streaming/channels/101/picture";
        private VideoProcessor vp; // capture device
        //private readonly Mat _frame = new();
        private readonly Mat _grayFrame = new ();
        private int _width; //width of chessboard no. squares in width - 1
        private int _height; // heght of chess board no. squares in heigth - 1
        private float _squareSize;
        private Size _patternSize;  //size of chess board to be detected
        VectorOfPointF _corners = new (); //corners found from chessboard
             

        private static Mat[] _frameArrayBuffer;
        private int _frameBufferSavepoint;
        private bool _startFlag;
        private bool _find;

        #endregion

        #region Getting the camera calibration
        private MCvPoint3D32f[][] _cornersObjectList;
        private PointF[][] _cornersPointsList;
        private VectorOfPointF[] _cornersPointsVec;

        private readonly Mat _cameraMatrix = new(3, 3, DepthType.Cv64F, 1);
        private readonly Mat _distCoeffs = new(8, 1, DepthType.Cv64F, 1);
        #endregion


        public CameraCalibrator(int NumOfFrameBuffer=10, int NumOfChessWidth=9, int NumOfChessHeight=7, int NumOfSquareSize=20)
        {
            _frameArrayBuffer = new Mat[(int)NumOfFrameBuffer];
            _cornersObjectList = new MCvPoint3D32f[_frameArrayBuffer.Length][];
            _cornersPointsList = new PointF[_frameArrayBuffer.Length][];
            _cornersPointsVec = new VectorOfPointF[_frameArrayBuffer.Length];
            _frameBufferSavepoint = 0;

            _width = NumOfChessWidth;       //width of chessboard no. squares in width - 1
            _height = NumOfChessHeight;     // heght of chess board no. squares in heigth - 1
            _squareSize = NumOfSquareSize;
            _patternSize = new Size(_width, _height); //size of chess board to be detected

            vp = new(url, EnumMediaInput.HTTP);
            vp.OnFrameReceived += Vp_OnFrameReceived;
            vp.Run();
        }

        public void Start()
        {  
            //allow the start
            _startFlag = true;
            _currentMode = EnumCalMode.SavingFrames;
        }

        private void Vp_OnFrameReceived(object? sender, VideoProcessorEventArgs e)
        {
            var frame = e.MatSrc;
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                ProcessFrame(frame);
            }
        }

        void ProcessFrame(Mat _frame)
        {
            //_capture.Retrieve(_frame);
            CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);

            //apply chess board detection
            if (_currentMode == EnumCalMode.SavingFrames)
            {
                FindChessBoard(_frame);
                _corners = new VectorOfPointF();
                _find = false;
                CvInvoke.Imshow("OriginalImage", _frame);
            }
            if (_currentMode == EnumCalMode.CalculatingIntrinsics)
            {
                double error = CalculateIntrinsics();
                MessageBox.Show(@"Intrinsic Calculation Error: " + error.ToString(CultureInfo.InvariantCulture), @"Results", MessageBoxButtons.OK, MessageBoxIcon.Information); //display the results to the user
                _currentMode = EnumCalMode.Calibrated;
                CvInvoke.Imshow("CalibratedImage", _frame);
            }
            if (_currentMode == EnumCalMode.Calibrated)
            {
                _frame = GetUndistortedImage(_frame);
                CvInvoke.Imshow("UndistortedImage", _frame);
            }
            //Main_Picturebox.Image = _frame;
           
        }

        public bool FindChessBoard(Mat MatSrc)
        {
            _find = CvInvoke.FindChessboardCorners(_grayFrame, _patternSize, _corners, CalibCbType.AdaptiveThresh | CalibCbType.FastCheck | CalibCbType.NormalizeImage);
            //we use this loop so we can show a colour image rather than a gray:
            if (_find) //chess board found
            {
                //make mesurments more accurate by using FindCornerSubPixel
                CvInvoke.CornerSubPix(_grayFrame, _corners, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.1));

                //if go button has been pressed start aquiring frames else we will just display the points
                if (_startFlag)
                {
                    _frameArrayBuffer[_frameBufferSavepoint] = _grayFrame; //store the image
                    _frameBufferSavepoint++; //increase buffer positon

                    //check the state of buffer
                    if (_frameBufferSavepoint == _frameArrayBuffer.Length)
                        _currentMode = EnumCalMode.CalculatingIntrinsics; //buffer full
                }

                //draw the results
                CvInvoke.DrawChessboardCorners(MatSrc, _patternSize, _corners, _find);                
                string msg = string.Format("{0}/{1}", _frameBufferSavepoint + 1, _frameArrayBuffer.Length);                
                var textOrigin = new Point(50, 50);//int baseLine = 0;var textOrigin = new Point(_frame.Cols - 2 * 120 - 10, _frame.Rows - 2 * baseLine - 10);
                CvInvoke.PutText(MatSrc, msg, textOrigin, FontFace.HersheyPlain, 3, new MCvScalar(0, 0, 255), 4);

                //calibrate the delay bassed on size of buffer
                //if buffer small you want a big delay if big small delay
                //Thread.Sleep(100); //allow the user to move the board to a different position
            }
            return _find;
        }

        public double CalculateIntrinsics()
        {
            for (int k = 0; k < _frameArrayBuffer.Length; k++)
            {
                _cornersPointsVec[k] = new VectorOfPointF();
                CvInvoke.FindChessboardCorners(_frameArrayBuffer[k], _patternSize, _cornersPointsVec[k], CalibCbType.AdaptiveThresh | CalibCbType.FastCheck | CalibCbType.NormalizeImage);
                //for accuracy
                CvInvoke.CornerSubPix(_grayFrame, _cornersPointsVec[k], new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.1));

                //Fill our objects list with the real world mesurments for the intrinsic calculations
                var objectList = new List<MCvPoint3D32f>();
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        objectList.Add(new MCvPoint3D32f(j * _squareSize, i * _squareSize, 0.0F));
                    }
                }
                _cornersObjectList[k] = objectList.ToArray();
                _cornersPointsList[k] = _cornersPointsVec[k].ToArray();
            }

            //our error should be as close to 0 as possible
            Mat[] _rvecs, _tvecs;
            double error = CvInvoke.CalibrateCamera(_cornersObjectList, _cornersPointsList, _grayFrame.Size, _cameraMatrix, _distCoeffs, CalibType.RationalModel, new MCvTermCriteria(30, 0.1), out _rvecs, out _tvecs);

            var rows = _cameraMatrix.Rows;
            var cols = _cameraMatrix.Cols;
            var data = _cameraMatrix.GetData();
            for (var i = 0; i < rows; i++)
            {
                for(var j = 0; j < cols; j++)
                {
                    var val = data.GetValue(i, j);
                    Debug.Write($"{val},");
                }
            }


            //var jsonCameraMatrix = JsonConvert.SerializeObject(_cameraMatrix);
            //var jsonDistCoeff = JsonConvert.SerializeObject(_distCoeffs);

            //Mat cameraMatrix1 = new(3, 3, DepthType.Cv64F, 1);
            //var camMat = JsonConvert.DeserializeObject<Mat>(jsonCameraMatrix);

            //Mat distCoeffs1 = new(8, 1, DepthType.Cv64F, 1);
            //var dcMat = JsonConvert.DeserializeObject(jsonDistCoeff);

            rows = _distCoeffs.Rows;
            cols = _distCoeffs.Cols;
            data = _distCoeffs.GetData();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var val = data.GetValue(i, j);
                    Debug.Write($"{val},");
                }
            }

            return error;
        }

        public Mat GetUndistortedImage(Mat MatSrc)
        {
            Mat outFrame = MatSrc.Clone();
            CvInvoke.Undistort(MatSrc, outFrame, _cameraMatrix, _distCoeffs);
            return outFrame;
        }

        public bool Load(string FilePath)
        {
            return false;
        }
        public bool Save(string FilePath)
        {
            return false;
        }


    }
}
