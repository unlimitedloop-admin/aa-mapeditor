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
//      File name       : CoreConstants.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Configs
{
    /// <summary>
    ///  Constant definition class.
    /// </summary>
    static class CoreConstants
    {
        // Map tile configurations.
        public const int MAPFIELD_LINES = 15;
        public const int MAPFIELD_COLUMNS = 16;
        public const int MAPFIELD_CELLSIZE = 32;


        // The size of the single button placed in the graphic chip list is square, so it has the same length and width.
        public const int GRAPHIC_CHIPLIST_BUTTON_SIZE = 40;
        public const int CHIP_BUTTONSIZE = GRAPHIC_CHIPLIST_BUTTON_SIZE;


        // Standard size of graphics chip. (16×16)
        public const int GRAPHIC_CHIP_RAW_SIZE = 16;
        public const int CHIP_SIZE = GRAPHIC_CHIP_RAW_SIZE;
    }
}
