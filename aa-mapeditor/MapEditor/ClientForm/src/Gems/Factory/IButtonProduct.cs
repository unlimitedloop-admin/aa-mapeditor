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
//      File name       : IButtonProduct.cs
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
    ///  Product interface for creating button objects.
    /// </summary>
    public interface IButtonProduct
    {
        /// <summary>
        ///  Create a button object.
        /// </summary>
        /// <returns>A button object or its lineage</returns>
        Button Create();
    }
}
