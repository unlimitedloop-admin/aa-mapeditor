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
//      File name       : ConstBinaryData.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/06
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.common
{
    /// <summary>
    ///  Provisions for defining binary files.
    /// </summary>
    internal class ConstBinaryData
    {
        // Data size of a single page of binary map data.
        public const int BINARYMAP_PAGESIZE = 256;
        public const int BINARY_DATA_UNITPAGES = BINARYMAP_PAGESIZE;
        public const int MAP_PAGESIZE = BINARYMAP_PAGESIZE;

        // Header information capacity of binary data.
        public const int BINARYMAP_HEADERSIZE = 16;
        public const int BINARY_DATA_HEADER = BINARYMAP_HEADERSIZE;
        public const int MAP_HEADERSIZE = BINARYMAP_HEADERSIZE;
    }
}
