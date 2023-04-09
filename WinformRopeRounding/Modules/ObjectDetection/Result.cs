namespace WinformRopeRounding.Modules.ObjectDetection
{
    public class Result
    {
        /// <summary>
        /// x1, y1, x2, y2 in page coordinates.
        /// <para>left, top, right, bottom.</para>
        /// </summary>
        public int[] BBox { get; set; }

        /// <summary>
        /// The Bbox category.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Confidence level.
        /// </summary>
        public float Confidence { get; }

        public Result(int[] bbox, string label, float confidence)
        {
            BBox = bbox;
            Label = label;
            Confidence = confidence;
        }
        public int X1 => (int)BBox[0];
        public int Y1 => (int)BBox[1];
        public int X2 => (int)BBox[2];
        public int Y2 => (int)BBox[3];

        public int Width => (int)Math.Abs(BBox[2] - BBox[0]);
        public int Height => (int)Math.Abs(BBox[3] - BBox[1]);
        public Rectangle Rect => new(X1, Y1, Width, Height);
    }
}
