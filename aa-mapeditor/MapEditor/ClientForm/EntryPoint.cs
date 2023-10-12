/**************************************************************/
//
//
//      Copyright (c) 20XX UNLIMITED LOOP ROOT-ONE
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
//      Last update     : 2023/10/12
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace ClientForm
{
    internal static class EntryPoint
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
                Application.Run(new MainForm());
            }
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
