using Cyotek.Windows.Forms;
using System.Diagnostics;
using WinformRopeRounding.Models;

namespace WinformRopeRounding.UserControls
{
    public class PtzPictureBoxEx : ImageBox
    {
        private Image imgOrg;
        public void SetImage(Image image)
        {
            imgOrg = (Image)image.Clone(); 
            base.Image = image;
        }
        ~PtzPictureBoxEx()
        {
            if (imgOrg != null) imgOrg.Dispose();
        }

        private IShape polyShape = null;

        private int _drawMode = 0;
        public int DrawMode
        {
            get { return _drawMode; }
            set
            {
                _drawMode = value;
                if (_drawMode == 1) polyShape = new NormRectangle();
                if (_drawMode == 2) polyShape = new RatioRectangle();
            }
        }

        private bool _enabledEditMode = false;
        public bool EnabledEditMode
        {
            get
            {
                return _enabledEditMode;
            }
            set
            {
                _enabledEditMode = value;
            }
        }

        public PtzPictureBoxEx() => base.Dock = DockStyle.Fill;

        private void PolyShape_OnShapeComplete(object sender, System.EventArgs e)
        {
            if (!EnabledEditMode) return;
            Debug.Print("OnShpComplete");
            EnabledEditMode = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!EnabledEditMode) return;
            polyShape.AddNewImagePoint(this, e.Location);
            if (polyShape != null) polyShape.Draw(base.Image);
            Invalidate();
        }

        int lastX = 0; int lastY = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            lastX = e.X; lastY = e.Y;
            this.Invalidate();

            if (!EnabledEditMode) return;

            polyShape.DrawRubberLine(this, e.Location);
            var newPt = PointToImage(e.Location);
            var m = new MouseEventArgs(e.Button, e.Clicks, newPt.X, newPt.Y, e.Delta);
            base.OnMouseMove(m);
        }

        public void ResetSelectedRegion()
        {
            if (polyShape != null) polyShape.Reset();
            base.Image = (Image)imgOrg.Clone();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //if (polyShape != null) polyShape.Draw(base.Image);

            //Draw Cross Line
            Pen myPen = new Pen(Color.Gray, 2.0F);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            e.Graphics.DrawLine(myPen, 0, lastY, this.Width, lastY);
            e.Graphics.DrawLine(myPen, lastX, 0, lastX, this.Height);
        }

        public void DrawShape(Rectangle Roi, Color color)
        {
            DrawShape(new List<Point>()
            {
                new Point(Roi.X,Roi.Y),
                new Point(Roi.X + Roi.Width, Roi.Y + Roi.Height)
            }, color);
        }

        public void DrawShape(List<Point> points, Color color)
        {
            polyShape.Points = points;
            polyShape.Draw(base.Image, color);
            Invalidate();
        }

        public Rectangle SaveNewROI()
        {
            var newPts = polyShape.Points;
            var roi = new Rectangle
            {
                X = Math.Min(newPts[0].X, newPts[1].X),
                Y = Math.Min(newPts[0].Y, newPts[1].Y),
                Width = Math.Abs(newPts[1].X - newPts[0].X),
                Height = Math.Abs(newPts[1].Y - newPts[0].Y)
            };
            return roi;
        }

    }
}
