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
//      File name       : FileCommands.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/10
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.applet;



/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  A collection of event handlers for file menu commands.
    /// </summary>
    internal class FileCommands
    {
        /// <summary>
        ///  MapContainer class reference.
        /// </summary>
        private readonly MapContainer? _mapContainer;


        /// <summary>
        ///  This is the constructor for FileCommands.
        /// </summary>
        /// <param name="container">Main container instance</param>
        internal FileCommands(ref MapContainer container)
        {
            _mapContainer = container;
        }

        /// <summary>
        ///  Open the binary file and expand it to the panel.
        /// </summary>
        /// <param name="panel">An object responsible for deploying other objects</param>
        internal void OpenBinaryMapFile(ref TableLayoutPanel panel)
        {
            _mapContainer?.LoadMapFileFromHexText(ref panel);
        }

        /// <summary>
        ///  Close the binary file.
        /// </summary>
        /// <param name="panel">The target object to demolish</param>
        internal void CloseBinaryMapFile(ref TableLayoutPanel panel)
        {
            _mapContainer?.DestroyMapFile(ref panel);
        }

        /// <summary>
        ///  Open the graphic chip file and expand it to the panel.
        /// </summary>
        /// <param name="panel">Object to deploy</param>
        internal void OpenGraphicChipFile(ref Panel panel)
        {
            _mapContainer?.LoadGraphicChipList(ref panel);
        }

        /// <summary>
        ///  Close the graphic chip list.
        /// </summary>
        /// <param name="panel">Object to destroy</param>
        internal void CloseGraphicChipFile(ref Panel panel)
        {
            _mapContainer?.DestroyGraphicChip(ref panel);
        }

        /// <summary>
        ///  Quit the whole application.
        /// </summary>
        internal static void ExitApplication()
        {
            Application.Exit();
        }
    }
}
