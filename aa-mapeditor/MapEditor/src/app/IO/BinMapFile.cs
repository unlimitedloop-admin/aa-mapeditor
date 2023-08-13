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
//      Last update     : 2023/08/13
//
//      File version    : 5
//
//
/**************************************************************/

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
        public bool FileOpen(string path)
        {
            try
            {
                // Check the existence of the file and place the contents of the file in memory.
                if (!File.Exists(path)) { return false; }
                using var fs = File.OpenRead(path);
                var binary = new BinaryReader(fs);
                long len = fs.Length;
                byte[] data = new byte[len];
                binary.Read(data, 0, (int)len);
                _data = data;
                FilePath = path;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("選択されたファイルは空であるか、読み取れないようです。");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        /// <param name="rectangle">Text box scaler</param>
        /// <returns>Generated <see cref="TextBox"/> object.</returns>
        internal TextBox CreateMapTextBox(int address, Size rectangle, Font? font = null)
        {
            Font default_font = new("Yu Gothic UI", 12, FontStyle.Regular);
            Font selected_font = font ?? default_font;
            
            var picx = new TextBox()
            {
                Text = (GetDataByte(address)?.ToString("X2")) ?? "",
                Size = new(rectangle.Width, rectangle.Height),
                Margin = new(0),
                BackColor = SystemColors.Control,
                TextAlign = HorizontalAlignment.Center,
                Multiline = true,
                Font = selected_font,
            };
            return picx;
        }

        /// <summary>
        ///  Generate a <seealso cref="PictureBox"/> to place the graphics chip.
        /// </summary>
        /// <param name="address">Hex number to graphic list number</param>
        /// <param name="image">Graphic image <seealso cref="Image"/></param>
        /// <param name="rectangle">Graphics chip size</param>
        /// <returns>Generated <seealso cref="PictureBox"/> object.</returns>
        internal static PictureBox CreateTextureBox(int address, Image? image, Size rectangle)
        {
            var picx = new PictureBox()
            {
                Name = "Texture_X" + address.ToString(),
                Size = rectangle,
                Margin = new(0),
                BackgroundImage = image,
            };
            return picx;
        }
    }
}
