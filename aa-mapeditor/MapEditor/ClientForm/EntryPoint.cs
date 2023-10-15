/**************************************************************/
//
//
//      Copyright (c) 2023 UNLIMITED LOOP ROOT-ONE
//
//
//      This software(and source code) is completely Unlicense.
//      see "LICENSE".
//
//
/**************************************************************/
//
//
//      Arthentic Action Map Editor (Csharp Edition)
//
//      File name       : EntryPoint.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/15
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Configs;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection;



/* sources */
namespace ClientForm
{
    internal class EntryPoint
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (CheckScreenResolution())
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm(GetApplicationName()));
            }
        }

        private static string GetApplicationName()
        {
            string filePath = Assembly.GetEntryAssembly()!.Location;
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string fileVersion = fileVersionInfo.FileVersion ?? "unknown build";
            string version = fileVersionInfo.ProductVersion ?? "1.0";
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var fraction = configuration.GetSection("WindowName").Get<WindowName>();
            string text = string.Empty;
#if DEBUG
            text = null != fraction ? fraction.DebugRunApplicationName + " Build-No." + fileVersion : "aa-mapeditor (developer limited) : unknown build";
#else
            text = null != fraction ? fraction.ProductionApplicationName + " Ver. " + version : "aa-mapeditor";
#endif
            return text;
        }


        /// <summary>
        ///  Check the resolution and verify that your application can run.
        /// </summary>
        /// <returns>False if resolution requirements are not met.</returns>
        private static bool CheckScreenResolution()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Get resolution. 
            int minWidth = 1190;  // Minimum screen width required
            int minHeight = 824;  // Minimum screen height required

            if (Screen.PrimaryScreen!.Bounds.Width < minWidth || Screen.PrimaryScreen!.Bounds.Height < minHeight)
            {
                MessageBox.Show("このアプリケーションは、最低" + minWidth + "x" + minHeight + "の解像度が必要です。", "解像度エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
