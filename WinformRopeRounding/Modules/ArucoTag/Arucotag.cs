using Emgu.CV.Aruco;
using Emgu.CV.Util;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WinformRopeRounding.Modules.ArucoTag
{
    public class Arucotag
    {
        private const int markersX = 4;
        private const int markersY = 4;
        private const int markersLength = 80;
        private const int markersSeparation = 30;

        private Mat _cameraMatrix = new();
        private Mat _distCoeffs = new();
        private Mat rvecs = new();
        private Mat tvecs = new();

        private DetectorParameters _detectorParameters;
        private Dictionary _dict;
        private GridBoard _gridBoard;

        public Arucotag(Dictionary.PredefinedDictionaryName name = Dictionary.PredefinedDictionaryName.Dict4X4_100)
        {
            CvInvoke.Init();
            _detectorParameters = DetectorParameters.GetDefault();
            _dict = new(name);
            _gridBoard = new GridBoard(markersX, markersY, markersLength, markersSeparation, _dict);
        }

        public Mat Detect(Mat Srcframe)
        {
            var frameCopy = Srcframe;
            //Srcframe.CopyTo(_frameCopy);
            using VectorOfInt ids = new();
            using VectorOfVectorOfPointF corners = new();
            using VectorOfVectorOfPointF rejected = new();
            ArucoInvoke.DetectMarkers(frameCopy, _dict, corners, ids, _detectorParameters, rejected);
            if (ids.Size > 0)
            {
                ArucoInvoke.RefineDetectedMarkers(frameCopy, _gridBoard, corners, ids, rejected, null, null, 10, 3, true, null, _detectorParameters);
                ArucoInvoke.DrawDetectedMarkers(frameCopy, corners, ids, new MCvScalar(0, 255, 255));

                if (!_cameraMatrix.IsEmpty && !_distCoeffs.IsEmpty)
                {
                    ArucoInvoke.EstimatePoseSingleMarkers(corners, markersLength, _cameraMatrix, _distCoeffs, rvecs, tvecs);
                    for (int i = 0; i < ids.Size; i++)
                    {
                        using Mat rvecMat = rvecs.Row(i);
                        using Mat tvecMat = tvecs.Row(i);
                        using VectorOfDouble rvec = new();
                        using VectorOfDouble tvec = new();
                        double[] values = new double[3];
                        rvecMat.CopyTo(values);
                        rvec.Push(values);
                        tvecMat.CopyTo(values);
                        tvec.Push(values);
                        //ArucoInvoke.DrawAxis(frameCopy, _cameraMatrix, _distCoeffs, rvec, tvec, markersLength * 0.5f);
                    }
                }
            }
            return frameCopy;
        }

    }
}
