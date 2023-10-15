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
//      Last update     : 2023/10/15
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Gems.Factory;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  Concrete class for factory method pattern objects to generate button objects.
    /// </summary>
    internal class ChipButtonFactory : ButtonFactory
    {
        // Adding chip data infomation.
        private readonly int _index;
        private readonly Bitmap _bitmap;


        /// <summary>
        ///  Request a custom button.
        ///  <para>To receive a custom button, you need to call the <see cref="GetProduct"/> from the instance.</para>
        /// </summary>
        /// <param name="index">Index number</param>
        /// <param name="bitmap">Texture</param>
        internal ChipButtonFactory(int index, Bitmap bitmap)
        {
            _index = index;
            _bitmap = bitmap;
        }

        /// <summary>
        ///  Create a button object.
        /// </summary>
        /// <returns>Button for optimized graphics chip.</returns>
        internal override IButtonProduct GetProduct()
        {
            return new ChipButton(_index, _bitmap);
        }
    }
}
