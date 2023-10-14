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
//      File name       : ButtonFactory.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Gems.Factory
{
    /// <summary>
    ///  An abstract class that has the functionality to manufacture button products.
    /// </summary>
    internal abstract class ButtonFactory
    {
        /// <summary>
        ///  The main function of manufacturing button products.
        /// </summary>
        /// <returns>A button object or its lineage.</returns>
        internal abstract IButtonProduct GetProduct();
    }
}
