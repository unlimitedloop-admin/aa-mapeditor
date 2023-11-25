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
//      File name       : ChipManagedPanel.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/25
//
//      File version    : 5
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.CustomControls.Chip
{
    /// <summary>
    ///  Parameters to pass to ChipManagedPanel's image sharing member.
    /// </summary>
    public class IndexerImage(byte index, Image image)
    {
        public byte Index { get; set; } = index;
        public Image Img { get; set; } = image;
    }


    /// <summary>
    ///  A class that realizes mutual links between image members in a double-headed panel object used in MapEdit.
    /// </summary>
    public class ChipManagedPanel : Panel, IDisposable
    {
        /// <summary>
        ///  Shared <see cref="Image"/> member list.
        /// </summary>
        private readonly List<IndexerImage> _images = [];

        /// <summary>
        ///  The <see cref="PictureBox"/> to be placed within the choiceChipPanel.
        /// </summary>
        private readonly PictureBox _choiceChipInstance = new()
        {
            Image = null,
            Location = new Point(3, 3),
            Name = "choiceChipTexture",
            Size = new Size(32, 32),
            TabIndex = 0,
            TabStop = false,
            Visible = true,
        };

        private const int VOID__ = -1;  // The void value defined.

        public Image? ChoiceChip { get => _choiceChipInstance.Image; set => _choiceChipInstance.Image = value; }

        /// <summary>
        ///  Graphic chip collection indexer.
        /// </summary>
        public int ChoiceChipNumber { get; set; } = VOID__;

        internal int Count => _images.Count;


        public ChipManagedPanel()
        {
            Controls.Add(_choiceChipInstance);
            _choiceChipInstance.Click += ChoiceChipInstance_Click;
        }

        /// <summary>
        ///  Add images to the graphics chip list.
        /// </summary>
        /// <param name="index">Index number added to the graphic chip list</param>
        /// <param name="image">Graphic chip <see cref="Image"/></param>
        /// <return>True if successfully added.</return>
        internal bool AddImage(int index, Image image)
        {
            if (index is >= byte.MinValue and <= byte.MaxValue)
            {
                _images.Add(new IndexerImage((byte)index, image));
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Get the desired <see cref="Image"/> from the index number.
        /// </summary>
        /// <param name="index">Index of the image to search</param>
        /// <returns>The <see cref="Image"/> data, or null if the <see cref="Image"/> is not found.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal Image? GetImageByIndex(byte index)
        {
            var indexedImage = _images.FirstOrDefault(x => x.Index == index);
            return indexedImage?.Img;
        }

        /// <summary>
        ///  Click event handler.
        /// </summary>
        private void ChoiceChipInstance_Click(object? sender, EventArgs e)
        {
            if (VOID__ != ChoiceChipNumber)
            {
                MessageBox.Show("コレクション番号：" + ChoiceChipNumber.ToString() + "\r\n(16進数) 0x" + ChoiceChipNumber.ToString("X2"), "選択中チップ情報");
            }
        }

        /// <summary>
        ///  Resets (clears) the selected panel information.
        /// </summary>
        internal void Clear()
        {
            if (_choiceChipInstance.Image is IDisposable disposableImage)
            {
                disposableImage.Dispose();
                _choiceChipInstance.Image = null;
            }
            ChoiceChipNumber = VOID__;
            _images.Clear();
        }

        /// <summary>
        ///  Disposing instance.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false</param>
        protected override void Dispose(bool disposing)
        {
            Clear();
            base.Dispose(disposing);
        }
    }
}
