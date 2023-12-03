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
//      Last update     : 2023/12/03
//
//      File version    : 13
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.CustomControls.Chip;
using ClientForm.src.Exceptions;
using ClientForm.src.Gems.Command;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.CustomControls.Map
{
    /// <summary>
    ///  A panel object that performs tiling drawing of graphics.
    /// </summary>
    public partial class TilingPanel : Panel
    {
        private ChipManagedPanel? _chipManager;
        private RecordSupervision? _memento;

        // Dependency injection of members for map field access.
        private IBinaryArrayData? _binaryArrayData;
        private IMapFieldViewer? _mapField;
        private IPageIndex? _pageIndex;

        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.
        private const string TOOLTIP_TEXT = "このパネルをダブルクリックしてマップの読込を開始します。";
        private readonly ToolTip _toolTip = new();  // For annotation.

        /// <summary>
        ///  Specifies the activation of the tooltip.
        /// </summary>
        /// <param name="isEnabled">Enabled boolean value</param>
        internal void SetToolTipActivate(bool isEnabled) => _toolTip.Active = isEnabled;


        public TilingPanel()
        {
            _toolTip.SetToolTip(this, TOOLTIP_TEXT);
            DoubleBuffered = true;
        }

        /// <summary>
        ///  Inserts an instance of a required class into a private member.
        /// </summary>
        /// <param name="chipmanager">Class reference</param>
        /// <param name="memento">Class reference</param>
        /// <param name="fields"><see cref="IMapFieldViewer"/> interface for DI container</param>
        /// <param name="binaryArray"><see cref="IBinaryArrayData"/> interface for DI container</param>
        /// <param name="pageIndex"><see cref="IPageIndex"/> interface for DI container</param>
        public void SetPrimaryInstance(ref ChipManagedPanel chipmanager, ref RecordSupervision memento, IMapFieldViewer fields, IBinaryArrayData binaryArray, IPageIndex pageIndex)
        {
            _chipManager = chipmanager;
            _memento = memento;
            _mapField = fields;
            _binaryArrayData = binaryArray;
            _pageIndex = pageIndex;
        }

        /// <summary>
        ///  Complete the picture on the panel using the pieces from <see cref="List{T}"/>Image.
        /// </summary>
        /// <param name="e">Override <see cref="Control.OnPaint"/> for Panel controls.</param>
        private void TileDrawer(PaintEventArgs e)
        {
            _ = ExceptionHandler.TryCatchWithLogging(() =>
            {
                // Exit if the graphic list is empty.
                if (_chipManager == null || _chipManager.Count <= 0 || 0 >= _binaryArrayData!.Length) return;

                int tileWidth = TILE_SIZE;
                int tileHeight = TILE_SIZE;

                for (int y = 0; y < _mapField!.MapFields.GetLength(0); y++)
                {
                    for (int x = 0; x < _mapField!.MapFields.GetLength(1); x++)
                    {
                        byte imageIndex = _mapField!.MapFields[y, x];
                        Image? image = _chipManager!.GetImageByIndex(imageIndex);
                        if (image != null)
                        {
                            e.Graphics.DrawImage(image, x * tileWidth, y * tileHeight);
                        }
                    }
                }
                if (null == _rangeTool)
                {
                    _rangeTool = new(this);     // Activates the selection tool when all tiles are filled.
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
            DrawRangeTool(e);
        }

        /// <summary>
        ///  Event fired when the map field is selected.
        /// </summary>
        /// <param name="start">starting point of selection</param>
        /// <param name="end">end of selection</param>
        private void MapTileChange(Point start, Point? end = null)
        {
            _ = ExceptionHandler.TryCatchWithLogging(() =>
            {
                // Exit if the graphic list is empty.
                if (null == _chipManager?.ChoiceChip || 0 >= _binaryArrayData!.Length) return;

                Point endPoint = end ?? start;  // If end is null, start will be used.

                int startTileX = start.X / TILE_SIZE;
                int startTileY = start.Y / TILE_SIZE;
                int endTileX = endPoint.X / TILE_SIZE;
                int endTileY = endPoint.Y / TILE_SIZE;
                byte chipindex = (byte)_chipManager!.ChoiceChipNumber;

                Point startPoint = new(startTileX, startTileY);
                Point finalEndPoint = new(endTileX, endTileY);
                var command = new MapTileChangeCommand(this, _pageIndex!.PageIndex, startPoint, finalEndPoint, chipindex);
                command.Execute();
                _memento!.PushUndoStack(command);
            });
        }

        /// <summary>
        ///  Get map chip information for the specified location.
        /// </summary>
        /// <param name="page">Target page index to retrieve</param>
        /// <param name="row">Number of target tile rows to retrieve</param>
        /// <param name="column">Number of target tile columns to retrieve</param>
        /// <returns>Tile number of binary data.</returns>
        internal byte GetBinaryData(int page, int row, int column)
        {
            return _binaryArrayData!.GetBinaryData(page, row, column);
        }

        /// <summary>
        ///  Rewrites the binary data at the specified map position.
        /// </summary>
        /// <param name="page">Target page index to retrieve</param>
        /// <param name="row">Number of target tile rows to retrieve</param>
        /// <param name="column">Number of target tile columns to retrieve</param>
        /// <param name="value">Set the value</param>
        internal void UpdateBinaryData(int page, int row, int column, byte value)
        {
            _binaryArrayData!.SetBinaryData(page, row, column, value);
            // The ChangeMapTile method is executed only if the change is on the same page as the current page.
            if (page == _pageIndex!.PageIndex)
            {
                _mapField!.ChangeMapTile(row, column, value);
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
                    _mapField!.MapFields[i, j] = 0;
                }
            }
            _rangeTool = null;
        }
    }
}
