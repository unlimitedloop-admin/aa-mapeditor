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
//      Last update     : 2023/09/30
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.IO;
using MapEditor.src.common;
using MapEditor.src.logger;
using MapEditor.src.main;
using static MapEditor.src.common.ConstMapFieldTable;



/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  The algorithm class for constructing map data.
    /// </summary>
    internal partial class MapStructs
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

        /// <summary>
        ///  Map field page number.
        /// </summary>
        public int MapPages { get; set; }

        /// <summary>
        ///  A boolean value representing the active state of a tile.
        /// </summary>
        private bool _foldType = false;


        /// <summary>
        ///  This is the constructor for MapStructs.
        /// </summary>
        /// <param name="name">Binary file name label.</param>
        /// <param name="chipHolder">A reference instance of the ChipHolder class.</param>
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
        ///  Creates a new TableLayoutPanel configured as a map field with the specified parameters.
        /// </summary>
        /// <param name="name">Specify the name of the object</param>
        /// <param name="columncount">The number of columns for the table</param>
        /// <param name="rowcount">The number of rows for the table</param>
        /// <param name="size">The overall size of the table</param>
        /// <param name="location">The location of the table on its parent control</param>
        /// <param name="cellsize">The absolute size in pixels for each cell (both rows and columns)</param>
        /// <returns>Returns a configured TableLayoutPanel representing the map field.</returns>
        private static TableLayoutPanel CreateMapFieldTable(string name, int columncount, int rowcount, Size size, Point location, float cellsize)
        {
            TableLayoutPanel table = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = columncount,
                Location = location,
                Margin = new Padding(0),
                Name = name,
                RowCount = rowcount,
                Size = size,
                TabIndex = 0
            };
            for (int i = 0; i < table.ColumnCount; i++)
            {
                _ = table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellsize));
            }
            for (int j = 0; j < table.RowCount; j++)
            {
                _ = table.RowStyles.Add(new RowStyle(SizeType.Absolute, cellsize));
            }
            return table;
        }

        /// <summary>
        ///  Unzip the map data file.
        /// </summary>
        /// <param name="path">File path to unzip</param>
        /// <param name="objects">A reference to the <see cref="Panel"/> object to add map fields.</param>
        /// <returns>True if successful.</returns>
        internal bool Unzip(string path, ref Panel objects)
        {
            if (null != _binMapFile && _binMapFile.FileOpen(path))
            {
                _mapTable = CreateMapFieldTable(MAPFIELDNAME, MAPCOLUMNS, MAPROWS, new Size(MAPSIZES_X, MAPSIZES_Y), new Point(MAPLOCATIONS_X, MAPLOCATIONS_Y), MAPCELLSIZES);
                int row_number = _mapTable.RowCount;
                int col_number = _mapTable.ColumnCount;
                int cellheight = _mapTable.Height / row_number;
                int cellwidth = _mapTable.Width / col_number;
                Size boxsize = new(cellwidth, cellheight);
                int index = 0x00, chipindex = ConstBinaryData.MAP_HEADERSIZE;

                // An iterative process that sequentially accesses each split panel in a TableLayoutPanel.
                for (int i = 0; i < row_number; i++)
                {
                    for (int j = 0; j < col_number; j++)
                    {
                        TextBox textbox = _binMapFile.CreateMapTextBox(chipindex, boxsize);
                        _mapTable.Controls.Add(textbox, j, i);
                        index++; chipindex++;
                    }
                }
                objects.Controls.Add(_mapTable);
                MapPages = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Unzip the map data file.
        /// </summary>
        /// <param name="path">File path to unzip</param>
        /// <param name="imagelist">A list of extracted graphic images</param>
        /// <param name="objects">A reference to the <see cref="Panel"/> object to add map fields.</param>
        /// <returns>True if successful.</returns>
        internal bool Unzip(string path, List<Image> imagelist, ref Panel objects)
        {
            if (null != _binMapFile && _binMapFile.FileOpen(path))
            {
                _mapTable = CreateMapFieldTable(MAPFIELDNAME, MAPCOLUMNS, MAPROWS, new Size(MAPSIZES_X, MAPSIZES_Y), new Point(MAPLOCATIONS_X, MAPLOCATIONS_Y), MAPCELLSIZES);
                int row_number = _mapTable.RowCount;
                int col_number = _mapTable.ColumnCount;
                int cellheight = _mapTable.Height / row_number;
                int cellwidth = _mapTable.Width / col_number;
                Size boxsize = new(cellwidth, cellheight);
                int index = 0x00, chipindex = ConstBinaryData.MAP_HEADERSIZE;

                // An iterative process that sequentially accesses each split panel in a TableLayoutPanel.
                for (int i = 0; i < row_number; i++)
                {
                    for (int j = 0; j < col_number; j++)
                    {
                        // Place the image container for map data editing in MapFieldTable.
                        byte chipimage = _binMapFile.GetDataByte(chipindex) ?? 0xFF;
                        var chipno = imagelist.Count < chipimage ? imagelist.Count : chipimage;
                        PictureBox picturebox = BinMapFile.CreateTextureBox(index, imagelist[chipno], boxsize);
                        picturebox.Text = chipno.ToString();
                        picturebox.MouseDown += MapFieldChip_MouseDown;
                        picturebox.MouseUp += MapFieldChip_MouseUp;
                        picturebox.MouseMove += MapFieldChip_MouseMove;
                        picturebox.Click += MapFieldChip_Click;
                        _mapTable.Controls.Add(picturebox, j, i);
                        index++; chipindex++;
                    }
                }
                objects.Controls.Add(_mapTable);
                MapPages = 0;
                SetupMapStructure();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Changes the alpha level of the image tile.
        /// </summary>
        /// <param name="transparent">Specified transparency of the texture at the maptable</param>
        internal void ChangeTextureAlphaLvl(bool transparent)
        {
            if (null != _binMapFile && null != _mapTable)
            {
                foreach (Control control in _mapTable.Controls)
                {
                    if (control is PictureBox picturebox && picturebox.Image is Bitmap bitmap_org)
                    {
                        if (transparent)
                        {
                            picturebox.Image = _binMapFile.MakeImageSemiTransparent(bitmap_org);
                        }
                        else
                        {
                            picturebox.Image = _binMapFile.MakeImageOpaque(bitmap_org);
                        }
                    }
                }
                _foldType = transparent;
                
                if (!_foldType)
                    RangeModeOff();
            }
        }

        /// <summary>
        ///  Sets the image and text of the target PictureBox at the specified cell position with the data from the provided source PictureBox.
        /// </summary>
        /// <param name="x">The x-coordinate of the target cell position</param>
        /// <param name="y">The y-coordinate of the target cell position</param>
        /// <param name="objects">The source PictureBox containing the data to be copied</param>
        /// <param name="transparent">A flag indicating if the image should be made semi-transparent</param>
        /// <exception cref="ArgumentException"></exception>
        internal void SetPanelFromMapFieldPosition(int x, int y, PictureBox objects, bool transparent)
        {
            try
            {
                if (null != _binMapFile && _mapTable?.GetControlFromPosition(x, y) is PictureBox target)
                {
                    target.Text = objects.Text;
                    if (transparent)
                    {
                        target.Image = _binMapFile.MakeImageSemiTransparent((Bitmap)objects.Image!);
                    }
                    else
                    {
                        target.Image = objects.Image;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("The map range is not correct. Please retry the operation.", "UNEXPECTED EXCEPTION INFO");
                DefaultLogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        ///  Fill the area selected as the selection range with pre-specified image chips.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ReplaceOnMapRangePanel()
        {
            try
            {
                // An iterative process that, if there is a selected graphic chip and the selected range refers to a valid area,
                // places it throughout the specified range.
                if (null != _binMapFile && "" != _chipHolder.GetChipHolderNumberText())
                {
                    // Ensure startCell is the top-left and endCell is the bottom-right.
                    Point start = new(
                        Math.Min(_ranger.startCell.X, _ranger.endCell.X),
                        Math.Min(_ranger.startCell.Y, _ranger.endCell.Y)
                    );
                    Point end = new(
                        Math.Max(_ranger.startCell.X, _ranger.endCell.X),
                        Math.Max(_ranger.startCell.Y, _ranger.endCell.Y)
                    );

                    List<MementoParameter> parameters = new();
                    for (int col = start.X; col <= end.X; col++)
                    {
                        for (int row = start.Y; row <= end.Y; row++)
                        {
                            if (_mapTable?.GetControlFromPosition(col, row) is PictureBox picture)
                            {
                                parameters.Add(new MementoParameter
                                {
                                    OldImageBinNum = byte.Parse(picture.Text),
                                    NewImageBinNum = byte.Parse(_chipHolder.GetChipHolderNumberText()!),
                                    MapAddress = (MapPages * 0x100) + (ConstBinaryData.MAP_HEADERSIZE + (0x10 * row) + col),
                                });
                            }
                            SetPanelFromMapFieldPosition(col, row, _chipHolder.GetSelectedChipTexture(), true);
                        }
                    }
                    MainForm.Recollection(parameters);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("The map range is not correct. Please retry the operation.", "UNEXPECTED EXCEPTION INFO");
                DefaultLogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        ///  Indirectly invokes the <see cref="ReplaceOnMapRangePanel">ReplaceOnMapRangePanel</see> method.
        /// </summary>
        /// <param name="reset">True if you want to clear the selected range</param>
        internal void CallReplaceOnMapRangePanel(bool reset)
        {
            // If the Enter key is pressed, it performs tile filling and clears the selection mode.
            // If the Insert key is pressed, it only performs tile filling.
            if (_ranger.selectionAnimationTimer.Enabled)
            {
                ReplaceOnMapRangePanel();
                if (reset)
                    RangeModeOff();
            }
        }

        /// <summary>
        ///  Remove all MapTable controls.
        /// </summary>
        internal void RemoveControlForAll()
        {
            _mapTable?.SuspendLayout();
            for (int row = 0; row < _mapTable?.RowCount; row++)
            {
                for (int col = 0; col < _mapTable?.ColumnCount; col++)
                {
                    Control? control = _mapTable?.GetControlFromPosition(col, row);
                    if (control is PictureBox || control is TextBox)
                    {
                        _mapTable?.Controls.Remove(control);
                        control.Dispose();
                    }
                }
            }
            _mapTable?.ResumeLayout(true);
        }
    }
}
