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
//      File name       : MapTileChangeCommand.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/18
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.CustomControls.Map;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Gems.Command
{
    /// <summary>
    ///  Command class for operations that change the <see cref="Image"/> of the <see cref="TilingPanel"/>.
    /// </summary>
    internal class MapTileChangeCommand : Command
    {
        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.
        
        // Resource.
        private readonly TilingPanel _targets;
        private readonly int _pagesIndex;
        private readonly Point _startCell;
        private readonly Point _endCell;
        private readonly byte _newTileIndex;
        private readonly List<byte> _oldTileIndex = new();


        /// <summary>
        ///  Setting command parameter.
        /// </summary>
        /// <param name="targets">MapTile <see cref="Panel"/></param>
        /// <param name="pagesIndex">Target page index</param>
        /// <param name="start">Start the cell address</param>
        /// <param name="end">End point the cell address</param>
        /// <param name="newTileIndex">Index number of the tile to change</param>
        public MapTileChangeCommand(TilingPanel targets, int pagesIndex, Point start, Point end, byte newTileIndex)
        {
            _targets = targets;
            _pagesIndex = pagesIndex;
            _startCell = start;
            _endCell = end;
            _newTileIndex = newTileIndex;
        }

        /// <summary>
        ///  Execute command.
        /// </summary>
        public override void Execute() => ChangeMapTiles(true);

        /// <summary>
        ///  Cancel execution of a command.
        /// </summary>
        public override void Undo() => ChangeMapTiles(false);

        /// <summary>
        ///  Changes the map tiles within the specified range of cell locations.
        /// </summary>
        /// <param name="flag">Specify true to embed _newTileIndex, and specify false to return _oldTileIndex data</param>
        private void ChangeMapTiles(bool flag)
        {
            Point startPoint = new(
                Math.Min(_startCell.X, _endCell.X),
                Math.Min(_startCell.Y, _endCell.Y)
            );
            Point endPoint = new(
                Math.Max(_startCell.X, _endCell.X),
                Math.Max(_startCell.Y, _endCell.Y)
            );

            int index = 0;
            for (int row = startPoint.Y; row <= endPoint.Y; row++)
            {
                for (int col = startPoint.X; col <= endPoint.X; col++)
                {
                    if (flag)
                    {
                        // Redo (Execute command)
                        _oldTileIndex.Add(_targets.Navigator.GetBinaryData(_pagesIndex, row, col));
                        _targets.Navigator.UpdateBinaryData(_pagesIndex, row, col, _newTileIndex);  // TODO : バイナリデータへ設定できなかった場合はどうしますか？
                    }
                    else
                    {
                        // Undo
                        _targets.Navigator.UpdateBinaryData(_pagesIndex, row, col, _oldTileIndex[index]);  // TODO : バイナリデータへ設定できなかった場合はどうしますか？
                    }
                    index++;
                }
            }
            RefreshTheRectInTargets(startPoint, endPoint);
        }

        /// <summary>
        ///  Refreshes the panel display of the changed tile map part.
        /// </summary>
        /// <param name="startPoint">Starting cell</param>
        /// <param name="endPoint">Ending cell</param>
        private void RefreshTheRectInTargets(Point startPoint, Point endPoint)
        {
            int x = startPoint.X * TILE_SIZE;
            int y = startPoint.Y * TILE_SIZE;
            int width = (endPoint.X - startPoint.X + 1) * TILE_SIZE;
            int height = (endPoint.Y - startPoint.Y + 1) * TILE_SIZE;
            
            _targets.SuspendLayout();
            Rectangle invalidateRect = new(x, y, width, height);
            _targets.Invalidate(invalidateRect);
            _targets.ResumeLayout();
        }
    }
}
