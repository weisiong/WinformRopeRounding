using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalVars.Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new FormRoiEditor());
            //Application.Run(new FormMain());
            //Application.Run(new FormColorSpacePicker());

        }

    }
}