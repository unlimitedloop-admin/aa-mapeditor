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
//      File name       : BinMapFile.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/30
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.logger;



/* sources */
namespace MapEditor.src.app.IO
{
    /// <summary>
    ///  File IO class for stage maps.
    /// </summary>
    internal class BinMapFile : IStandardFileIO
    {
        /// <summary>
        ///  Binary file source path.
        /// </summary>
        public string FilePath { protected set; get; } = string.Empty;

        /// <summary>
        ///  Binary file name label.
        /// </summary>
        public string Name { protected set; get; }

        /// <summary>
        ///  Array of binary file data.
        /// </summary>
        private byte[]? _data;

        /// <summary>
        ///  Cache collection of graphics data.
        /// </summary>
        private readonly Dictionary<int, Bitmap> _semiTransparentCache = new();
        private readonly Dictionary<int, Bitmap> _opaqueCache = new();


        /// <summary>
        ///  This is the constructor for BinMapFile.
        /// </summary>
        /// <param name="name">Binary file name label</param>
        internal BinMapFile(string name)
        {
            Name = name;
            _data = Array.Empty<byte>();
        }

        /// <summary>
        ///  Gets the data length of the binary data being stored in memory.
        /// </summary>
        /// <returns>An integer for the data length, 0 if null.</returns>
        internal int GetDataLength()
        {
            return _data?.Length ?? 0;
        }

        /// <summary>
        ///  Opens the specified binary file and reads it into memory.
        /// </summary>
        /// <param name="path">Specify the full path of the binary file</param>
        /// <returns>When the file is successfully opened, true is returned.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public bool FileOpen(string path)
        {
            try
            {
                // Check the existence of the file and place the contents of the file in memory.
                if (!File.Exists(path))
                    return false;

                using var fs = File.OpenRead(path);
                var binary = new BinaryReader(fs);
                long len = fs.Length;
                byte[] data = new byte[len];
                binary.Read(data, 0, (int)len);
                _data = data;
                FilePath = path;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("The selected file appears to be empty or unreadable. Is there a mistake in the file?", "UNEXPECTED EXCEPTION INFO");
                DefaultLogger.LogError(ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UNEXPECTED EXCEPTION INFO");
                DefaultLogger.LogError(ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        ///  Clears the data loaded in memory.
        /// </summary>
        /// <param name="name">Target file name</param>
        /// <returns>When the file is successfully closed, true is returned.</returns>
        public bool FileClose(string name)
        {
            if (null != _data && name == Name)
            {
                _data = null;
                FilePath = string.Empty;
                Name = string.Empty;
            }
            return true;
        }

        /// <summary>
        ///  Writes data to a specified address in a binary file.
        /// </summary>
        /// <param name="address">Address number in bytes to write</param>
        /// <param name="value">Value to write (hexadecimal)</param>
        internal void SetDataByte(int address, byte value)
        {
            if (null != _data && address < _data.Length)
            {
                _data[address] = value;
            }
        }

        /// <summary>
        ///  Gets the value of the specified address.
        /// </summary>
        /// <param name="address">Address number in bytes to read</param>
        /// <returns>Binary data bytes.</returns>
        internal byte? GetDataByte(int address)
        {
            if (null != _data && address < _data.Length)
            {
                return _data[address];
            }
            return null;
        }

        /// <summary>
        ///  Create a <see cref="TextBox"/> object to be any placed.
        /// </summary>
        /// <param name="address">Hex number to write in the textbox</param>
        /// <param name="scales">Text box scaler</param>
        /// <returns>Generated <see cref="TextBox"/> object.</returns>
        internal TextBox CreateMapTextBox(int address, Size scales, Font? font = null)
        {
            Font defaultFont = new("Yu Gothic UI", 12, FontStyle.Regular);
            Font selectedFont = font ?? defaultFont;

            TextBox pict = new()
            {
                Text = (GetDataByte(address)?.ToString("X2")) ?? "",
                Size = new(scales.Width, scales.Height),
                Margin = new(0),
                BackColor = SystemColors.Control,
                TextAlign = HorizontalAlignment.Center,
                Multiline = true,
                Font = selectedFont,
            };
            return pict;
        }

        /// <summary>
        ///  Generate a <seealso cref="PictureBox"/> to place the graphics chip.
        /// </summary>
        /// <param name="address">Hex number to graphic list number</param>
        /// <param name="image">Graphic <seealso cref="Image"/></param>
        /// <param name="rectangle">Graphics chip size</param>
        /// <returns>Generated <seealso cref="PictureBox"/> object.</returns>
        internal static PictureBox CreateTextureBox(int address, Image? image, Size rectangle)
        {
            Bitmap bitmap = (Bitmap)image!;
            PictureBox pict = new()
            {
                Name = "Texture_X" + address.ToString(),
                Size = rectangle,
                Margin = new(0),
                Image = bitmap,
            };
            return pict;
        }

        /// <summary>
        ///  Creates a no transparent version of the provided bitmap image.
        /// </summary>
        /// <param name="original">The original image data used for bitmapization.</param>
        /// <returns>Semi-transparent image data <see cref="Bitmap"/>.</returns>
        internal Bitmap MakeImageOpaque(Bitmap original)
        {
            int hash = original.GetHashCode();
            if (_opaqueCache.TryGetValue(hash, out Bitmap? cacheBitmap) && null != cacheBitmap)
            {
                return cacheBitmap;
            }
            Bitmap bitmap = new(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    // Changing the RGB values to semi-transparent.
                    Color originalColor = original.GetPixel(i, j);
                    Color brightlycolor = Color.FromArgb(255, originalColor.R, originalColor.G, originalColor.B);
                    bitmap.SetPixel(i, j, brightlycolor);
                }
            }
            _opaqueCache[hash] = bitmap;
            return bitmap;
        }

        /// <summary>
        ///  Creates a semi-transparent version of the provided <see cref="Bitmap"/>.
        /// </summary>
        /// <param name="original">The original image data used for bitmapization.</param>
        /// <returns>Semi-transparent image data <see cref="Bitmap"/>.</returns>
        internal Bitmap MakeImageSemiTransparent(Bitmap original)
        {
            int hash = original.GetHashCode();
            if (_semiTransparentCache.TryGetValue(hash, out Bitmap? cacheBitmap) && null != cacheBitmap)
            {
                return cacheBitmap;
            }
            Bitmap semitransparentBitmap = new(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    // Changing the RGB values to semi-transparent.
                    Color originalColor = original.GetPixel(i, j);
                    Color semitransparentColor = Color.FromArgb(128, originalColor.R, originalColor.G, originalColor.B);
                    semitransparentBitmap.SetPixel(i, j, semitransparentColor);
                }
            }
            _semiTransparentCache[hash] = semitransparentBitmap;
            return semitransparentBitmap;
        }
    }
}
