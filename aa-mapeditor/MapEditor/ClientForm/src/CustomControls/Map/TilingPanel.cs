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
//      File name       : TilingPanel.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.CustomControls.Map
{
    /// <summary>
    ///  A panel object that performs tiling drawing of graphics.
    /// </summary>
    public partial class TilingPanel : Panel
    {
        /// <summary>
        ///  Array data of the picture to be painted on the tile.
        /// </summary>
        public List<Image> ImageList { get; set; } = new();

        /// <summary>
        ///  An address book of image data chips arranged on a panel.
        /// </summary>
        public byte[,] MapTile { get; set; } = new byte[MAPFIELD_LINES, MAPFIELD_COLUMNS];

        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.


        public TilingPanel() { }

        /// <summary>
        ///  Complete the picture on the panel using the pieces from ImageList.
        ///  <para>Override <see cref="Control.OnPaint"/> for Panel controls.</para>
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int tileWidth = TILE_SIZE;
            int tileHeight = TILE_SIZE;
            for (int y = 0; MapTile.GetLength(0) > y; y++)
            {
                for (int x = 0; MapTile.GetLength(1) > x; x++)
                {
                    byte imageIndex = MapTile[y, x];
                    if (ImageList.Count > imageIndex)
                    {
                        e.Graphics.DrawImage(ImageList[imageIndex], x * tileWidth, y * tileHeight);
                    }
                }
            }
        }
    }
}
