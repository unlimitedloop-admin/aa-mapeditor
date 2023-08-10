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
//      Last update     : 2023/08/10
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
using MapEditor.src.app.IO;
using System.Drawing;

namespace MapEditor.src.app.models
{
    /// <summary>
    ///  Graphic chip list class.
    /// </summary>
    internal class ChipLists
    {
        /// <summary>
        ///  Graphics chip list class.
        /// </summary>
        private GraphicListFile? _graphicListFile = null;


        /// <summary>
        ///  This is the constructor for ChipLists.
        /// </summary>
        /// <param name="name">Graphic chip file name label</param>
        internal ChipLists(string name)
        {
            _graphicListFile = new(name);
        }

        /// <summary>
        ///  Generates a graphic chip list and adds it to the specified panel.
        /// </summary>
        /// <param name="path">Graphic chip file source path</param>
        /// <param name="height">The vertical division count of the graphic chip</param>
        /// <param name="width">The Horizonal division count of the graphic chip</param>
        /// <param name="objects">A reference to the panel object for adding graphic chips</param>
        /// <returns>If successful, returns true</returns>
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
    }
}