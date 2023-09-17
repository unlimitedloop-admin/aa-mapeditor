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
//      File name       : ChipLists.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/17
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.IO;
using MapEditor.src.main;



/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  Graphic chip list class.
    /// </summary>
    internal class ChipLists
    {
        /// <summary>
        ///  File IO class for graphic image datas.
        /// </summary>
        private readonly GraphicListFile? _graphicListFile = null;

        /// <summary>
        ///  The management instance class for the tile panel used for selecting graphic chips from the graphic chip list.
        /// </summary>
        private readonly ChipHolder _chipHolder;


        /// <summary>
        ///  This is the constructor for ChipLists.
        /// </summary>
        /// <param name="name">Graphic chip file name label</param>
        internal ChipLists(string name, ChipHolder chipHolder)
        {
            _graphicListFile = new(name);
            _chipHolder = chipHolder;
        }

        /// <summary>
        ///  Generates a graphic chip list and adds it to the specified panel.
        /// </summary>
        /// <param name="path">Graphic chip file source path</param>
        /// <param name="height">The vertical division count of the graphic chip</param>
        /// <param name="width">The Horizonal division count of the graphic chip</param>
        /// <param name="objects">A reference to the panel object for adding graphic chips</param>
        /// <returns>If successful, returns true.</returns>
        internal bool Create(string path, int height, int width, ref Panel objects)
        {
            if (null != _graphicListFile && _graphicListFile.FileOpen(path))
            {
                objects.Controls.Clear();
                TableLayoutPanel? table = _graphicListFile.GetGraphicChipList((uint)height, (uint)width);
                if (table != null)
                {
                    objects.Controls.Add(table);
                    objects.BackColor = SystemColors.ControlLight;
                    objects.AutoScroll = true;
                    _graphicListFile.GraphicChipClick += ChipLists_GraphicChipClick;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  Discard the graphics chip list.
        /// </summary>
        /// <param name="objects">A panel object to drop</param>
        internal void Drop(ref Panel objects)
        {
            if (null != _graphicListFile)
            {
                objects.Controls.Clear();
                _graphicListFile?.FileClose(_graphicListFile.FilePath);
            }
        }

        /// <summary>
        ///  Get the chiplist object loaded in memory.
        /// </summary>
        /// <returns>List generics.</returns>
        internal List<Image>? GetBackgroundImageList()
        {
            return _graphicListFile?.ImageList;
        }

        /// <summary>
        ///  Get the chiplist object loaded in memory.
        /// </summary>
        /// <param name="index">The index of the array element</param>
        /// <returns>Image object.</returns>
        internal Image? GetBackgroundImage(int index)
        {
            return _graphicListFile?.GetChipListImageAtIndex(index);
        }


        /// <summary>
        ///  Physical button click event handler for graphics chip list.
        /// </summary>
        /// <param name="sender">Image data set in <see cref="PictureBox"/></param>
        /// <param name="e">Unused event argument</param>
        /// <param name="tooltip_text">The text on the tooltip</param>
        private void ChipLists_GraphicChipClick(Button sender, EventArgs e, string tooltip_text)
        {
            Button button = sender!;
            List<MementoParameter> parameters = new()
            {
                new MementoParameter
                {
                    OldImageBinNum = !string.IsNullOrEmpty(_chipHolder.GetChipHolderNumberText()) ? byte.Parse(_chipHolder.GetChipHolderNumberText()!) : null,
                    NewImageBinNum = "" != tooltip_text ? byte.Parse(tooltip_text) : null,
                    Holder = true
                }
            };
            MainForm.Recollection(parameters);
            _chipHolder.SetSelectedChipTexture(tooltip_text, button.BackgroundImage);
        }
    }


    /// <summary>
    ///  A dedicated event handler for retrieving information about the graphic chip.
    /// </summary>
    /// <param name="sender">Button object</param>
    /// <param name="e">Event args</param>
    /// <param name="tooltip_text">The chip sequence number set in the tooltip</param>
    public delegate void GetChipHandler(Button sender, EventArgs e, string tooltip_text);
}
