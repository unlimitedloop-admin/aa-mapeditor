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
//      Last update     : 2023/12/03
//
//      File version    : 7
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Exceptions;
using ClientForm.src.Logger;



/* sources */
namespace ClientForm.src.Apps.Files.BinaryFile
{
    /// <summary>
    ///  A static class that provides functionality for reading and writing binary files.
    /// </summary>
    internal static class BinaryMap
    {
        /// <summary>
        ///  The process of opening a binary file.
        /// </summary>
        /// <returns>Byte array for binary data file.</returns>
        private static byte[] FileOpen(string filepath)
        {
            try
            {
                using var fileStream = File.OpenRead(filepath);
                using var binaryReader = new BinaryReader(fileStream);
                long len = fileStream.Length;
                return binaryReader.ReadBytes((int)len);
            }
            catch (Exception ex)
            {
                DefaultLogger.LogError(ex.Message);
                return [];  // Returns an empty byte array if an error occurs.
            }
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <returns>Binary data of the opened file.</returns>
        internal static byte[] BinaryFileOpener(out string filePath)
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                filePath = openbin.FileName;
                return FileOpen(filePath);
            }
            filePath = string.Empty;
            return [];
        }

        /// <summary>
        ///  Hosts the dialog to open a binary file.
        /// </summary>
        /// <param name="filePath">File path to open</param>
        /// <returns>Binary data of the opened file.</returns>
        internal static byte[] BinaryFileOpener(string filePath)
        {
            return FileOpen(filePath);
        }

        /// <summary>
        ///  Writes a BinaryArrayData byte string to a file as binary data.
        /// </summary>
        /// <param name="filepath">Target file path</param>
        /// <param name="data"></param>
        /// <param name="offset">Number of bytes to start writing binary data</param>
        /// <param name="length">Length of bytes to write</param>
        /// <returns>True if the operation is complete.</returns>
        private static bool FileWrite(string filepath, byte[] data, int offset, int length)
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                using FileStream fileStream = new(filepath, FileMode.Create);
                fileStream.Write(data, offset, length);
            });
        }

        /// <summary>
        ///  Save the binary file.
        /// </summary>
        /// <param name="bytes">Binary data array to write</param>
        /// <returns>Saved binary file path.</returns>
        internal static string SaveBinaryFile(byte[] bytes)
        {
            if (0 < bytes.Length)
            {
                using SaveFileDialog saveBin = new()
                {
                    Filter = "binファイル|*bin",
                    Title = "名前を付けて保存",
                };
                if (saveBin.ShowDialog() == DialogResult.OK)
                {
                    return !FileWrite(saveBin.FileName, bytes, 0, bytes.Length) ? string.Empty : saveBin.FileName;
                }
            }
            return string.Empty;
        }
    }
}
