namespace WinformRopeRounding.Utilities
{
    public class AppSetting
    {
        public int TcpPort { get; set; }
        public List<Camera> Cams { get; set; }
        public List<Action> Actions { get; set; }
        public ProductTemplate Template { get; set; }
    }

    public class ProductTemplate
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public Rectangle BaseRefROI { get; set; }
        public List<Rectangle> HoleROIs { get; set; }
    }

    public class Camera
    {
        public string CamId { get; set; }
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Action
    {
        public string ActId { get; set; }
        public string CamId { get; set; }
        public string LocInfo { get; set; }
        public Rectangle BBox { get; set; }
    }

    public class LocInfo
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

}
