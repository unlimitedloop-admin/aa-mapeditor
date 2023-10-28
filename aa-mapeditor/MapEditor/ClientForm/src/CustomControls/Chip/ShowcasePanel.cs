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
//      Last update     : 2023/10/28
//
//      File version    : 7
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.Exceptions;
using ClientForm.src.Gems.Command;
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
        ///  Memento stack reference.
        /// </summary>
        private RecordSupervision? _memento;

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
        private ChipManagedPanel? _chipManager;

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
        /// <param name="memento">Class reference</param>
        public void SetPrimaryInstance(ref ChipManagedPanel chipmanager, ref RecordSupervision memento)
        {
            _chipManager = chipmanager;
            _memento = memento;
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

            _ = ExceptionHandler.TryCatchWithLogging(() =>
            {
                // Displays button controls with graphics on a panel at regular intervals.
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        Bitmap bitmap = new(GRAPHBOXSIZE, GRAPHBOXSIZE);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        Rectangle imgRect = new(x % columns * GRAPHSIZE, y * GRAPHSIZE, GRAPHSIZE - 1, GRAPHSIZE - 1);
                        graphics.DrawImage(BaseImage, new Rectangle(0, 0, GRAPHBOXSIZE, GRAPHBOXSIZE), imgRect, GraphicsUnit.Pixel);

                        byte location = (byte)(y * columns + x);
                        if (_chipManager!.AddImage(location, bitmap))
                        {
                            ButtonFactory buttonFactory = new ChipButtonFactory(location, bitmap);
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
                            throw new Exception("Failed to add image to _chipManager");
                        }
                    }
                }
            });
        }

        /// <summary>
        ///  Chip list button click event handler.
        /// </summary>
        /// <param name="sender"><see cref="ChipButton"/> object</param>
        /// <param name="e">Click event args</param>
        private void Button_Click(object? sender, EventArgs e)
        {
            ChipButton button = (ChipButton)sender!;
            var command = new ChipSelectCommand(_chipManager!, button.Image, button.ChipIndex);
            command.Execute();
            _memento!.PushUndoStack(command);
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
            _memento?.Clear();
        }
    }
}
