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
//      Last update     : 2023/10/22
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Exceptions;
using ClientForm.src.Logger;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  A memory class that reads binary files and manages map data.
    /// </summary>
    internal class BinaryMap : IDisposable
    {
        /// <summary>
        ///  Original obtained from the selected binary data file.
        /// </summary>
        public byte[] BinaryData { get; private set; }

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


        internal BinaryMap()
        {
            BinaryData = Array.Empty<byte>();
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal bool BinaryFileOpener()
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                FilePath = openbin.FileName;
                return FileOpen();
            }
            else
            {
                return false;
            }
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
        ///  Extracts the binary data at the specified position.
        /// </summary>
        /// <param name="offset">Sequence number</param>
        /// <returns>binary data address (byte).</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal byte? GetBinaryData(int offset)
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                if (0 > BinaryData.Length || BinaryData.Length <= offset)
                {
                    // TODO : 例外発生後の挙動について要検証
                    DefaultLogger.LogError("不測のメモリアクセス違反がありました。_binaryDataのサイズ：[" + BinaryData.Length.ToString() + "]、アクセス要求されたアドレス：[" + offset + "]");
                    throw new ArgumentOutOfRangeException(nameof(offset), "The provided offset is out of the range of the binary data.");
                }
            })
                ? BinaryData[offset]
                : null;
        }

        /// <summary>
        ///  Disposable.
        /// </summary>
        public void Dispose()
        {
            _binaryReader?.Dispose();
            _fileStream?.Dispose();
        }
    }
}
