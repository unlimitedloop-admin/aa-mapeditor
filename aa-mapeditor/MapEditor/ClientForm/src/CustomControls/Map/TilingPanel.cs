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
//      Last update     : 2023/10/15
//
//      File version    : 4
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.CustomControls.Chip;
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
        ///  Class for sharing images.
        /// </summary>
        private ChipManagedPanel? _chipManager = null;

        /// <summary>
        ///  An address book of image data chips arranged on a panel.
        /// </summary>
        public byte[,] MapTile { get; set; } = new byte[MAPFIELD_LINES, MAPFIELD_COLUMNS];

        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.


        public TilingPanel() { }

        /// <summary>
        ///  Inserts an instance of a required class into a private member.
        /// </summary>
        /// <param name="chipmanager">Class reference</param>
        public void SetPrimaryInstance(ref ChipManagedPanel chipmanager)
        {
            _chipManager = chipmanager;
        }

        /// <summary>
        ///  Complete the picture on the panel using the pieces from ImageList.
        ///  <para>Override <see cref="Control.OnPaint"/> for Panel controls.</para>
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (null != _chipManager && 0 < _chipManager.Count)
            {
                int tileWidth = TILE_SIZE;
                int tileHeight = TILE_SIZE;
                for (int y = 0; MapTile.GetLength(0) > y; y++)
                {
                    for (int x = 0; MapTile.GetLength(1) > x; x++)
                    {
                        byte imageIndex = MapTile[y, x];
                        Image? image = _chipManager.GetImageByIndex(imageIndex);
                        if (null != image)
                        {
                            e.Graphics.DrawImage(image, x * tileWidth, y * tileHeight);
                        }
                    }
                }
            }
        }
    }
}
