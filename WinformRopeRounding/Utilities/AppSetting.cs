using WinformRopeRounding.Models;

namespace WinformRopeRounding.Utilities
{
    public class AppSetting
    {
        public int TcpPort { get; set; }
        public Dictionary<string,Camera> Cams { get; set; }
        public Dictionary<string,Action> Actions { get; set; }
        public Dictionary<string, ProductTemplate>  Templates { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
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
        public bool Enable { get; set; }
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string IntrinsicParas { get; set; }
        public string DistCoeffParas { get; set; }
        public Rectangle MeasurementRatio { get; set; } //"10mm:320pix"
    }

    public class Action
    {
        public string CameraId { get; set; }
        public string Position { get; set; }
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
