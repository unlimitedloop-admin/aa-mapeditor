/**************************************************************/
//
//
//      Copyright (c) 20XX UNLIMITED LOOP ROOT-ONE
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
//      File name       : MapFieldTile.cs
//
//      Author          : u7
//
//      Last update     : yyyy/mm/dd
//
//      File version    : -
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.app.capsules
{
    internal class MapFieldTile : PictureBox
    {
        public byte ChipAddress { get; set; }

        public string ChipAddressText { get; set; } = string.Empty;

        private byte _alphaColor = byte.MaxValue;

        public byte AlphaColor
        {
            get { return _alphaColor; }
            set
            {
                if (value != _alphaColor)
                {
                    _alphaColor = value;
                    ChangeAlphaLevelForImage();
                }
            }
        }


        private void ChangeAlphaLevelForImage()
        {
            Bitmap bitmap = new(Image.Width, Image.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    // Changing the RGB values to semi-transparent.
                    Color originalcolor = bitmap.GetPixel(i, j);
                    Color semitransparentcolor = Color.FromArgb(_alphaColor, originalcolor.R, originalcolor.G, originalcolor.B);
                    bitmap.SetPixel(i, j, semitransparentcolor);
                }
            }
        }
    }
}
