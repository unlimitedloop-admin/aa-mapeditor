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
//      File name       : ConstMapFieldTable.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/01
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.common
{
    /// <summary>
    ///  The standard properties of the map field.
    /// </summary>
    internal class ConstMapFieldTable
    {
        public const string MAPFIELDNAME = "mapFieldTable";
        public const int MAPCOLUMNS = 16;
        public const int MAPROWS = 15;
        public const int MAPSIZES_X = 512;
        public const int MAPSIZES_Y = 480;
        public const int MAPLOCATIONS_X = 23;
        public const int MAPLOCATIONS_Y = 11;
        public const float MAPCELLSIZES = 32F;

        public const int MAPFIELD_MODE_CLICK = 0;
        public const int MAPFIELD_MODE_RANGE = 1;
    }
}
