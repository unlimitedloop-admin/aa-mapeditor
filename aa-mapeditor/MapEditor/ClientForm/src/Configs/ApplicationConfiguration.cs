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
//      File name       : ApplicationConfiguration.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/22
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Configs
{
    /// <summary>
    ///  Application name property.
    /// </summary>
    public class WindowName
    {
        public string DebugRunApplicationName { get; set; } = string.Empty;
        public string ProductionApplicationName { get; set; } = string.Empty;
    }



    /// <summary>
    ///  Application window scale information.
    /// </summary>
    public class ApplicationWindowScale
    {
        public int ClientWindowWidth { get; set; }
        public int ClientWindowHeight { get; set; }
    }
}
