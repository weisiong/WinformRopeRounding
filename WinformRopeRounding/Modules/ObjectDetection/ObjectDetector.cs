using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using Microsoft.ML;
using static Microsoft.ML.Transforms.Image.ImageResizingEstimator;
using Yolov8Net;

namespace WinformRopeRounding.Modules.ObjectDetection
{
    public class ObjectDetector
    {
        private readonly IPredictor yolo;
        private const string MODEL_PATH = @"Assets\Weights\{0}.onnx";
        private static readonly string[] classesNames = new string[] { "Base", "Hole", "Head", "Body" };
        public ObjectDetector(string modelfile)
        {
            var ModelFilePath = string.Format(MODEL_PATH, modelfile);
            yolo = yolo = YoloV8Predictor.Create(ModelFilePath, classesNames, false);
        }

        public IEnumerable<Result> Inference(ref Mat MatSrc, bool DrawResult = false, float scoreThres = 0.5f, float iouThres = 0.1f)
        {
            List<Result> lstResult = new();
            // predict
            var bitmap = MatSrc.ToBitmap();
            var predictions = yolo.Predict(bitmap);

            using Graphics g = Graphics.FromImage(bitmap);
            foreach (var res in predictions)
            {
                //if (res.Label.Equals("Head")) res.BBox = FinetuneHead(MatSrc, res);
                if (res.Label.Equals("Body")) continue;
                var bboxf = Rectangle.Round(res.Rectangle);
                var bbox = new int[] { bboxf.X, bboxf.Y, bboxf.X + bboxf.Width, bboxf.Y + bboxf.Height };
                lstResult.Add(new Result(bbox, res.Label.Name, res.Score));
                if (DrawResult)
                {
                    DrawPrediction(bitmap, res);
                    MatSrc = bitmap.ToMat();
                }
            }

            return lstResult;
        }

        private static void DrawPrediction(Image image, Yolov8Net.Prediction pred)
        {
            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;

            var x = Math.Max(pred.Rectangle.X, 0);
            var y = Math.Max(pred.Rectangle.Y, 0);
            var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
            var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

            // Bounding Box Text
            string text = $"{pred.Label.Name} [{Math.Round(pred.Score * 100)}]";
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawRectangle(Pens.Red, x, y, width, height);
                using (SolidBrush brushes = new(Color.FromArgb(50, Color.Red)))
                {
                    graphics.FillRectangle(brushes, x, y, width, height);
                }
                graphics.DrawString(text, new Font("Arial", 8), Brushes.White, new PointF(x, y));
            }
        }

        //private static float[] FinetuneHead(Mat frame,Result result)
        //{
        //    var points = result.BBox;

        //    //MCvScalar lowerLimit = new(79, 0, 91);
        //    //MCvScalar upperLimit = new(119, 255, 255);
        //    MCvScalar lowerLimit = new(0, 33, 0);
        //    MCvScalar upperLimit = new(73, 144, 255);

        //    var img_roi = frame.ToImage<Bgr, byte>();
        //    img_roi.ROI = result.Rect;

        //    Mat imgHSV = new();
        //    CvInvoke.CvtColor(img_roi, imgHSV, ColorConversion.Bgr2Hsv);
        //    CvInvoke.InRange(imgHSV, new ScalarArray(lowerLimit), new ScalarArray(upperLimit), img_roi);
        //    CvInvoke.BitwiseNot(img_roi, img_roi);

        //    Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
        //    CvInvoke.Erode(img_roi, img_roi, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);
        //    CvInvoke.Dilate(img_roi, img_roi, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);

        //    VectorOfPoint vop = new();
        //    using Mat hierachy = new();
        //    using VectorOfVectorOfPoint contours = new();
        //    // Build list of contours
        //    CvInvoke.FindContours(img_roi, contours, hierachy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
        //    // Filter object by contour area
        //    if (contours.Size > 0)
        //    {
        //        for (int i = 0; i < contours.Size; i++)
        //        {
        //            VectorOfPoint contour = contours[i];
        //            vop.Push(contour);
        //        }
        //    }

        //    if (vop.Length > 1)
        //    {
        //        var rect = CvInvoke.MinAreaRect(vop);
        //        var boundedRect = rect.MinAreaRect();
        //        boundedRect.Offset(img_roi.ROI.X, img_roi.ROI.Y);
        //        points[0] = boundedRect.Left;
        //        points[1] = boundedRect.Top;
        //        points[2] = boundedRect.Right;
        //        points[3] = boundedRect.Bottom;
        //    }
        //    return points;
        //}

    }
}
