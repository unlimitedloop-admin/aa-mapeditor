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
//      File name       : ChipHolder.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/30
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  The management instance class for the tile panel used for selecting graphic chips from the graphic chip list.
    /// </summary>
    internal class ChipHolder
    {
        /// <summary>
        ///  The currently selected image panel in the graphic list.
        /// </summary>
        private readonly Panel _selectedChipHolder;

        /// <summary>
        ///  The PictureBox to be placed within the selectedChipPanel.
        /// </summary>
        private PictureBox ChipHolderInstance { set; get; } = new()
        {
            Anchor = AnchorStyles.None,
            Location = new Point(3, 3),
            Name = "selectedChipTexture",
            Size = new Size(32, 32),
            TabIndex = 0,
            TabStop = false
        };

        
        internal ChipHolder(ref Panel panel)
        {
            _selectedChipHolder = panel;
            _selectedChipHolder.Controls.Add(ChipHolderInstance);
        }

        /// <summary>
        ///  Set an image to the selectedChipTexture object.
        /// </summary>
        /// <param name="text">Set <see cref="string"/> the selectedChipTexture.Text</param>
        /// <param name="backgroundimage">Set <see cref="Image"/> the selectedChipTexture.Image</param>
        internal void SetSelectedChipTexture(string? text, Image? backgroundimage)
        {
            ChipHolderInstance.Text = text;
            ChipHolderInstance.Image = backgroundimage;
        }

        /// <summary>
        ///  Gets the <see cref="PictureBox"/> body object.
        /// </summary>
        /// <returns><see cref="PictureBox"/> object.</returns>
        internal PictureBox GetSelectedChipTexture()
        {
            return ChipHolderInstance;
        }

        /// <summary>
        ///  Get the text of the selected ChipTexture object.
        /// </summary>
        /// <returns><see cref="string"/> text.</returns>
        internal string? GetChipHolderNumberText()
        {
            return ChipHolderInstance.Text;
        }

        /// <summary>
        ///  Get the <see cref="Image"/> of the selected ChipTexture object.
        /// </summary>
        /// <returns><see cref="Image"/> data.</returns>
        internal Image? GetChipHolderImage()
        {
            return ChipHolderInstance.Image;
        }
    }
}
