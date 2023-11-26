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
//      Last update     : 2023/11/26
//
//      File version    : 7
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
        private static void Main()
        {
            IConfigurationRoot configrations = GetConfigurationRoot();
            if (CheckScreenResolution(configrations))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm(GetApplicationName(configrations)));
            }
        }

        /// <summary>
        ///  Get an instance holding raw values from environment config file.
        /// </summary>
        /// <returns><see cref="IConfigurationRoot"/> for "appsettings.json".</returns>
        private static IConfigurationRoot GetConfigurationRoot()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        /// <summary>
        ///  Get the application name from the config file.
        /// </summary>
        /// <returns>Screen title string.</returns>
        private static string GetApplicationName(IConfigurationRoot configuration)
        {
            string filePath = Assembly.GetEntryAssembly()!.Location;
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string buildVersion = fileVersionInfo.FileVersion ?? "unknown build";
            string version = fileVersionInfo.ProductVersion ?? "1.0";

            var fraction = configuration.GetSection("WindowName").Get<WindowName>();
            string text = string.Empty;
#if DEBUG
            text = null != fraction ? fraction.DebugRunApplicationName + " Build-No." + buildVersion : "Authentic Action Map Editor (developer limited)";
#else
            text = null != fraction ? fraction.ProductionApplicationName + " Ver. " + version : "Authentic Action Map Editor";
#endif
            return text;
        }

        /// <summary>
        ///  Check the resolution and verify that your application can run.
        /// </summary>
        /// <returns>False if resolution requirements are not met.</returns>
        private static bool CheckScreenResolution(IConfigurationRoot configuration)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fraction = configuration.GetSection("ApplicationWindowScale").Get<ApplicationWindowScale>();
            int minWidth = null != fraction ? fraction.ClientWindowWidth : 1;   // Minimum screen width required
            int minHeight = null != fraction ? fraction.ClientWindowHeight : 1; // Minimum screen height required

            // Get resolution.
            if (Screen.PrimaryScreen!.Bounds.Width < minWidth || Screen.PrimaryScreen!.Bounds.Height < minHeight)
            {
                MessageBox.Show("このアプリケーションは、最低" + minWidth + "x" + minHeight + "の解像度が必要です。", "解像度エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
