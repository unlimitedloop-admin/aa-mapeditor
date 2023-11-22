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
//      Last update     : 2023/11/21
//
//      File version    : 5
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.Exceptions;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Apps.Core
{
    /// <summary>
    ///  A class that guides and manages map fields.
    /// </summary>
    internal class MapFieldNavigator
    {
        /// <summary>
        ///  Binary map filepath.
        /// </summary>
        private string _fieldName = string.Empty;

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
        ///  Index value of the page number currently being drawn.
        /// </summary>
        private int _pageIndex;

        /// <summary>
        ///  The page address of the currently drawn map.
        /// </summary>
        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                if (_pageIndex != value && 0 <= value)
                {
                    _pageIndex = value;
                    ApplyingMapTiles();
                }
            }
        }

        /// <summary>
        ///  Binary array of map data to draw.
        /// </summary>
        public byte[,] MapFields { get; set; }

        /// <summary>
        ///  This is original formed binary data loaded into memory.
        /// </summary>
        public byte[] BinaryData { get; private set; } = [];


        /// <summary>
        ///  Please pass an byte array for drawing map fields.
        /// </summary>
        /// <param name="bytes">Byte type array</param>
        public MapFieldNavigator(byte[,] bytes)
        {
            MapFields = bytes;
            Clear();
        }

        /// <summary>
        ///  Delete the binary data enumeration of concealment.
        /// </summary>
        internal void Clear()
        {
            BinaryData = [];
            _pageIndex = 0;
        }

        /// <summary>
        ///  Stores the chips in the map field array.
        /// </summary>
        /// <param name="row">Row number of the array</param>
        /// <param name="col">Column number of the array</param>
        /// <param name="index">Tile address to be replaced</param>
        internal void ChangeMapTile(int row, int col, byte index)
        {
            if (0 <= row && row < MapFields.GetLength(0) && 0 <= col && col < MapFields.GetLength(1))
            {
                MapFields[row, col] = index;
            }
        }

        /// <summary>
        ///  Applying the map field's tile address.
        /// </summary>
        /// <returns>A logical value indicating whether the map address distribution is complete.</returns>
        private bool ApplyingMapTiles()
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                int targetAddress = BINARY_HEADER_SIZE + (BINARY_DATA_1PAGE_SIZE * PageIndex);
                byte[,] currentMapFields = MapFields;

                for (int i = 0; i < MapFields.GetLength(0); i++)
                {
                    for (int j = 0; j < MapFields.GetLength(1); j++)
                    {
                        if (BinaryData[targetAddress + (i * MapFields.GetLength(1)) + j] is byte data)
                        {
                            ChangeMapTile(i, j, data);
                        }
                        else
                        {
                            // If ArgumentOutOfRangeException occurs in BinaryData...
                            MapFields = currentMapFields;
                            MessageBox.Show("チップリストに含まれないバイナリバイト羅列が見つかったため、マップは表示できませんでした。", "お知らせ");
                            throw new Exception();
                        }
                    }
                }
            });
        }

        /// <summary>
        ///  Sets the binary array to be drawn in the field.
        /// </summary>
        /// <returns>True if the field information could be set.</returns>
        internal bool SetFieldData()
        {
            using BinaryMap binary = new();
            BinaryData = binary.BinaryFileOpener();
            if (0 < BinaryData.Length)
            {
                FieldName = binary.FilePath;
                return ApplyingMapTiles();
            }
            return false;
        }

        /// <summary>
        ///  Sets the binary array to be drawn in the field.
        /// </summary>
        internal void ReOpenFieldData()
        {
            if (null != _fieldName)
            {
                using BinaryMap binary = new();
                BinaryData = binary.BinaryFileOpener(_fieldName);
                _pageIndex = 0;
                _ = ApplyingMapTiles();
            }
        }

        /// <summary>
        ///  Gets the binary data byte at the specified position.
        /// </summary>
        /// <param name="page">Target page index</param>
        /// <param name="row">Target lines</param>
        /// <param name="column">Target columns</param>
        /// <returns>Data bytes.</returns>
        internal byte GetBinaryData(int page, int row, int column)
        {
            int address = (page * BINARY_DATA_1PAGE_SIZE) + BINARY_HEADER_SIZE + (row * BINARY_LINE_SIZE) + column;  // Calculate the location of a binary address.
            if (BinaryData.Length > address)
            {
                return GetBinaryData(address);
            }
            return byte.MinValue;
        }
        private byte GetBinaryData(int address) => BinaryData[address];

        /// <summary>
        ///  Updates the binary data corresponding to the edited map field.
        /// </summary>
        /// <param name="page">Target page index</param>
        /// <param name="row">Target lines</param>
        /// <param name="column">Target columns</param>
        /// <param name="value">Update value</param>
        /// <returns>True if the update is complete, false if there is a problem.</returns>
        internal bool UpdateBinaryData(int page, int row, int column, byte value)
        {
            int address = (page * BINARY_DATA_1PAGE_SIZE) + BINARY_HEADER_SIZE + (row * BINARY_LINE_SIZE) + column;  // Calculate the location of a binary address.
            if (address < BinaryData.Length)
            {
                UpdateBinaryData(address, value);
                // The ChangeMapTile method is executed only if the change is on the same page as the current page.
                if (page == PageIndex)
                {
                    ChangeMapTile(row, column, value);
                }
                return true;
            }
            return false;
        }
        private void UpdateBinaryData(int address, byte value) => BinaryData[address] = value;



        // Used to hold pre-input information for showPagesTextBox used when moving pages.
        // This is only manipulated by the ValidationInputPagesValues method. Anything else is not allowed.
        private string _previousPageText = "1";

        /// <summary>
        ///  Validate the input value in the page number <see cref="TextBox"/>.
        /// </summary>
        /// <param name="sender">showPagesTextBox object</param>
        /// <param name="maxPages">Maximum number of pages that can be set</param>
        internal void ValidationInputPagesValues(TextBox sender, int maxPages)
        {
            if (int.TryParse(sender.Text, out int number))
            {
                // If the input value is within the range, keep the value; if it is outside the range, restore the input value.
                if (number <= 0 || number > maxPages)
                {
                    System.Media.SystemSounds.Beep.Play();
                    sender.Text = _previousPageText;
                    sender.SelectionStart = sender.Text.Length;
                }
                else
                {
                    _previousPageText = sender.Text;
                }
            }
            else if (!string.IsNullOrEmpty(sender.Text))
            {
                System.Media.SystemSounds.Beep.Play();
                sender.Text = _previousPageText;
                sender.SelectionStart = sender.Text.Length;
            }
            else // Default behavior when sender.Text is empty.
            {
                _previousPageText = "1";
                sender.Text = _previousPageText;
            }
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
