namespace WinformRopeRounding.Models
{
    public class Movement
    {
        public int SeqId { get; set; }
        public string LocInfo { get; set; } //= new List<string>();
        public Rectangle MotionROI { get; set; }
        public List<LotROIs> LotROIs { get; set; } = new List<LotROIs>();
    }

    public class LotROIs
    {
        public string SeqId { get; set; }
        public Rectangle Lot { get; set; }
        public Rectangle Plate { get; set; }
        public List<Point> EmptyEdge { get; set; } = new List<Point>();
        public List<Point> EmptyZone { get; set; } = new List<Point>();
        public string Plate_Output_Empty_Path { get; set; }
        public string Plate_Emptylot_Path { get; set; }
    }

}
