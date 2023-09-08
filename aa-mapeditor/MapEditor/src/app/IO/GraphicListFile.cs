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
//      File name       : GraphicListFile.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/08
//
//      File version    : 5
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.common;



/* sources */
namespace MapEditor.src.app.IO
{
    /// <summary>
    ///  File IO class for graphic image datas.
    /// </summary>
    internal class GraphicListFile : IStandardFileIO
    {
        /// <summary>
        ///  Graphic chip file source path.
        /// </summary>
        public string FilePath { protected set; get; } = string.Empty;
        
        /// <summary>
        ///  Graphic chip file name label.
        /// </summary>
        public string Name { protected set; get; }

        /// <summary>
        ///  The original image data.
        /// </summary>
        private Image? _image = null;

        /// <summary>
        ///  Graphic chip list object data.
        /// </summary>
        public List<Image>? ImageList { get; set; } = null;


        /// <summary>
        ///  Click event listener for the graphics chip list button.
        /// </summary>
        public event EventHandler? GraphicChipClick;


        /// <summary>
        ///  This is the constructor for GraphicListFile.
        /// </summary>
        /// <param name="name">Graphic chip file name label</param>
        internal GraphicListFile(string name)
        {
            Name = name;
        }

        /// <summary>
        ///  Loads the specified graphics data into read memory.
        /// </summary>
        /// <param name="path">Specify the full path of the graphicdata file</param>
        /// <returns>When the file is successfully opened, true is returned.</returns>
        public bool FileOpen(string path)
        {
            _image = Image.FromFile(path);
            if (null != _image)
            {
                FilePath = path;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Clears the data loaded in memory.
        /// </summary>
        /// <param name="path">Target file path</param>
        /// <returns>When the file is successfully closed, true is returned.</returns>
        public bool FileClose(string path)
        {
            if (null != _image && path == FilePath)
            {
                _image?.Dispose();
                if (null != ImageList)
                {
                    foreach (var item in ImageList)
                    {
                        item.Dispose();
                    }
                }
            }
            return true;
        }

        /// <summary>
        ///  Gets an empty <seealso cref="TableLayoutPanel"/> of the specified size.
        /// </summary>
        /// <param name="rowcount">Specifies the number of rows in the <seealso cref="TableLayoutPanel"/> to construct</param>
        /// <param name="columncount">Specifies the number of columns in the <seealso cref="TableLayoutPanel"/> to construct</param>
        /// <param name="larger">Cell size (square absolute value)</param>
        /// <returns><seealso cref="TableLayoutPanel"/> instance.</returns>
        private static TableLayoutPanel GetLayoutPanel(uint rowcount, uint columncount, int larger)
        {
            TableLayoutPanel table = new()
            {
                AutoSize = true,
                RowCount = (int)rowcount,
                ColumnCount = (int)columncount,
            };
            table.RowStyles.Clear();
            for (var row = 0; row < table.RowCount; row++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, larger));
            }
            table.ColumnStyles.Clear();
            for (var col = 0; col < table.ColumnCount; col++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, larger));
            }
            table.Size = new Size(table.ColumnCount * larger, table.RowCount * larger);
            return table;
        }

        /// <summary>
        ///  Create and get a button control object for the graphics chip list.
        /// </summary>
        /// <param name="index">Prefix number to append to button names</param>
        /// <param name="bitmap">Bitmap information to set in the background of the button</param>
        /// <returns><seealso cref="Button"/> instance.</returns>
        private Button GetButton(uint index, Bitmap bitmap)
        {
            Button button = new()
            {
                Name = "graph" + index,
                Text = index.ToString(),
                FlatStyle = FlatStyle.Flat,
                Width = ConstGraphicData.CHIPBUTTON_SIZE,
                Height = ConstGraphicData.CHIPBUTTON_SIZE,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.None,
            };
            button.FlatAppearance.BorderSize = 0;
            button.BackgroundImage = bitmap;
            button.Click += GraphicChipList_Click;
            return button;
        }

        /// <summary>
        ///  Get the <seealso cref="TableLayoutPanel"/> object for the graphics chip list.
        /// </summary>
        /// <param name="rows">Setting rows on the table</param>
        /// <param name="cols">Setting columns on the table</param>
        /// <returns><seealso cref="TableLayoutPanel"/> instance.</returns>
        internal TableLayoutPanel? GetGraphicChipList(uint rows, uint cols)
        {
            TableLayoutPanel? table = null;
            // Is there an upper limit for the graphics chip list, is it within that range, and is it possible to obtain the specified image file?
            if (null != _image && 0x100 >= rows * cols)
            {
                const int graph_size = ConstGraphicData.CHIPRAWSIZE;
                const int cell_size = ConstGraphicData.TABLE_CELLSIZE;
                ImageList = new();
                // Create a resource to place the graphics chip list.
                table = GetLayoutPanel(rows, cols, cell_size);
                // Split the loaded Image and place it in the individual cells of the TableLayoutPanel object in order.
                uint counter = 0;
                for (var row = 0; row < table.RowCount; row++)
                {
                    for (var col = 0; col < table.ColumnCount; col++)
                    {
                        // Create a drawing canvas and put it in the background of the button.
                        Rectangle box = new(0, 0, ConstGraphicData.GRAPHBOXSIZE, ConstGraphicData.GRAPHBOXSIZE);
                        Rectangle img_rect = new(col % table.ColumnCount / 1 * graph_size, row * graph_size, graph_size, graph_size);
                        Bitmap bitmap = new(cell_size, cell_size);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        graphics.DrawImage(_image, box, img_rect, GraphicsUnit.Pixel);
                        // Add the created instance to the list.
                        table.Controls.Add(GetButton(counter, bitmap), col, row);
                        ImageList.Add(bitmap);
                        counter++;
                    }
                }
                table.Invalidate();         // Reload.
            }
            return table;
        }

        /// <summary>
        ///  Retrieve the chip list from the specified index.
        /// </summary>
        /// <param name="index">The index of the array element</param>
        /// <returns>If the specified array index is found, the image data is returned.</returns>
        internal Image? GetChipListImageAtImdex(int index)
        {
            if (null != ImageList && 0 <= index && ImageList.Count > index)
            {
                return ImageList[index];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        ///  Click event when the graphic chip button is clicked.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        private void GraphicChipList_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender!;
            GraphicChipClick?.Invoke(button, e);
        }
    }
}
