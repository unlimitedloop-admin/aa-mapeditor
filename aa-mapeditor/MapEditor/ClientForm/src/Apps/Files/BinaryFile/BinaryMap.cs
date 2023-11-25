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
//      File name       : BinaryMap.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/25
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Exceptions;



/* sources */
namespace ClientForm.src.Apps.Files.BinaryFile
{
    /// <summary>
    ///  A memory class that reads binary files and manages map data.
    /// </summary>
    internal class BinaryMap : IDisposable
    {
        /// <summary>
        ///  It's an asynchronous file stream of binary data that you're reading.
        /// </summary>
        private FileStream? _fileStream;

        /// <summary>
        ///  A storage structure for reading binary file data.
        /// </summary>
        private BinaryReader? _binaryReader;

        /// <summary>
        ///  Path of the selected file.
        /// </summary>
        public string FilePath { get; private set; } = string.Empty;

        /// <summary>
        ///  Original obtained from the selected binary data file.
        /// </summary>
        public byte[] BinaryData { get; private set; }


        internal BinaryMap()
        {
            BinaryData = [];
        }

        internal BinaryMap(byte[] bytes)
        {
            BinaryData = bytes;
        }

        /// <summary>
        ///  The process of opening a binary file.
        /// </summary>
        /// <returns>True if successful.</returns>
        private bool FileOpen()
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                _fileStream = File.OpenRead(FilePath);
                _binaryReader = new BinaryReader(_fileStream);
                long len = _fileStream.Length;
                byte[] data = new byte[len];
                _ = _binaryReader.Read(data, 0, (int)len);
                BinaryData = data;
            });
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <returns>Binary data of the opened file.</returns>
        internal byte[] BinaryFileOpener()
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                FilePath = openbin.FileName;
                if (!FileOpen())
                {
                    return [];
                }
            }
            return BinaryData;
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <param name="filePath">File path to open</param>
        /// <returns>Binary data of the opened file.</returns>
        internal byte[] BinaryFileOpener(string filePath)
        {
            BinaryData = [];
            FilePath = filePath;
            return !FileOpen() ? ([]) : BinaryData;
        }

        /// <summary>
        ///  Writes a BinaryData byte string to a file as binary data.
        /// </summary>
        /// <param name="filepath">Target file path</param>
        /// <param name="offset">Number of bytes to start writing binary data</param>
        /// <param name="length">Length of bytes to write</param>
        /// <returns>True if the operation is complete.</returns>
        private bool FileWrite(string filepath, int offset, int length)
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                using FileStream fileStream = new(filepath, FileMode.Create);
                fileStream.Write(BinaryData, offset, length);
            });
        }

        /// <summary>
        ///  Save the binary file.
        /// </summary>
        /// <param name="filePath">File path to save</param>
        /// <returns>Saved file path.</returns>
        internal string SaveBinaryFile(string filePath)
        {
            return !FileWrite(filePath, 0, BinaryData.Length) ? string.Empty : filePath;
        }

        /// <summary>
        ///  Disposing instance.
        /// </summary>
        public void Dispose()
        {
            _binaryReader?.Dispose();
            _fileStream?.Dispose();
        }
    }
}
