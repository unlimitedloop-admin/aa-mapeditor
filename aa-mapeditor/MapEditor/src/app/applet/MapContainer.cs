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
//      Last update     : 2023/09/30
//
//      File version    : 11
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
        ///  The management instance class for the tile panel used for selecting graphic chips from the graphic chip list.
        /// </summary>
        internal ChipHolder _chipHolder;


        internal MapContainer(ref Panel holdpanel)
        {
            _chipHolder = new(ref holdpanel);
        }

        /// <summary>
        ///  Load the map structure of the selected binary file.
        /// </summary>
        /// <param name="instance">A <see cref="Panel"/> that expands the loaded map data</param>
        internal void LoadMapFileFromHexText(ref Panel instance)
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                DestroyMapFile(ref instance);
                _mapStruct = new(Path.GetFileName(openbin.FileName), _chipHolder);
                if (!_mapStruct.Unzip(openbin.FileName, ref instance))
                {
                    _mapStruct = null;
                }
            }
            openbin.Dispose();
        }

        /// <summary>
        ///  Load the map structure of the selected binary file.
        /// </summary>
        /// <param name="instance">A <see cref="Panel"/> that expands the loaded map data</param>
        internal void LoadMapFileFromGraphic(ref Panel instance)
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
                    _mapStruct = new(Path.GetFileName(openbin.FileName), _chipHolder);
                    if (!_mapStruct.Unzip(openbin.FileName, imagelist, ref instance))
                    {
                        _mapStruct = null;
                    }
                }
            }
            openbin.Dispose();
        }

        /// <summary>
        ///  Changes the selection mode of the map field.
        /// </summary>
        /// <param name="transparent">Specified transparency of the block</param>
        internal void ChangeSelectModeForMapStruct(bool transparent)
        {
            _mapStruct?.ChangeTextureAlphaLvl(transparent);
        }

        /// <summary>
        ///  Destroy MapStruct instance.
        /// </summary>
        /// <param name="instance">A <see cref="Panel"/> that deletion map data</param>
        internal void DestroyMapFile(ref Panel instance)
        {
            if (null != _mapStruct)
            {
                _mapStruct.RemoveControlForAll();
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
                _chipLists = new(Path.GetFileName(openfile.FileName), _chipHolder);
                if (!_chipLists.Create(openfile.FileName, openfile.GraphicHeight, openfile.GraphicWidth, ref instance))
                {
                    _chipLists = null;
                }
            }
            openfile.Dispose();
        }

        /// <summary>
        ///  Destroy the ChipLists.
        /// </summary>
        /// <param name="instance"><seealso cref="Panel"/> to place the chip list</param>
        internal void DestroyGraphicChip(ref Panel instance)
        {
            if (null != _chipLists)
            {
                _chipLists.RemoveControlForAll(ref instance);
                instance.Controls.Clear();
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
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Retrieve the chip list image at the specified index number.
        /// </summary>
        /// <param name="index">Numerical value of the array index for <see cref="byte"/> type</param>
        /// <returns>Chip list <see cref="Image"/> object.</returns>
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

        /// <summary>
        ///  Indirectly invokes the process of filling chips into the selected area of the map field.
        /// </summary>
        /// <param name="reset">True if you want to clear the selected range.</param>
        internal void MapStruct_ReplaceRangeCell(bool reset)
        {
            // Recalling methods of the MapStruct.
            _mapStruct?.CallReplaceOnMapRangePanel(reset);
        }

        /// <summary>
        ///  Get the current map page value.
        /// </summary>
        /// <returns>MapPages member value.</returns>
        internal int GetMapPages()
        {
            return _mapStruct!.MapPages;
        }

        /// <summary>
        ///  Indirectly calls the SetPanelFromMapFieldPosition method of the MapStruct class.
        /// </summary>
        /// <param name="x">The x-coordinate of the target cell position</param>
        /// <param name="y">The y-coordinate of the target cell position</param>
        /// <param name="picturebox">The source <see cref="PictureBox"/> containing the data to be copied</param>
        /// <param name="transparent">A flag indicating if the image should be made semi-transparent</param>
        internal void SetPanelFromMapFieldPosition(int x, int y, PictureBox picturebox, bool transparent)
        {
            // Recalling methods of the MapStruct.
            _mapStruct?.SetPanelFromMapFieldPosition(x, y, picturebox, transparent);
        }
    }
}
