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
//      File name       : MapContainer.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/06
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.models;



/* sources */
namespace MapEditor.src.app.applet
{
    /// <summary>
    ///  This is an object container providing core functionalities for the map editor.
    /// </summary>
    internal class MapContainer
    {
        /// <summary>
        ///  A management class for controlling objects placed in a MapStructPanel.
        /// </summary>
        private MapStructs? _mapStruct;


        /// <summary>
        ///  Load the map structure of the selected binary file.
        /// </summary>
        /// <param name="instance">A <see cref="TableLayoutPanel"/> that expands the loaded map data</param>
        internal void LoadMapFileFromHexText(ref TableLayoutPanel instance)
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                DestroyMapFile(ref instance);
                _mapStruct = new(Path.GetFullPath(openbin.FileName));
                if (!_mapStruct.Unzip(openbin.FileName, ref instance))
                {
                    _mapStruct = null;
                }
            }
            openbin.Dispose();
        }

        /// <summary>
        ///  Destroy loaded map data.
        /// </summary>
        /// <param name="instance">A <see cref="TableLayoutPanel"/> that deletion map data</param>
        internal void DestroyMapFile(ref TableLayoutPanel instance)
        {
            if (null != _mapStruct)
            {
                instance.Controls.Clear();
                _mapStruct = null;
            }
        }
    }
}
