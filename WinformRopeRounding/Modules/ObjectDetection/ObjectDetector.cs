using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using Microsoft.ML;
using static Microsoft.ML.Transforms.Image.ImageResizingEstimator;

namespace WinformRopeRounding.Modules.ObjectDetection
{
    public class ObjectDetector
    {
        private const string modelPath = @"Assets\Weights\best.onnx";
        private static readonly string[] classesNames = new string[] { "Base", "Hole", "Head", "Body" };
        private readonly PredictionEngine<BitmapData, Prediction> predictionEngine;
        public ObjectDetector()
        {
            MLContext mlContext = new();
            var pipeline = mlContext.Transforms.ResizeImages(inputColumnName: "bitmap", outputColumnName: "images", imageWidth: 640, imageHeight: 640, resizing: ResizingKind.Fill)
                .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "images", scaleImage: 1f / 255f, interleavePixelColors: false))
                .Append(mlContext.Transforms.ApplyOnnxModel(
                    outputColumnNames: new[]
                    {
                        "output"
                    },
                    inputColumnNames: new[]
                    {
                        "images"
                    },
                    modelFile: modelPath,
                    shapeDictionary: new Dictionary<string, int[]>()
                    {
                        { "images", new[] { 1, 3, 640, 640 } },
                        { "output", new[] { 1, 25200, 9 } },
                    }, null, true));

            // Fit on empty list to obtain input data schema
            var model = pipeline.Fit(mlContext.Data.LoadFromEnumerable(new List<BitmapData>()));

            // Create prediction engine
            predictionEngine = mlContext.Model.CreatePredictionEngine<BitmapData, Prediction>(model);
        }

        public IEnumerable<Result> Inference(ref Mat MatSrc, bool DrawResult = false, float scoreThres = 0.5f, float iouThres = 0.1f)
        {
            List<Result> lstResult = new();
            // predict
            var bitmap = MatSrc.ToBitmap();
            var predict = predictionEngine.Predict(new BitmapData() { Image = bitmap });
            var results = predict.GetResults(classesNames, scoreThres, iouThres);

            using Graphics g = Graphics.FromImage(bitmap);
            foreach (var res in results)
            {
                if (res.Label.Equals("Head")) res.BBox = FinetuneHead(MatSrc, res);
                if (res.Label.Equals("Body")) continue;
                lstResult.Add(new Result(res.BBox, res.Label, res.Confidence));
                if (DrawResult)
                {
                    DrawPrediction(g, res);
                    MatSrc = bitmap.ToMat();
                }
            }
            return lstResult;
        }

        private static float[] FinetuneHead(Mat frame,Result result)
        {
            var points = result.BBox;

            //MCvScalar lowerLimit = new(79, 0, 91);
            //MCvScalar upperLimit = new(119, 255, 255);
            MCvScalar lowerLimit = new(0, 33, 0);
            MCvScalar upperLimit = new(73, 144, 255);

            var img_roi = frame.ToImage<Bgr, byte>();
            img_roi.ROI = result.Rect;

            Mat imgHSV = new();
            CvInvoke.CvtColor(img_roi, imgHSV, ColorConversion.Bgr2Hsv);
            CvInvoke.InRange(imgHSV, new ScalarArray(lowerLimit), new ScalarArray(upperLimit), img_roi);
            CvInvoke.BitwiseNot(img_roi, img_roi);

            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(img_roi, img_roi, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);
            CvInvoke.Dilate(img_roi, img_roi, kernel, new Point(-1, -1), 1, BorderType.Constant, new Bgr(Color.Black).MCvScalar);

            VectorOfPoint vop = new();
            using Mat hierachy = new();
            using VectorOfVectorOfPoint contours = new();
            // Build list of contours
            CvInvoke.FindContours(img_roi, contours, hierachy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            // Filter object by contour area
            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    VectorOfPoint contour = contours[i];
                    vop.Push(contour);
                }
            }

            if (vop.Length > 1)
            {
                var rect = CvInvoke.MinAreaRect(vop);
                var boundedRect = rect.MinAreaRect();
                boundedRect.Offset(img_roi.ROI.X, img_roi.ROI.Y);
                points[0] = boundedRect.Left;
                points[1] = boundedRect.Top;
                points[2] = boundedRect.Right;
                points[3] = boundedRect.Bottom;
            }
            return points;
        }

        private static void DrawPrediction(Graphics g, Result res)
        {
            var x1 = res.BBox[0]; var y1 = res.BBox[1];
            var x2 = res.BBox[2]; var y2 = res.BBox[3];
            
            g.DrawRectangle(Pens.Red, x1, y1, x1 - x2, y1 - y2);
            using (SolidBrush brushes = new(Color.FromArgb(50, Color.Red)))
            {
                g.FillRectangle(brushes, x1, y1, x2 - x1, y2 - y1);
            }
            g.DrawString(res.Label, new Font("Arial", 8), Brushes.White, new PointF(x1, y1));
            //g.DrawString(res.Label + " " + res.Confidence.ToString("0.00"), new Font("Arial", 8), Brushes.Wheat, new PointF(x1, y1));
        }



    }
}
