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
//      Last update     : 2023/10/22
//
//      File version    : 7
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.CustomControls.Chip;
using ClientForm.src.Exceptions;
using static ClientForm.src.Configs.CoreConstants;
using static ClientForm.src.Configs.CustomColor;



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
        private ChipManagedPanel? _chipManager;

        /// <summary>
        ///  An address book of image data chips arranged on a panel.
        /// </summary>
        private readonly byte[,] _mapTile = new byte[MAPFIELD_LINES, MAPFIELD_COLUMNS];

        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.
        private const string TOOLTIP_TEXT = "このパネルをダブルクリックしてマップの読込を開始します。";
        private readonly ToolTip _toolTip = new();  // For annotation.


        public TilingPanel()
        {
            Navigator = new(_mapTile);
            Navigator.FieldNameChanged += Navigator_FieldNameChanged;
            _toolTip.SetToolTip(this, TOOLTIP_TEXT);
            DoubleBuffered = true;
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
        ///  Complete the picture on the panel using the pieces from <see cref="List{T}"/>Image.
        /// </summary>
        /// <param name="e">Override <see cref="Control.OnPaint"/> for Panel controls.</param>
        private void TileDrawer(PaintEventArgs e)
        {
            _ = ExceptionHandler.TryCatchWithLogging(() =>
            {
                if (_chipManager == null || _chipManager.Count <= 0 || string.IsNullOrEmpty(Navigator.FieldName))
                {
                    return;
                }

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

        /// <summary>
        ///  OnPaint of TilingPanel event handler.
        ///  <para>Override <see cref="Control.OnPaint"/> for Panel controls.</para>
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            TileDrawer(e);
        }

        /// <summary>
        ///  Event fired when the map field is clicked.
        /// </summary>
        /// <param name="point">The mouse coordinate point you clicked</param>
        private void MapFieldClick(Point point)
        {
            int clickedTileX = point.X / TILE_SIZE;
            int clickedTileY = point.Y / TILE_SIZE;
            int chipindex = _chipManager!.ChoiceChipNumber;
            if (0 <= chipindex && byte.MaxValue >= chipindex && Navigator.ChangeMapTile(clickedTileY, clickedTileX, (byte)chipindex))
            {
                SuspendLayout();
                Rectangle invalidateRect = new(clickedTileX * TILE_SIZE, clickedTileY * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                Invalidate(invalidateRect);
                ResumeLayout();
            }
        }

        /// <summary>
        ///  OnClick of TilingPanel event handler.
        ///  <para>Override <see cref="Control.OnClick"/> for Panel controls.</para>
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            MapFieldClick(PointToClient(Cursor.Position));
        }

        /// <summary>
        ///  Event listener when MapFieldNavigator's file name changes.
        /// </summary>
        private void Navigator_FieldNameChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Navigator.FieldName))
            {
                BackColor = SystemColors.AppWorkspace;
                _toolTip.Active = true;
            }
            else
            {
                BackColor = LightGreen;
                _toolTip.Active = false;
            }
        }

        /// <summary>
        ///  Destroys the binary data of MapFieldPanel.
        /// </summary>
        internal void DestroyMapField()
        {
            for (int i = 0; i < MAPFIELD_LINES; i++)
            {
                for (int j = 0; j < MAPFIELD_COLUMNS; j++)
                {
                    _mapTile[i, j] = 0;
                }
            }
            Navigator.FieldName = string.Empty;
            Navigator.Clear();
        }
    }
}
