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
//      Last update     : 2023/10/18
//
//      File version    : 1
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
    internal class BinaryMap
    {
        /// <summary>
        ///  Original obtained from the selected binary data file.
        /// </summary>
        private byte[] _binaryData;

        /// <summary>
        ///  Path of the selected file.
        /// </summary>
        public string FilePath { get; private set; } = string.Empty;


        internal BinaryMap()
        {
            _binaryData = Array.Empty<byte>();
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal bool BinaryFileOpener()
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
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
                using FileStream fs = File.OpenRead(FilePath);
                BinaryReader binary = new(fs);
                long len = fs.Length;
                byte[] data = new byte[len];
                _ = binary.Read(data, 0, (int)len);
                _binaryData = data;
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
                if (0 > _binaryData.Length || _binaryData.Length <= offset)
                {
                    // TODO : 例外発生後の挙動について要検証
                    DefaultLogger.LogError("不測のメモリアクセス違反がありました。_binaryDataのサイズ：[" + _binaryData.Length.ToString() + "]、アクセス要求されたアドレス：[" + offset + "]");
                    throw new ArgumentOutOfRangeException(nameof(offset), "The provided offset is out of the range of the binary data.");
                }
            })
                ? _binaryData[offset]
                : null;
        }
    }
}
