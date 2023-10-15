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
//      Last update     : 2023/10/15
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */

namespace ClientForm.src.CustomControls.Chip
{
    /// <summary>
    ///  Parameters to pass to ChipManagedPanel's image sharing member.
    /// </summary>
    public class IndexerImage
    {
        public int Index { get; set; }
        public Image Img { get; set; }

        public IndexerImage(int index, Image image)
        {
            Index = index;
            Img = image;
        }
    }


    /// <summary>
    ///  A class that realizes mutual links between image members in a double-headed panel object used in MapEdit.
    /// </summary>
    public class ChipManagedPanel : Panel, IDisposable
    {
        /// <summary>
        ///  Shared image member list.
        /// </summary>
        private readonly List<IndexerImage> _images = new();

        // TODO : 不要な代入が発生しないようにメンバの隠蔽が必要
        /// <summary>
        ///  The PictureBox to be placed within the choiceChipPanel.
        /// </summary>
        public PictureBox ChoiceChipInstance { get; set; } = new()
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

        /// <summary>
        ///  Graphic chip collection indexer.
        /// </summary>
        public int ChoiceChipNumber { get; set; } = VOID__;

        internal int Count => _images.Count;
        internal void Clear() => _images.Clear();


        public ChipManagedPanel()
        {
            Controls.Add(ChoiceChipInstance);
            ChoiceChipInstance.Click += ChoiceChipInstance_Click;
        }

        /// <summary>
        ///  Add images to the graphics chip list.
        /// </summary>
        /// <param name="index">Index number added to the graphic chip list</param>
        /// <param name="image">Graphic chip <see cref="Image"/></param>
        internal void AddImage(int index, Image image)
        {
            _images.Add(new IndexerImage(index, image));
        }

        /// <summary>
        ///  Get the desired <see cref="Image"/> from the index number.
        /// </summary>
        /// <param name="index">Index of the image to search</param>
        /// <returns>The <see cref="Image"/> data, or null if the <see cref="Image"/> is not found.</returns>
        internal Image? GetImageByIndex(int index)
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
        ///  Disposing instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Clear();
        }
    }
}
