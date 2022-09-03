using Cyotek.Windows.Forms;


namespace WinformRopeRounding.Models
{
    public class NormRectangle : IShape
    {
        private Point lastClickedPoint;
        private Point lastMovedPoint;
        private readonly int maxPoint;

        private List<Point> points = new();
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        public NormRectangle()
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
            Pen pen = new(Color.Blue, 4);
            DrawRectangleShape(img, pen);
        }

        //immediate draw
        public void Draw(Image img, Color color)
        {
            Pen pen = new(color, 4);
            PerformDraw(img, pen);
        }

        private void DrawRectangleShape(Image img, Pen pen)
        {
            if (Points.Count > 1 && Points.Count == maxPoint)
            {
                PerformDraw(img, pen);
            }
        }

        private Rectangle lastDrawedRectange = Rectangle.Empty;
        private void PerformDraw(Image img, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                Point[] pts = Points.ToArray();
                SolidBrush b = new(Color.FromArgb(100, pen.Color));

                var pt1 = pts[^2];
                var pt2 = pts[^1];
                var left = Math.Min(pt1.X, pt2.X);
                var top = Math.Min(pt1.Y, pt2.Y);
                var width = Math.Abs(pt1.X - pt2.X);
                var height = Math.Abs(pt1.Y - pt2.Y);
                var rect = new Rectangle(new Point(left, top), new Size(width, height));

                if (lastDrawedRectange == Rectangle.Empty || !lastDrawedRectange.Equals(rect))
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
                    var height = Math.Abs(point.Y - lastMovedPoint.Y);
                    Rectangle newRect = new(new Point(left, top), new Size(width, height));
                    ControlPaint.DrawReversibleFrame(newRect, Color.Black, FrameStyle.Thick);
                }
                var startPoint = ctr.PointToScreen(currentLocation);
                if (!lastMovedPoint.IsEmpty)
                {
                    //Draw New Line
                    var left = Math.Min(point.X, lastMovedPoint.X);
                    var top = Math.Min(point.Y, lastMovedPoint.Y);
                    var width = Math.Abs(point.X - lastMovedPoint.X);
                    var height = Math.Abs(point.Y - lastMovedPoint.Y);
                    Rectangle newRect = new(new Point(left, top), new Size(width, height));
                    ControlPaint.DrawReversibleFrame(newRect, Color.Black, FrameStyle.Thick);
                }
                lastMovedPoint = startPoint;
            }
        }

    }
}
