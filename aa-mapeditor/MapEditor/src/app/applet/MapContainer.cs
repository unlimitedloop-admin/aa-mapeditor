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
//      Last update     : 2023/09/10
//
//      File version    : 9
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.models;
using MapEditor.src.common;
using MapEditor.src.dialog;
using MapEditor.src.main;



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
        /// <param name="eventargs">Summary of event listeners for adding mouse events to the map</param>
        internal void LoadMapFileFromHexText(ref TableLayoutPanel instance, CustomMapStructEventArgs eventargs)
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                DestroyMapFile(ref instance);
                _mapStruct = new(Path.GetFileName(openbin.FileName));
                if (!_mapStruct.Unzip(openbin.FileName, ref instance, eventargs))
                {
                    _mapStruct = null;
                }
            }
            openbin.Dispose();
        }

        /// <summary>
        ///  Load the map structure of the selected binary file.
        /// </summary>
        /// <param name="instance">A <see cref="TableLayoutPanel"/> that expands the loaded map data</param>
        /// <param name="eventargs">Summary of event listeners for adding mouse events to the map</param>
        internal void LoadMapFileFromGraphic(ref TableLayoutPanel instance, CustomMapStructEventArgs eventargs)
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK && null != _chipLists)
            {
                DestroyMapFile(ref instance);
                List<Image>? imagelist = _chipLists.GetBackgroundImageList();
                if (null != imagelist)
                {
                    _mapStruct = new(Path.GetFileName(openbin.FileName));
                    if (!_mapStruct.Unzip(openbin.FileName, imagelist, ref instance, eventargs))
                    {
                        _mapStruct = null;
                    }
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
        /// <param name="events">Event listener invoked for retrieving the graphic chip</param>
        internal void LoadGraphicChipList(ref Panel instance, GetChipHandler events)
        {
            using LoadGraphDialog openfile = new();
            if (openfile.ShowDialog() == DialogResult.OK && null != openfile.FileName)
            {
                DestroyGraphicChip(ref instance);
                _chipLists = new(Path.GetFileName(openfile.FileName));
                if (_chipLists.Create(openfile.FileName, openfile.GraphicHeight, openfile.GraphicWidth, ref instance) && null != _chipLists._graphicListFile)
                {
                    _chipLists._graphicListFile.GraphicChipClick += events;
                }
                else
                {
                    _chipLists = null;
                }
            }
            openfile.Dispose();
        }

        /// <summary>
        ///  Delete the graphic chip list.
        /// </summary>
        /// <param name="instance"><seealso cref="Panel"/> to place the chip list</param>
        internal void DestroyGraphicChip(ref Panel instance)
        {
            if (null != _chipLists)
            {
                _chipLists.Drop(ref instance);
                _chipLists = null;
            }
        }

        /// <summary>
        ///  The presence or absence of the _chipLists instance.
        /// </summary>
        /// <returns>If the ChipLists instance exists, true.</returns>
        internal bool IsChipLists()
        {
            if (null != _chipLists)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Retrieve the chip list image at the specified index number.
        /// </summary>
        /// <param name="index">Numerical value of the array index</param>
        /// <returns>Chip list image object.</returns>
        internal Image? GetChipListImage(int index)
        {
            return _chipLists?.GetBackgroundImage(index);
        }

        /// <summary>
        ///  Retrieve the chip list image at the specified index number.
        /// </summary>
        /// <param name="index">Numerical value of the array index for byte type</param>
        /// <returns>Chip list image object.</returns>
        internal Image? GetChipListImage(byte? index)
        {
            if (index.HasValue && IsChipLists())
            {
                return _chipLists?.GetBackgroundImage(index.Value);
            }
            else
            {
                return null;
            }
        }
    }
}
