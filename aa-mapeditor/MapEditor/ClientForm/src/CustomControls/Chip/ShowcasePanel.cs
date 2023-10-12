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
//      File name       : ShowcasePanel.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/12
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.EditsUI;



/* sources */
namespace ClientForm.src.CustomControls.Chip
{
    /// <summary>
    ///  A panel object that displays map chips.
    /// </summary>
    public partial class ShowcasePanel : Panel
    {
        private readonly ChipButtonFactory _buttonFactory;

        /// <summary>
        ///  Fabric <see cref="Image"/> for map chips.
        /// </summary>
        public Image? BaseImage { get; set; } = null;


        public ShowcasePanel()
        {
            _buttonFactory = new ConcreteChipButtonFactory();
        }

        /// <summary>
        ///  Load chip list.
        /// </summary>
        /// <param name="rows">Number of lines in the chip list</param>
        /// <param name="columns">Number of columns in the chip list</param>
        public void LoadChipList(int rows, int columns)
        {
            const int GRAPHSIZE = 16;
            const int GRAPHBOXSIZE = 32;
            const int TABLECELLSIZE = 48!;

            if (null == BaseImage || 0 >= rows || 0 >= columns) return;

            Controls.Clear();
            // Displays button controls with graphics on a panel at regular intervals.
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Rectangle imgRect = new(x % columns / 1 * GRAPHSIZE, y * GRAPHSIZE, GRAPHSIZE - 1, GRAPHSIZE - 1);
                    Bitmap bitmap = new(TABLECELLSIZE, TABLECELLSIZE);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(BaseImage, new Rectangle(7, 7, GRAPHBOXSIZE, GRAPHBOXSIZE), imgRect, GraphicsUnit.Pixel);

                    Button button = _buttonFactory.CreateButton(y * columns + x, bitmap);
                    button.Location = new Point(x * TABLECELLSIZE, y * TABLECELLSIZE);
                    button.Click += Button_Click;
                    Controls.Add(button);
                }
            }
        }

        /// <summary>
        ///  Chip list button click event handler.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Click event args</param>
        private void Button_Click(object? sender, EventArgs e)
        {

        }
    }
}
