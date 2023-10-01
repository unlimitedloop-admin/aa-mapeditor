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
//      File name       : MainForm_SubModule.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/01
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Implement other private methods to use on MainForm.
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        ///  Toggles the cursor selection mode button.
        /// </summary>
        /// <param name="changetag">Desired value (0 or 1)</param>
        private void Change_CursorSelectButtonDesign(int changetag)
        {
            // If you are already in the same mode, no operation is necessary.
            if (null != cursorSelectButton.Tag && changetag != (int)cursorSelectButton.Tag)
            {
                if (0 == (int)cursorSelectButton.Tag)
                {
                    _mainContainer.ChangeSelectModeForMapStruct(true);
                    cursorSelectButton.BackgroundImage = Properties.Resources.icons8_カーソル_30;
                    cursorSelectButton.Tag = 1;
                    ActiveControl = null;
                }
                else if (1 == (int)cursorSelectButton.Tag)
                {
                    _mainContainer.ChangeSelectModeForMapStruct(false);
                    cursorSelectButton.BackgroundImage = Properties.Resources.icons8_セルを選択_30;
                    cursorSelectButton.Tag = 0;
                }
            }
        }
    }
}
