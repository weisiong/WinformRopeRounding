namespace WinformRopeRounding.Utilities
{
    public class AppSetting
    {
        public int TcpPort { get; set; }
        public Dictionary<string,Camera> Cams { get; set; }
        public Dictionary<string,Action> Actions { get; set; }
        public ProductTemplate Template { get; set; }
    }

    public class ProductTemplate
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public Dictionary<string, ROI> HoleROIs { get; set; }
    }

    public class ROI
    {
        public Rectangle BBOX { get; set; }
    }

    public class Camera
    {
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public PTZInfo PtzInfo { get; set; }
    }

    public class Action
    {
        public string CameraName { get; set; }
        public PTZInfo PtzInfo { get; set; }
        public Rectangle BBox { get; set; }
    }

    public class PTZInfo
    {
        public float Pan { get; set; }
        public float Tilt { get; set; }
        public float Zoom { get; set; }

        //pan tilt zoom
        public override string ToString()
        {
            return "{" + $"Pan={Pan}, Tilt={Tilt}, Zoom={Zoom}" + "}";
            //return $"{Pan}, {Tilt}, {Zoom}";
        }

    }

}
