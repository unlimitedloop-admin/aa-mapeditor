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
//      File name       : PageIndex.cs
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
using ClientForm.src.Apps.Modules;



/* sources */
namespace ClientForm.src.Apps.EditsUI
{
    /// <summary>
    ///  This is an interface that manages the paging numbers of map fields.
    /// </summary>
    public interface IPageIndex
    {
        int PageIndex { get; set; }
        public void ValidationInputPagesValues(int maxPages);
    }

    /// <summary>
    ///  Concrete class that implements <see cref="IPageIndex"/> interface.
    /// </summary>
    /// <param name="textBox">"showPagesTextBox" control.</param>
    public class PageIndexer(TextBox textBox) : IPageIndex
    {
        private readonly TextBox _textBox = textBox;
        private readonly FieldMapPageValidateChecker _mapPager = new();     // Field map page input check.

        public int PageIndex { get; set; } = 0;

        public void ValidationInputPagesValues(int maxPages) => _mapPager.ValidationInputPagesValues(_textBox, maxPages);
    }
}
