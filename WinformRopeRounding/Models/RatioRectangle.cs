using Cyotek.Windows.Forms;


namespace WinformRopeRounding.Models
{
    public class RatioRectangle : IShape
    {
        private Point lastClickedPoint;
        private Point lastMovedPoint;
        private int maxPoint;
        private static readonly float HDratio = 0.5625f; //Height 16:9 ratio
        private List<Point> points = new List<Point>();
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        public RatioRectangle()
        {
            maxPoint = 2;
        }

        public void Reset()
        {
            lastClickedPoint = new Point();
            lastMovedPoint = new Point();
            Points.Clear();
        }

        public void AddNewImagePoint(ImageBox imgBox, Point e)
        {
            if (!imgBox.IsPointInImage(e)) return;
            var point = imgBox.PointToImage(e);
            Points.Add(point);
            lastClickedPoint = e;
        }

        //editing draw
        public void Draw(Image img)
        {
            Pen pen = new Pen(Color.Blue, 4);
            DrawRectangleShape(img, pen);
        }

        //immediate draw
        public void Draw(Image img, Color color)
        {
            Pen pen = new Pen(color, 4);
            PerformDraw(img, pen);
        }

        private void DrawRectangleShape(Image img, Pen pen)
        {
            if (Points.Count > 1 && Points.Count == maxPoint)
            {
                PerformDraw(img, pen, true);
            }
        }

        private Rectangle lastDrawedRectange;
        private void PerformDraw(Image img, Pen pen, bool lastDraw = false)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                Point[] pts = Points.ToArray();
                SolidBrush b = new SolidBrush(Color.FromArgb(100, pen.Color));

                var pt1 = pts[pts.Length - 2];
                var pt2 = pts[pts.Length - 1];
                var left = Math.Min(pt1.X, pt2.X);
                var top = Math.Min(pt1.Y, pt2.Y);
                var width = Math.Abs(pt1.X - pt2.X);
                var height = Convert.ToInt16(width * HDratio);
                var rect = new Rectangle(new Point(left, top), new Size(width, height));

                //check if draw complete then calculate pt1.Y based on pt2.Y
                if (lastDraw)
                {
                    var bottom = Math.Max(pt1.Y, pt2.Y);
                    var calculatedTop = bottom - height;
                    rect = new Rectangle(new Point(left, calculatedTop), new Size(width, height));
                    pt1.Y = calculatedTop;

                    //update new point pt1
                    Points.RemoveAt(0);
                    Points.Insert(0, pt1);
                }

                if (lastDrawedRectange == null || !lastDrawedRectange.Equals(rect))
                {
                    g.DrawRectangle(pen, rect);
                    g.FillRectangle(b, rect);
                    lastDrawedRectange = rect;
                }
            }
        }

        public void DrawRubberLine(Control ctr, Point currentLocation)
        {
            var lastPoint = lastClickedPoint;
            if (!lastPoint.IsEmpty)
            {
                if (Points.Count > maxPoint - 1)
                    return;

                var point = ctr.PointToScreen(lastPoint);
                if (!lastMovedPoint.IsEmpty)
                {
                    //Erase Previous Line
                    var left = Math.Min(point.X, lastMovedPoint.X);
                    var top = Math.Min(point.Y, lastMovedPoint.Y);
                    var width = Math.Abs(point.X - lastMovedPoint.X);
                    var height = Convert.ToInt16(width * HDratio); //var height = Math.Abs(point.Y - lastMovedPoint.Y);
                    var newRect = new Rectangle(new Point(left, top), new Size(width, height));
                    ControlPaint.DrawReversibleFrame(newRect, Color.LightGreen, FrameStyle.Thick);
                }
                var startPoint = ctr.PointToScreen(currentLocation);
                if (!lastMovedPoint.IsEmpty)
                {
                    //Draw New Line
                    var left = Math.Min(point.X, lastMovedPoint.X);
                    var top = Math.Min(point.Y, lastMovedPoint.Y);
                    var width = Math.Abs(point.X - lastMovedPoint.X);
                    var height = Convert.ToInt16(width * HDratio); // Math.Abs(point.Y - lastMovedPoint.Y);
                    var newRect = new Rectangle(new Point(left, top), new Size(width, height));
                    ControlPaint.DrawReversibleFrame(newRect, Color.LightGreen, FrameStyle.Thick);
                }
                lastMovedPoint = startPoint;
            }
        }

    }
}
