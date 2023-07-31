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
//      File name       : WinEntry.cs
//
//      Author          : u7
//
//      Last update     : 2023/07/31
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Program entry point containing the main function.
    /// </summary>
    internal static class WinEntry
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}