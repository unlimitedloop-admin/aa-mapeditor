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
//      File name       : MapStructs.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/05
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.IO;



/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  The algorithm class for constructing map data.
    /// </summary>
    internal class MapStructs
    {
        /// <summary>
        ///  Binary map file manager class.
        /// </summary>
        private BinMapFile? _binMapFile;


        /// <summary>
        ///  This is the constructor for MapStructs.
        /// </summary>
        /// <param name="name">Binary file name label.</param>
        /// <param name="path">Specify the full path of the binary file</param>
        internal MapStructs(string name, string path)
        {
            _binMapFile = new(name);
            _binMapFile.FileOpen(path);
        }

        /// <summary>
        ///  This is the destructor.
        /// </summary>
        ~MapStructs()
        {
            if (null != _binMapFile)
            {
                _binMapFile.FileClose(_binMapFile.Name);
                _binMapFile = null;
            }
        }

        /// <summary>
        ///  Unzip the map data file.
        /// </summary>
        /// <param name="objects">A reference to the <see cref="TableLayoutPanel"/> object for adding objects</param>
        /// <returns>True if successful.</returns>
        internal bool Unzip(ref TableLayoutPanel objects)
        {
            // Branching where BinMapFile failed.
            if (null == _binMapFile || 0 == _binMapFile.GetDataLength())
            {
                return false;
            }
            int row_number = objects.RowCount;
            int col_number = objects.ColumnCount;
            int cellheight = objects.Height / row_number;
            int cellwidth = objects.Width / col_number;
            Size boxsize = new(cellwidth, cellheight);
            int index = 0x00, chipindex = 0x10;

            // An iterative process that sequentially accesses each split panel in a TableLayoutPanel.
            for (int i = 0; i < row_number; i++)
            {
                for (int j = 0; j < col_number; j++)
                {
                    objects.Controls.Add(_binMapFile.CreateMapTextBox(chipindex, boxsize), j, i);
                    index++; chipindex++;
                }
            }
            return true;
        }
    }
}
