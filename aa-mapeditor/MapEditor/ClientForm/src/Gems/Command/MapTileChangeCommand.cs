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
//      Last update     : 2023/11/26
//
//      File version    : 4
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
    /// <remarks>
    ///  Setting command parameter.
    /// </remarks>
    /// <param name="targets">MapTile <see cref="Panel"/></param>
    /// <param name="pagesIndex">Target page index</param>
    /// <param name="start">Start the cell address</param>
    /// <param name="end">End point the cell address</param>
    /// <param name="newTileIndex">Index number of the tile to change</param>
    internal class MapTileChangeCommand(TilingPanel targets, int pagesIndex, Point start, Point end, byte newTileIndex) : Command
    {
        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.
        private readonly List<byte> _oldTileIndex = [];

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
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y)
            );
            Point endPoint = new(
                Math.Max(start.X, end.X),
                Math.Max(start.Y, end.Y)
            );

            int index = 0;
            for (int row = startPoint.Y; row <= endPoint.Y; row++)
            {
                for (int col = startPoint.X; col <= endPoint.X; col++)
                {
                    if (flag)
                    {
                        // Redo (Execute command)
                        _oldTileIndex.Add(targets.Navigator.GetBinaryData(pagesIndex, row, col));
                        targets.Navigator.UpdateBinaryData(pagesIndex, row, col, newTileIndex);  // TODO : バイナリデータへ設定できなかった場合はどうしますか？
                    }
                    else
                    {
                        // Undo
                        targets.Navigator.UpdateBinaryData(pagesIndex, row, col, _oldTileIndex[index]);  // TODO : バイナリデータへ設定できなかった場合はどうしますか？
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
            
            targets.SuspendLayout();
            Rectangle invalidateRect = new(x, y, width, height);
            targets.Invalidate(invalidateRect);
            targets.ResumeLayout();
        }
    }
}
