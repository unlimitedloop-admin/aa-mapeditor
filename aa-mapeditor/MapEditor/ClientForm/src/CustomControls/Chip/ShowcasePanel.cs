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
//      Last update     : 2023/10/22
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.Gems.Factory;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.CustomControls.Chip
{
    /// <summary>
    ///  A panel object that displays map chips.
    /// </summary>
    public partial class ShowcasePanel : Panel
    {
        /// <summary>
        ///  Fabric <see cref="Image"/> for map chips.
        /// </summary>
        public Image? BaseImage
        {
            get { return _baseImage; }
            set
            {
                if (_baseImage != value)
                {
                    _baseImage = value;
                    OnBaseImageChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///  Map chip <see cref="Image"/>.
        /// </summary>
        private Image? _baseImage = null;

        /// <summary>
        ///  Class for sharing images.
        /// </summary>
        private ChipManagedPanel? _chipManager = null;

        private const string TOOLTIP_TEXT = "このパネルをダブルクリックして素材の投入を開始します。";
        private readonly ToolTip _toolTip = new();  // For annotation.


        public ShowcasePanel()
        {
            _toolTip.SetToolTip(this, TOOLTIP_TEXT);
        }

        /// <summary>
        ///  Inserts an instance of a required class into a private member.
        /// </summary>
        /// <param name="chipmanager">Class reference</param>
        public void SetPrimaryInstance(ref ChipManagedPanel chipmanager)
        {
            _chipManager = chipmanager;
        }

        /// <summary>
        ///  Load chip list.
        /// </summary>
        /// <param name="rows">Number of lines in the chip list</param>
        /// <param name="columns">Number of columns in the chip list</param>
        public void LoadChipList(int rows, int columns)
        {
            const int GRAPHSIZE = CHIP_SIZE;
            const int GRAPHBOXSIZE = GRAPHIC_BOX_SIZE;
            const int CELLSIZE = CHIP_CELLSIZE;

            if (null == BaseImage || 0 >= rows || 0 >= columns) return;

            DeleteAllControl();
            // Displays button controls with graphics on a panel at regular intervals.
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Rectangle imgRect = new(x % columns / 1 * GRAPHSIZE, y * GRAPHSIZE, GRAPHSIZE - 1, GRAPHSIZE - 1);
                    Bitmap bitmap = new(GRAPHBOXSIZE, GRAPHBOXSIZE);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(BaseImage, new Rectangle(0, 0, GRAPHBOXSIZE, GRAPHBOXSIZE), imgRect, GraphicsUnit.Pixel);
                    if (_chipManager!.AddImage((y * columns) + x, bitmap))
                    {
                        // Using a Factory Method pattern to get a button instance and downcasting to a custom button.
                        ButtonFactory buttonFactory = new ChipButtonFactory((y * columns) + x, bitmap);
                        IButtonProduct product = buttonFactory.GetProduct();
                        Button createButton = product.Create();
                        if (createButton is ChipButton button)
                        {
                            button.Location = new Point(x * CELLSIZE, y * CELLSIZE);
                            button.Click += Button_Click;
                            Controls.Add(button);
                        }
                    }
                    else
                    {
                        /*
                         * This syntax will pass if you try to register more than 255 chips, for example.
                         * This is because it falls under an exception pattern due to the structure of binary data.
                         */ 
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///  Chip list button click event handler.
        /// </summary>
        /// <param name="sender"><see cref="ChipButton"/> object</param>
        /// <param name="e">Click event args</param>
        private void Button_Click(object? sender, EventArgs e)
        {
            ChipButton button = (ChipButton)sender!;
            _chipManager!.ChoiceChipInstance.Image = button.Image;
            _chipManager!.ChoiceChipNumber = button.ChipIndex;
        }

        /// <summary>
        ///  BaseImage property is changed event handler.
        /// </summary>
        private void OnBaseImageChanged(object? sender, EventArgs e)
        {
            _toolTip.Active = null == _baseImage;
        }

        /// <summary>
        ///  Remove all controls from the panel.
        /// </summary>
        internal void DeleteAllControl()
        {
            SuspendLayout();
            foreach (Control control in Controls)
            {
                if (control is ChipButton button)
                {
                    button.Click -= Button_Click;
                }
                control.Dispose();
            }
            Controls.Clear();
            ResumeLayout();
            _chipManager?.Clear();
        }
    }
}
