using Serilog;
using Serilog.Sinks.WinForms.Base;
using Newtonsoft.Json;
using WinformRopeRounding.Models;

namespace WinformRopeRounding.Utilities
{
    
    public static class GlobalVars
    {
        // System Variables
        public const string SoftwareVersion = "RopeRounding ver.20230209_1330";

        public static string SettingPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public static string SNAPSHOT_SOURCE_FORMAT = "http://{0}:{1}@{2}/ISAPI/Streaming/channels/101/picture";
        
        public static string ConfigFileName = "Config.json";

        public static string ProductFileName = "Products.json";

        public static AppSetting AppSetting { get; set; } = new AppSetting();
        public static void Init()
        {
            DefaultAppSetting();
            ConfigureSerilog();

            var fullFileName = ConfigFileName; //System.IO.Path.Combine(SettingPath, "Config.json");
            if (File.Exists(fullFileName))
            {
                var jsonString = File.ReadAllText(fullFileName);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    AppSetting = JsonConvert.DeserializeObject<AppSetting>(jsonString);
                }
            }

            fullFileName = ProductFileName;
            if (File.Exists(fullFileName))
            {
                var jsonString = File.ReadAllText(fullFileName);
                if (AppSetting is not null && !string.IsNullOrEmpty(jsonString))
                {
                    AppSetting.Products = JsonConvert.DeserializeObject<List<Product>>(jsonString); // new Products(jsonString);
                }
            }
        }

        private static void DefaultAppSetting()
        {
            var cams = new Dictionary<string, Camera>
            {
                { "Cam1", new() { Enable = true, IPAddress = "192.168.125.64", Username = "admin", Password = "Heliotech", Position  =  "0.76324 0.28763 0.2", 
                  IntrinsicParas ="1 0 0 0 1 0 0 0 1", DistCoeffParas = "0.00 -0.00 0.00 0.00 -0.00 -0.00 0.00 0.00 0 0 0 0 0 0", MeasurementRatio=new(0,0,0,0)} },
                { "Cam2", new() { Enable = false, IPAddress = "192.168.125.66", Username = "admin", Password = "Heliotech", Position  =  "0.76324 0.28763 0.2",
                  IntrinsicParas ="1 0 0 0 1 0 0 0 1", DistCoeffParas = "0.00 -0.00 0.00 0.00 -0.00 -0.00 0.00 0.00 0 0 0 0 0 0" , MeasurementRatio=new(0,0,0,0)} }
            };

            var actions = new Dictionary<string, Action>
            {
                {"A", new() {  CameraId = "Cam1", Position = "0.827222 0.519778 0.4", BBox = new(200, 70, 860, 600) }},
                {"B", new() {  CameraId = "Cam2", Position = "0.76324 0.28763 0.2", BBox = new(300, 330, 115, 40) }},
            };

            var templates = new Dictionary<string, ProductTemplate>
            {
                {"Cam1", new () {
                    Name = "ProductModel1",
                    ProductCode = "Pro-01",
                    HoleROIs = new Dictionary<string, ROI>
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
                }},
                {"Cam2", new () {
                    Name = "ProductModel1",
                    ProductCode = "Pro-01",
                    HoleROIs = new Dictionary<string, ROI>
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
                }}
            };                      

            AppSetting = new()
            {
                TcpPort = 1888,
                Cams = cams,
                Actions = actions,
                Templates = templates
            };

            //Products products = new();
            var products = AppSetting.Products;
            products.Add(new Product() { Name = "1001A001", Catagory = "1001", ModelFiles = "A,B" });
            products.Add(new Product() { Name = "1001A002", Catagory = "1001", ModelFiles = "A,B" });
            products.Add(new Product() { Name = "1001A003", Catagory = "1001", ModelFiles = "A,B" });

            products.Add(new Product() { Name = "2001A001", Catagory = "2001", ModelFiles = "C,D" });
            products.Add(new Product() { Name = "2001A002", Catagory = "2001", ModelFiles = "C,D" });
            products.Add(new Product() { Name = "2001A003", Catagory = "2001", ModelFiles = "C,D" });

            products.Add(new Product() { Name = "3001A001", Catagory = "3001", ModelFiles = "E,F" });
            products.Add(new Product() { Name = "3001A002", Catagory = "3001", ModelFiles = "E,F" });
            products.Add(new Product() { Name = "3001A003", Catagory = "3001", ModelFiles = "E,F" });

            AppSetting.Products = products;

            //var json = products.ToJson();
            //File.WriteAllText(ProductFileName, json);
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
                        .WriteTo.File(
                            path: @"C:\Apps\Logger\log-.json",
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: "{Timestamp:yyyyMMdd HHmmss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();
        }

    }
}
