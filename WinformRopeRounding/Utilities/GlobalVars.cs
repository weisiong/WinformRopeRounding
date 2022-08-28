﻿using Serilog;
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
            ConfigureSerilog();

            var cams = new List<Camera>
            {
                new() { CamId = "Cam1", IPAddress = "192.168.1.64", Username = "admin", Password = "joseph12345" },
                new() { CamId = "Cam2", IPAddress = "192.168.1.64", Username = "admin", Password = "joseph12345" }
            };

            var actions = new List<Action>
            {
                new() { ActId = "A", CamId = "Cam1", PtzInfo =  new PTZInfo { Pan=1f, Tilt=1f, Zoom=0f }, BBox = new(120, 50, 80, 100) },
                new() { ActId = "B", CamId = "Cam1", PtzInfo = new PTZInfo { Pan=0.76324f, Tilt=0.28763f, Zoom=0.2f } , BBox = new(120, 150, 180, 300) },
                new() { ActId = "C", CamId = string.Empty, PtzInfo = new PTZInfo(), BBox = Rectangle.Empty }
            };

            var template = new ProductTemplate
            {
                Name = "Product01",
                ProductCode = "Pro-01",
                BaseROI = new ROI() { Name = "Base", BBOX = new(253, 107, 55, 65) },
                HoleROIs = new List<ROI>
                {                
                    new ROI{ Name="Hole01", BBOX = new Rectangle(322, 172, 95, 30) },
                    new ROI{ Name="Hole02", BBOX = new Rectangle(322, 213, 95, 30) },
                    new ROI{ Name="Hole03", BBOX =new Rectangle(322, 254, 95, 30) },
                    new ROI{ Name="Hole04", BBOX =new Rectangle(322, 293, 95, 30) },
                    new ROI{ Name="Hole05", BBOX =new Rectangle(322, 334, 95, 30) },
                    new ROI{ Name="Hole06", BBOX =new Rectangle(322, 375, 95, 30) },
                    new ROI{ Name="Hole07", BBOX =new Rectangle(322, 417, 95, 30) },
                    new ROI{ Name="Hole08", BBOX =new Rectangle(322, 454, 95, 30) },
                    new ROI{ Name="Hole09", BBOX =new Rectangle(322, 497, 95, 30) },
                    new ROI{ Name="Hole10", BBOX =new Rectangle(322, 538, 95, 30) },
                    new ROI{ Name="Hole11", BBOX =new Rectangle(322, 577, 95, 30) },
                    new ROI{ Name="Hole12", BBOX =new Rectangle(322, 617, 95, 30) }
                }
            };

            AppSetting = new()
            {
                TcpPort = 1888,
                Cams = cams,
                Actions = actions,
                Template = template
            };

            var json = JsonConvert.SerializeObject(AppSetting, Formatting.Indented);
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
