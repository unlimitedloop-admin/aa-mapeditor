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
//      Last update     : 2023/08/10
//
//      File version    : 4
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.models;
using MapEditor.src.dialog;



/* sources */
namespace MapEditor.src.app.applet
{
    /// <summary>
    ///  This is an object container providing core functionalities for the map editor.
    /// </summary>
    internal class MapContainer
    {
        /// <summary>
        ///  A management class for controlling objects placed in a GraphicChipPanel.
        /// </summary>
        private ChipLists? _chipLists;
        
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

        /// <summary>
        ///  Load the graphic chip list of the selected image file.
        /// </summary>
        /// <param name="instance"><seealso cref="Panel"/> to place the tip list</param>
        internal void LoadGraphicChipList(ref Panel instance)
        {
            using LoadGraphDialog openfile = new();
            if (openfile.ShowDialog() == DialogResult.OK && null != openfile.FileName)
            {
                DestroyGraphicChip(ref instance);
                _chipLists = new(Path.GetFileName(openfile.FileName));
                _chipLists.Create(openfile.FileName, openfile.GraphicHeight, openfile.GraphicWidth, ref instance);
            }
            openfile.Dispose();
        }

        /// <summary>
        ///  Delete the graphic chip list. 
        /// </summary>
        /// <param name="instance"><seealso cref="Panel"/> to place the chip list</param>
        internal void DestroyGraphicChip(ref Panel instance)
        {
            _chipLists?.Drop(ref instance);
        }
    }
}
