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
//      Last update     : 2023/10/28
//
//      File version    : 1
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
        private readonly Point _startCell;
        private readonly Point _endCell;
        private readonly byte _newTileIndex;
        private readonly byte _oldTileIndex;


        /// <summary>
        ///  Setting command parameter.
        /// </summary>
        /// <param name="targets">MapTile <see cref="Panel"/></param>
        /// <param name="start">Start the cell address</param>
        /// <param name="end">End point the cell address</param>
        /// <param name="newTileIndex">Index number of the tile to change</param>
        /// <param name="oldTileIndex">The index number of the tile before the change</param>
        public MapTileChangeCommand(TilingPanel targets, Point start, Point end, byte newTileIndex, byte oldTileIndex)
        {
            _targets = targets;
            _startCell = start;
            _endCell = end;
            _newTileIndex = newTileIndex;
            _oldTileIndex = oldTileIndex;
        }

        /// <summary>
        ///  Execute command.
        /// </summary>
        public override void Execute() => ChangeMapTiles(_newTileIndex);

        /// <summary>
        ///  Cancel execution of a command.
        /// </summary>
        public override void Undo() => ChangeMapTiles(_oldTileIndex);

        /// <summary>
        ///  Changes the map tiles within the specified range of cell locations.
        /// </summary>
        /// <param name="tileindex">Index number of the tilemap to change</param>
        private void ChangeMapTiles(byte tileindex)
        {
            Point startPoint = new(
                Math.Min(_startCell.X, _endCell.X),
                Math.Min(_startCell.Y, _endCell.Y)
            );
            Point endPoint = new(
                Math.Max(_startCell.X, _endCell.X),
                Math.Max(_startCell.Y, _endCell.Y)
            );

            for (int row = startPoint.Y; row <= endPoint.Y; row++)
            {
                for (int col = startPoint.X; col <= endPoint.X; col++)
                {
                    _targets.SetMapTile(col, row, tileindex);
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
