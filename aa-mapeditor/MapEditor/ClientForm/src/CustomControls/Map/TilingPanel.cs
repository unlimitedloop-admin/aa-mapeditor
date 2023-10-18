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
//      Last update     : 2023/10/18
//
//      File version    : 6
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.CustomControls.Chip;
using ClientForm.src.Exceptions;
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
        ///  A class that manages map data and provides guidance.
        /// </summary>
        internal MapFieldNavigator Navigator { get; private set; }

        /// <summary>
        ///  Class for sharing images.
        /// </summary>
        private ChipManagedPanel? _chipManager = null;

        /// <summary>
        ///  An address book of image data chips arranged on a panel.
        /// </summary>
        private readonly byte[,] _mapTile = new byte[MAPFIELD_LINES, MAPFIELD_COLUMNS];

        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.


        public TilingPanel()
        {
            Navigator = new(_mapTile);
        }

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

            if (string.IsNullOrEmpty(Navigator.FieldName)) return;

            _ = ExceptionHandler.TryCatchWithLogging(() =>
            {
                if (_chipManager == null || _chipManager.Count <= 0) return;

                int tileWidth = TILE_SIZE;
                int tileHeight = TILE_SIZE;

                for (int y = 0; y < _mapTile.GetLength(0); y++)
                {
                    for (int x = 0; x < _mapTile.GetLength(1); x++)
                    {
                        byte imageIndex = _mapTile[y, x];
                        Image? image = _chipManager.GetImageByIndex(imageIndex);
                        if (image != null)
                        {
                            e.Graphics.DrawImage(image, x * tileWidth, y * tileHeight);
                        }
                    }
                }
            });
        }
    }
}
