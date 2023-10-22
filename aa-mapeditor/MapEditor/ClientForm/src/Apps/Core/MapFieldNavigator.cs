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
//      Last update     : 2023/10/22
//
//      File version    : 2
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
        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                if (_fieldName != value)
                {
                    _fieldName = value;
                    OnFieldNameChanged();
                }
            }
        }

        /// <summary>
        ///  Binary map filepath.
        /// </summary>
        private string _fieldName = string.Empty;

        /// <summary>
        ///  The page index of the currently drawn map.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///  Binary array of map data to draw.
        /// </summary>
        public byte[,] MapFields { get; set; }

        /// <summary>
        ///  This is original formed binary data loaded into memory.
        /// </summary>
        public byte[] BinaryData { get; private set; }


        /// <summary>
        ///  Please pass an byte array for drawing map fields.
        /// </summary>
        /// <param name="bytes">Byte type array</param>
        public MapFieldNavigator(byte[,] bytes)
        {
            MapFields = bytes;
            BinaryData = Array.Empty<byte>();
        }

        /// <summary>
        ///  Delete the binary data enumeration of concealment.
        /// </summary>
        internal void Clear()
        {
            BinaryData = Array.Empty<byte>();
        }

        /// <summary>
        ///  Sets the binary array to be drawn in the field.
        /// </summary>
        /// <returns>True if the field information could be set.</returns>
        internal bool SetFieldData()
        {
            using BinaryMap binary = new();
            if (binary.BinaryFileOpener())
            {
                byte[,] currentMapFields = MapFields;
                for (int i = 0; i < MapFields.GetLength(0); i++)
                {
                    for (int j = 0; j < MapFields.GetLength(1); j++)
                    {
                        if (binary.GetBinaryData(0x10 + (i * MapFields.GetLength(1)) + j) is byte data)
                        {
                            _ = ChangeMapTile(i, j, data);
                        }
                        else
                        {
                            // If ArgumentOutOfRangeException occurs in GetBinaryData...
                            MapFields = currentMapFields;
                            MessageBox.Show("チップリストに含まれないバイナリバイト羅列が見つかったため、マップは表示できませんでした。", "お知らせ");
                            return false;
                        }
                    }
                }
                FieldName = binary.FilePath;
                BinaryData = binary.BinaryData;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Stores the chips in the specified array.
        /// </summary>
        /// <param name="row">Row number of the array</param>
        /// <param name="col">Column number of the array</param>
        /// <param name="index">Tile index to be replaced</param>
        /// <returns>True if the array has been replaced; false if there is no change.</returns>
        internal bool ChangeMapTile(int row, int col, byte index)
        {
            if (0 <= row && MapFields.GetLength(0) > row && 0 <= col && MapFields.GetLength(1) > col)
            {
                MapFields[row, col] = index;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Event when FieldName is changed.
        /// </summary>
        public event EventHandler? FieldNameChanged;

        /// <summary>
        ///  Event when FieldName is changed. (virtual method)
        /// </summary>
        protected virtual void OnFieldNameChanged()
        {
            FieldNameChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
