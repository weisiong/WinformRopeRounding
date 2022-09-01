using Serilog;
using Serilog.Sinks.WinForms.Base;
using Newtonsoft.Json;

namespace WinformRopeRounding.Utilities
{
    
    public static class GlobalVars
    {
        // System Variables
        public const string SoftwareVersion = "RopeRounding ver.20220828_1330";

        public static string SettingPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);


        public static AppSetting AppSetting { get; set; } = new AppSetting();
        public static void Init()
        {
            DefaultAppSetting();
            ConfigureSerilog();

            var fullFileName = "Config.json"; //System.IO.Path.Combine(SettingPath, "Config.json");
            if (File.Exists(fullFileName))
            {
                var jsonString = File.ReadAllText(fullFileName);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    AppSetting = JsonConvert.DeserializeObject<AppSetting>(jsonString);
                }
            }
        }

        private static void DefaultAppSetting()
        {
            var cams = new Dictionary<string, Camera>
            {
                { "Cam1", new() { IPAddress = "192.168.1.64", Username = "admin", Password = "joseph12345" } },
                { "Cam2", new() { IPAddress = "192.168.1.64", Username = "admin", Password = "joseph12345" } }
            };

            var actions = new Dictionary<string, Action> //List<Action>
            {
                {"A", new() {  CameraName = "Cam1", PtzInfo =  new PTZInfo { Pan=1f, Tilt=1f, Zoom=0f }, BBox = new(120, 50, 80, 100) }},
                {"B", new() {  CameraName = "Cam2", PtzInfo =  new PTZInfo { Pan=0.76324f, Tilt=0.28763f, Zoom=0.2f}, BBox = new(120, 150, 180, 300) }},
                {"C", new() {  CameraName = "Cam3", PtzInfo =  new PTZInfo(), BBox = Rectangle.Empty }}
            };

            var template = new ProductTemplate
            {
                Name = "Product01",
                ProductCode = "Pro-01",
                HoleROIs = new Dictionary<string, ROI> // List<ROI>
                {
                    {"Base00", new() { BBOX = new Rectangle(253, 107, 55, 65) } },
                    {"Hole01", new() { BBOX = new Rectangle(322, 172, 95, 30) } },
                    {"Hole02", new() { BBOX = new Rectangle(322, 213, 95, 30) } },
                    {"Hole03", new() { BBOX = new Rectangle(322, 254, 95, 30) } },
                    {"Hole04", new() { BBOX = new Rectangle(253, 293, 55, 65) } },
                    {"Hole05", new() { BBOX = new Rectangle(253, 334, 55, 65) } },
                    {"Hole06", new() { BBOX = new Rectangle(253, 375, 55, 65) } },
                    {"Hole07", new() { BBOX = new Rectangle(253, 417, 55, 65) } },
                    {"Hole08", new() { BBOX = new Rectangle(253, 454, 55, 65) } },
                    {"Hole09", new() { BBOX = new Rectangle(253, 497, 55, 65) } },
                    {"Hole10", new() { BBOX = new Rectangle(253, 538, 55, 65) } },
                    {"Hole11", new() { BBOX = new Rectangle(253, 577, 55, 65) } },
                    {"Hole12", new() { BBOX = new Rectangle(253, 617, 55, 65) } }
                }
            };

            AppSetting = new()
            {
                TcpPort = 1888,
                Cams = cams,
                Actions = actions,
                Template = template
            };
        }

        private static void ConfigureSerilog()
        {
            var formatter = new Serilog.Formatting.Display.MessageTemplateTextFormatter
                ("[{Timestamp:HH:mm:ss}] {Message}{NewLine}{Exception}");
            Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteToSimpleAndRichTextBox(formatter)
                        //.WriteToGridView()
                        //.WriteToJsonTextBox()                        
                        .CreateLogger();
        }
    
    }
}
