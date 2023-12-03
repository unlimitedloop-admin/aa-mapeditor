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
//      File name       : MapFieldViewer.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/03
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  An interface with a region of map fields.
    /// </summary>
    public interface IMapFieldViewer
    {
        public byte[,] MapFields { get; set; }
        public void ChangeMapTile(int row, int col, byte index);
    }



    /// <summary>
    /// Concrete class that implements <see cref="IMapFieldViewer"/> interface.
    /// </summary>
    public class MapFieldViewer : IMapFieldViewer
    {
        /// <summary>
        ///  This array is a map data tile structure of a fixed area drawn in the TilingPanel.
        /// </summary>
        private byte[,] _mapFields = new byte[MAPFIELD_LINES, MAPFIELD_COLUMNS];

        /// <summary>
        ///  A two-dimensional array of map fields.
        /// </summary>
        public byte[,] MapFields
        {
            get => _mapFields;
            set
            {
                if (_mapFields != value)
                {
                    _mapFields = value;
                }
            }
        }

        /// <summary>
        ///  Stores the chips in the map field array.
        /// </summary>
        /// <param name="row">Row number of the array</param>
        /// <param name="col">Column number of the array</param>
        /// <param name="index">Tile address to be replaced</param>
        public void ChangeMapTile(int row, int col, byte index)
        {
            if (0 <= row && row < MapFields.GetLength(0) && 0 <= col && col < MapFields.GetLength(1))
            {
                MapFields[row, col] = index;
            }
        }
    }
}
