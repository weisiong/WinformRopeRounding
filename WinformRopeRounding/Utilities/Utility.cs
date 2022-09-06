using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace EmguCVDemo
{
    public static class Utility
    {
        public  static void DrawRotatedRect(IInputOutputArray src, RotatedRect rect, MCvScalar color, int thickness = 1)
        {
            var rect_pts = CvInvoke.BoxPoints(rect);
            for (int ipt = 0; ipt < 4; ipt++)
            {
                //Cv2.Line(src, (Point)rect_pts[ipt], (Point)rect_pts[(ipt + 1) % 4], color, thickness);
                var X1 = Convert.ToInt16(rect_pts[ipt].X);
                var Y1 = Convert.ToInt16(rect_pts[ipt].Y);
                var X2 = Convert.ToInt16(rect_pts[(ipt + 1) % 4].X);
                var Y2 = Convert.ToInt16(rect_pts[(ipt + 1) % 4].Y);
                CvInvoke.Line(src, new Point { X = X1, Y = Y1 }, new Point { X = X2, Y = Y2 }, color, thickness + ipt);
                Console.WriteLine($"{ipt + 1}. Pt1:({X1},{Y1}), Pt2:({X2},{Y2})");
            }
        }

        public static void ImageShow(Mat refMat, string fileNameOnly, int winW = 800, int winH = 600, int locX = 200, int locY = 200)
        {
            CvInvoke.NamedWindow(fileNameOnly, WindowFlags.Normal);
            //CvInvoke.ResizeForFrame(refMat,refMat,new Size(winW, winH));
            //CvInvoke.MoveWindow(fileNameOnly, locX, locY);
            CvInvoke.Imshow(fileNameOnly, refMat);
            CvInvoke.WaitKey(1);
            //CvInvoke.DestroyAllWindows();
        }


        public static double IOU(Rectangle bbox1, Rectangle bbox2)
        {
            var area1 = bbox1.Width * bbox1.Height;
            var area2 = bbox2.Width * bbox2.Height;

            //Now we need to find the intersection box
            //to do that, find the largest (x, y) coordinates
            //for the start of the intersection bounding box and
            //the smallest (x, y) coordinates for the end of
            //the intersection bounding box
            var xx1 = Math.Max(bbox1.X, bbox2.X);
            var yy1 = Math.Max(bbox1.Y, bbox2.Y);
            var xx2 = Math.Min(bbox1.Right, bbox2.Right);
            var yy2 = Math.Min(bbox1.Bottom, bbox2.Bottom);

            //So the intersection BBox has the coordinates (xx,yy) (aa,bb)
            //compute the width and height of the intersection bounding box
            var w = Math.Max(0, xx2 - xx1);
            var h = Math.Max(0, yy2 - yy1);

            //find the intersection area
            var intersect_area = w * h;

            //find the union area of both the boxes
            var union_area = area1 + area2 - intersect_area;

            //compute the ratio of overlap between the computed
            //bounding box and the bounding box in the area list
            var IoU = Convert.ToDouble(intersect_area) / Convert.ToDouble(union_area);
            return IoU;
        }


    }
}
