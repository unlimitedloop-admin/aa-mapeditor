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
//      File name       : ConstGraphicData.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/10
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.common
{
    /// <summary>
    ///  Provisions for defining graphic chip lists.
    /// </summary>
    internal class ConstGraphicData
    {
        /// <summary>
        ///  Standard size of graphics chip. (16×16)
        /// </summary>
        public const int GRAPHIC_CHIP_RAW_SIZE = 16;
        public const int CHIPRAWSIZE = GRAPHIC_CHIP_RAW_SIZE;

        /// <summary>
        ///  Graphic chip list button size. (40)
        /// </summary>
        public const int CHIPBUTTON_SIZE = 40;

        /// <summary>
        ///  Image size (32x32) placed int the graphics chip list.
        /// </summary>
        public const int GRAPHIC_BOX_IMAGE_SIZE = 32;
        public const int GRAPHBOXSIZE = GRAPHIC_BOX_IMAGE_SIZE;

        /// <summary>
        ///  Table cell size. (48x48)
        /// </summary>
        public const int CHIPLIST_TABLE_CELL_SIZE = 48!;
        public const int TABLE_CELLSIZE = CHIPLIST_TABLE_CELL_SIZE;
    }
}
