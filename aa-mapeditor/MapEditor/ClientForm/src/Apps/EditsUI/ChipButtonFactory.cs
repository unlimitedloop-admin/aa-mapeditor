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
//      File name       : ChipButtonFactory.cs
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
    ///  Abstract class for chip list.
    /// </summary>
    internal abstract class ChipButtonFactory
    {
        protected ChipButtonFactory() { }

        /// <summary>
        ///  Abstract method to generate chips.
        /// </summary>
        internal abstract Button CreateButton(int index, Bitmap bitmap);
    }
}
