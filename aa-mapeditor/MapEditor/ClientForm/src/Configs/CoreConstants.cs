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
//      Last update     : 2023/12/07
//
//      File version    : 6
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Configs
{
    /// <summary>
    ///  Constant definition class.
    /// </summary>
    public static class CoreConstants
    {
        // Map tile panel configurations.
        public const int MAPFIELD_PANEL_WIDTH = 512;
        public const int MAPFIELD_PANEL_HEIGHT = 480;
        public const int MAPFIELD_LINES = 15;
        public const int MAPFIELD_COLUMNS = 16;
        public const int MAPFIELD_CELLSIZE = 32;


        // The size of the single button placed in the graphic chip list is square, so it has the same length and width.
        public const int GRAPHIC_CHIPLIST_BUTTON_SIZE = 40;
        public const int CHIP_BUTTONSIZE = GRAPHIC_CHIPLIST_BUTTON_SIZE;


        // Standard size of graphics chip. (16×16)
        public const int GRAPHIC_CHIP_RAW_SIZE = 16;
        public const int CHIP_SIZE = GRAPHIC_CHIP_RAW_SIZE;


        // graphicChipList config.
        public const int GRAPHIC_BOX_SIZE = 32;
        public const int GRAPHIC_CHIP_LIST_CELLSIZE = 48!;
        public const int CHIP_CELLSIZE = GRAPHIC_CHIP_LIST_CELLSIZE;


        // Binary file config.
        public const int BINARY_DATA_1PAGE_SIZE = 0x100;
        public const int BINARY_HEADER_SIZE = 0x10;
        public const int BINARY_LINE_SIZE = 0x10;


        // Header property collection.
        public static readonly string[] SCROLLTYPELIST = [
            "隣接ページなし",
            "任意スクロール",
            "ぺージ単位スクロール",
            "スクロール不可（淵あり）",
            "スクロール不可（淵なし）",
            "動的イベント型（フラグ）",
            "軸補正型スクロール",
            "ループ部屋の両端",
            "オートスクロール",
            "オブジェクト依存オートスクロール",
            "大部屋",
            "三次元スクロール",
            "ラスタースクロール（フラグ）",
            "多重BG（フラグ）",
            "その他",
            "（未定義）"
        ];

        public static readonly string[] SCROLLTYPE = [
            "-",
            "Follow",
            "Fixed",
            "None",
            "None",
            "Event",
            "SemiFollow",
            "Loops",
            "Auto",
            "Obj.Auto",
            "Multiway",
            "3D",
            "Raster",
            "DupliBG",
            "X",
            "Z"
        ];
    }
}
