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
//      File name       : MapFieldNavigator.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/03
//
//      File version    : 8
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.Apps.Files.BinaryFile;
using ClientForm.src.Exceptions;



/* sources */
namespace ClientForm.src.Apps.Core
{
    /// <summary>
    ///  Edit data management class for map fields.
    /// </summary>
    /// <remarks>Managed of <see cref="IMapFieldViewer"/>, <see cref="IBinaryArrayData"/>, <see cref="IBinaryFile"/>, <see cref="IPageIndex"/> and other interfaces.</remarks>
    internal class MapFieldNavigator(IMapFieldViewer mapFields, IBinaryArrayData binaryData, IBinaryFile binFile, IPageIndex pageIndex)
    {

        /// <summary>
        ///  FileName (label) of the map field.
        /// </summary>
        public string BinFileName { get => binFile.BinFileName; set => binFile.BinFileName = value; }

        /// <summary>
        ///  The page address of the currently drawn map.
        /// </summary>
        public int PageIndex
        {
            get => pageIndex!.PageIndex;
            set
            {
                if (pageIndex!.PageIndex != value && 0 <= value)
                {
                    pageIndex.PageIndex = value;
                    ApplyingMapTiles();
                }
            }
        }

        /// <summary>
        ///  Maximum number of pages of <see cref="IBinaryArrayData"/>.
        /// </summary>
        internal int MaxPages => binaryData.PageSize;


        /// <summary>
        ///  Delete the <see cref="IBinaryArrayData"/> data enumeration of concealment.
        /// </summary>
        internal void Clear()
        {
            binaryData.Reset();
            pageIndex!.PageIndex = 0;
        }

        /// <summary>
        ///  Applying the <see cref="IMapFieldViewer"/> tile address.
        /// </summary>
        /// <returns>A logical value indicating whether the map address distribution is complete.</returns>
        private bool ApplyingMapTiles()
        {
            return ExceptionHandler.TryCatchWithLogging(() =>
            {
                byte[,] currentMapFields = mapFields.MapFields;

                for (int i = 0; i < mapFields.MapFields.GetLength(0); i++)
                {
                    for (int j = 0; j < mapFields.MapFields.GetLength(1); j++)
                    {
                        if (binaryData.GetBinaryData(pageIndex!.PageIndex, i, j) is byte data)
                        {
                            mapFields.ChangeMapTile(i, j, data);
                        }
                        else
                        {
                            // Rollback information from a partially processed ChangeMapTile and forces the multiple loop to end.
                            mapFields.MapFields = currentMapFields;
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            });
        }

        /// <summary>
        ///  Sets the binaryData array to be drawn in the field.
        /// </summary>
        /// <returns>True if the field information could be set.</returns>
        internal bool SetFieldData()
        {
            binaryData.Set(BinaryMap.BinaryFileOpener(out string filepath));
            if (0 < binaryData.Length)
            {
                BinFileName = filepath;
                return ApplyingMapTiles();
            }
            return false;
        }

        /// <summary>
        ///  Sets the binaryData array to be drawn in the field.
        /// </summary>
        internal void ReOpenFieldData()
        {
            if (null != BinFileName)
            {
                binaryData.Set(BinaryMap.BinaryFileOpener(BinFileName));
                pageIndex!.PageIndex = 0;
                _ = ApplyingMapTiles();
            }
        }

        /// <summary>
        ///  Save the binary file.
        /// </summary>
        /// <returns>Saved binary file path.</returns>
        internal string ExportingBinaryData() => BinaryMap.SaveBinaryFile(binaryData.Get());

        /// <summary>
        ///  Checks the validity of the values entered in a given object.
        /// </summary>
        /// <returns>Maximum number of pages of <see cref="IBinaryArrayData"/>.</returns>
        internal int ValidationInputPagesValues()
        {
            pageIndex!.ValidationInputPagesValues(MaxPages);
            return MaxPages;
        }
    }
}
