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
//      File name       : ConcreteChipButtonFactory.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/12
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  Concrete class for factory method pattern objects to generate button objects.
    /// </summary>
    internal class ConcreteChipButtonFactory : ChipButtonFactory
    {
        /// <summary>
        ///  Create a button object.
        /// </summary>
        /// <param name="index">Chip index number</param>
        /// <param name="bitmap">Chip image</param>
        /// <returns>The created button object.</returns>
        internal override Button CreateButton(int index, Bitmap bitmap)
        {
            Button button = new()
            {
                Name = "chip_" + index,
                FlatStyle = FlatStyle.Flat,
                Width = 40,
                Height = 40,
                BackColor = Color.Transparent,
                Image = bitmap,
                BackgroundImageLayout = ImageLayout.None,
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }
    }
}
