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
//      File name       : MapFieldNavigator.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/18
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.EditsUI;



/* sources */
namespace ClientForm.src.Apps.Core
{
    /// <summary>
    ///  A class that guides and manages map fields.
    /// </summary>
    internal class MapFieldNavigator
    {
        /// <summary>
        ///  Name (label) of the map field.
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        ///  A memory class that reads binary files and manages map data.
        /// </summary>
        private readonly BinaryMap _binaryMap = new();

        /// <summary>
        ///  The page index of the currently drawn map.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///  Binary array of map data to draw.
        /// </summary>
        public byte[,] MapFields;


        /// <summary>
        ///  Please pass an byte array for drawing map fields.
        /// </summary>
        /// <param name="bytes">Byte type array</param>
        public MapFieldNavigator(byte[,] bytes)
        {
            MapFields = bytes;
        }

        /// <summary>
        ///  Sets the binary array to be drawn in the field.
        /// </summary>
        internal void SetFieldData()
        {
            if (_binaryMap.BinaryFileOpener())
            {
                FieldName = _binaryMap.FilePath;
                for (int i = 0; i < MapFields.GetLength(0); i++)
                {
                    for (int j = 0; j < MapFields.GetLength(1); j++)
                    {
                        byte? data = _binaryMap.GetBinaryData(0x10 + (i * MapFields.GetLength(1)) + j);
                        MapFields[i, j] = data ?? 0xFF;
                    }
                }
            }
        }
    }
}
