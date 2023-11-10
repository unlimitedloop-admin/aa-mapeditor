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
//      File name       : MapTilesCloneCommand.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/09
//
//      File version    : -
//
//
/**************************************************************/

/*
 * ※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
 * ※ このクラスはまだコーディングの状態で使用する事はできません ※
 * ※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
 */

/* using namespace */
using ClientForm.src.CustomControls.Map;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Gems.Command
{
    /// <summary>
    ///  TODO : マップタイルを複製する処理を実装します。
    /// </summary>
    internal class MapTilesCloneCommand : Command
    {
        private const int TILE_SIZE = MAPFIELD_CELLSIZE;   // Square tile length.

        // Resource.
        private readonly TilingPanel _targets;
        private readonly Point _startCell;
        private readonly Point _endCell;
        private readonly Point _targetCell;


        public MapTilesCloneCommand(TilingPanel targets, Point baseStartCell, Point baseEndCell, Point targetCell)
        {
            _targets = targets;
            _startCell = baseStartCell;
            _endCell = baseEndCell;
            _targetCell = targetCell;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
