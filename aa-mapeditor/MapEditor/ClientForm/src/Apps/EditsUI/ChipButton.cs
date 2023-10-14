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
//      File name       : ChipButton.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Gems.Factory;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  Custom button class to obtain additional information of the graphics chip.
    /// </summary>
    public class ChipButton : Button, IButtonProduct
    {
        /// <summary>
        ///  Graphics chip index number.
        /// </summary>
        public int ChipIndex { get; }


        /// <summary>
        ///  Set up the chip button.
        /// </summary>
        /// <param name="index">Graphics chip indexer</param>
        /// <param name="bitmap">Graphic (<see cref="Bitmap"/>) to display on the button</param>
        public ChipButton(int index, Bitmap bitmap)
        {
            Name = "chip_" + index;
            ChipIndex = index;
            FlatStyle = FlatStyle.Flat;
            Width = CHIP_BUTTONSIZE;
            Height = CHIP_BUTTONSIZE;
            BackColor = Color.Transparent;
            Image = bitmap;
            BackgroundImageLayout = ImageLayout.None;
            FlatAppearance.BorderSize = 0;
            ToolTip toolTip = new();
            toolTip.SetToolTip(this, index.ToString());
        }

        /// <summary>
        ///  Create chip list button object.
        /// </summary>
        /// <returns><see cref="ChipButton"/> object.</returns>
        public Button Create()
        {
            return new ChipButton(ChipIndex, (Bitmap)Image!);
        }
    }
}
