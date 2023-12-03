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
//      File name       : BinaryArrayData.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/03
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Configs;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  This is an interface that provides functionality to read and write the contents of binary data.
    /// </summary>
    public interface IBinaryArrayData
    {
        int Length { get; }
        int PageSize { get; }
        virtual void Reset() { }
        virtual byte[] Get() => [];
        virtual byte Get(int index) => 0;
        virtual void Set(byte[] bytes) { }
        virtual void Set(int index, byte value) { }
        virtual byte GetBinaryData(int page, int row, int column) { return 0; }
        virtual void SetBinaryData(int page, int row, int column, byte value) { }
    }

    /// <summary>
    ///  This is an interface that holds information about binary files.
    /// </summary>
    public interface IBinaryFile
    {
        public string BinFileName { get; set; }
        public event Action<string>? BinFileNameChanged;
    }



    /// <summary>
    ///  Concrete class that implements <see cref="IBinaryArrayData"/>, <see cref="IBinaryFile"/> interface.
    /// </summary>
    public class BinaryArrayData : IBinaryArrayData, IBinaryFile
    {
        private string _binFileName = string.Empty;
        private byte[] _binaryData = [];

        /// <summary>
        ///  Binary file path.
        /// </summary>
        public string BinFileName
        {
            get => _binFileName;
            set
            {
                if (_binFileName != value)
                {
                    _binFileName = value;
                    OnBinFileNameChanged();
                }
            }
        }


        public BinaryArrayData() { }

        public int Length => _binaryData.Length;

        /// <summary>
        ///  Number of pages of binary data divided by 0x100.
        /// </summary>
        public int PageSize => _binaryData.Length / CoreConstants.BINARY_DATA_1PAGE_SIZE;

        public void Reset()
        {
            _binaryData = [];
        }

        public byte[] Get() => _binaryData;

        public byte Get(int index)
        {
            return _binaryData[index];
        }

        public void Set(byte[] bytes)
        {
            _binaryData = bytes;
        }

        public void Set(int index, byte value)
        {
            _binaryData[index] = value;
        }

        /// <summary>
        ///  Gets the binary data byte at the specified position.
        /// </summary>
        /// <param name="page">Target page index</param>
        /// <param name="row">Target lines</param>
        /// <param name="column">Target columns</param>
        /// <returns>Data bytes.</returns>
        public byte GetBinaryData(int page, int row, int column)
        {
            int address = GetAddress(page, row, column);  // Calculate the location of a binary address.
            if (Length > address)
            {
                return Get(address);
            }
            return byte.MinValue;
        }

        /// <summary>
        ///  Updates the binary data corresponding to the edited map field.
        /// </summary>
        /// <param name="page">Target page index</param>
        /// <param name="row">Target lines</param>
        /// <param name="column">Target columns</param>
        /// <param name="value">Update value</param>
        public void SetBinaryData(int page, int row, int column, byte value)
        {
            int address = GetAddress(page, row, column);  // Calculate the location of a binary address.
            if (address < Length)
            {
                Set(address, value);
            }
        }

        private static int GetAddress(int page, int row, int column)
        {
            return (page * CoreConstants.BINARY_DATA_1PAGE_SIZE) + CoreConstants.BINARY_HEADER_SIZE + (row * CoreConstants.BINARY_LINE_SIZE) + column;
        }


        /// <summary>
        ///  Event when BinFileName is changed.
        /// </summary>
        public event Action<string>? BinFileNameChanged;

        /// <summary>
        ///  Event when BinFileName is changed. (virtual method)
        /// </summary>
        protected virtual void OnBinFileNameChanged()
        {
            BinFileNameChanged?.Invoke(_binFileName);
        }
    }
}
