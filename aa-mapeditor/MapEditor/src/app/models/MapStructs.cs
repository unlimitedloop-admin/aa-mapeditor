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
//      File name       : MapStructs.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/17
//
//      File version    : 5
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.IO;
using MapEditor.src.common;



/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  The algorithm class for constructing map data.
    /// </summary>
    internal class MapStructs
    {
        /// <summary>
        ///  Binary map file manager class.
        /// </summary>
        private BinMapFile? _binMapFile;

        /// <summary>
        ///  The map field table object.
        /// </summary>
        private TableLayoutPanel? _mapTable;

        /// <summary>
        ///  The management instance class for the tile panel used for selecting graphic chips from the graphic chip list.
        /// </summary>
        private readonly ChipHolder _chipHolder;

        // The coordinates held to determine the selected area of the map field.
        private Point _mouseDownPoint;
        //private Point _mouseUpPoint;


        /// <summary>
        ///  This is the constructor for MapStructs.
        /// </summary>
        /// <param name="name">Binary file name label.</param>
        internal MapStructs(string name, ChipHolder chipHolder)
        {
            _binMapFile = new(name);
            _chipHolder = chipHolder;
        }

        /// <summary>
        ///  This is the destructor.
        /// </summary>
        ~MapStructs()
        {
            if (null != _binMapFile)
            {
                _binMapFile.FileClose(_binMapFile.Name);
                _binMapFile = null;
            }
        }

        /// <summary>
        ///  Unzip the map data file.
        /// </summary>
        /// <param name="path">File path to unzip</param>
        /// <param name="objects">A reference to the <see cref="TableLayoutPanel"/> object for adding objects</param>
        /// <returns>True if successful.</returns>
        internal bool Unzip(string path, ref TableLayoutPanel objects)
        {
            if (null != _binMapFile && _binMapFile.FileOpen(path))
            {
                int row_number = objects.RowCount;
                int col_number = objects.ColumnCount;
                int cellheight = objects.Height / row_number;
                int cellwidth = objects.Width / col_number;
                Size boxsize = new(cellwidth, cellheight);
                int index = 0x00, chipindex = ConstBinaryData.MAP_HEADERSIZE;

                // An iterative process that sequentially accesses each split panel in a TableLayoutPanel.
                for (int i = 0; i < row_number; i++)
                {
                    for (int j = 0; j < col_number; j++)
                    {
                        TextBox textbox = _binMapFile.CreateMapTextBox(chipindex, boxsize);
                        textbox.MouseDown += MapStruct_FieldMouseDown;
                        textbox.MouseUp += MapStruct_FieldMouseUp;
                        textbox.MouseMove += MapStruct_FieldMouseMove;
                        objects.Controls.Add(textbox, j, i);
                        index++; chipindex++;
                    }
                }
                _mapTable = objects;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Unzip the map data file.
        /// </summary>
        /// <param name="path">File path to unzip</param>
        /// <param name="imagelist">A list of extracted graphic images</param>
        /// <param name="objects">A reference to the <see cref="TableLayoutPanel"/> object for adding objects</param>
        /// <returns>True if successful.</returns>
        internal bool Unzip(string path, List<Image> imagelist, ref TableLayoutPanel objects)
        {
            if (null != _binMapFile && _binMapFile.FileOpen(path))
            {
                int row_number = objects.RowCount;
                int col_number = objects.ColumnCount;
                int cellheight = objects.Height / row_number;
                int cellwidth = objects.Width / col_number;
                Size boxsize = new(cellwidth, cellheight);
                int index = 0x00, chipindex = 0x10;

                // An iterative process that sequentially accesses each split panel in a TableLayoutPanel.
                for (int i = 0; i < row_number; i++)
                {
                    for (int j = 0; j < col_number; j++)
                    {
                        // Place the image container for map data editing in MapFieldTable.
                        byte chipimage = _binMapFile.GetDataByte(chipindex) ?? 0xFF;
                        var chipno = imagelist.Count < chipimage ? imagelist.Count : chipimage;
                        PictureBox picturebox = BinMapFile.CreateTextureBox(index, imagelist[chipno], boxsize);
                        picturebox.MouseDown += MapStruct_FieldMouseDown;
                        picturebox.MouseUp += MapStruct_FieldMouseUp;
                        picturebox.MouseMove += MapStruct_FieldMouseMove;
                        objects.Controls.Add(picturebox, j, i);
                        index++; chipindex++;
                    }
                }
                _mapTable = objects;
                return true;
            }
            else
            {
                return false;
            }
        }



        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is pressed down on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseDown(object? sender, MouseEventArgs e)
        {
            if (null != _mapTable)
            {
                Point mousepos = _mapTable.PointToClient(Control.MousePosition);
                int clickedcol = mousepos.X / (_mapTable.Width / _mapTable.ColumnCount);
                int clickedrow = mousepos.Y / (_mapTable.Height / _mapTable.RowCount);
                _mouseDownPoint = new(clickedcol, clickedrow);
            }
        }

        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is moved over on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseMove(object? sender, MouseEventArgs e)
        {

        }

        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is released on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseUp(object? sender, MouseEventArgs e)
        {
            if (null != _mapTable && _mapTable.GetControlFromPosition(_mouseDownPoint.X, _mouseDownPoint.Y) is PictureBox target && "" != _chipHolder.GetChipHolderNumberText())
            {
                target.Text = _chipHolder.GetChipHolderNumberText();
                target.Image = _chipHolder.GetChipHolderImage();
            }
        }
    }
}
