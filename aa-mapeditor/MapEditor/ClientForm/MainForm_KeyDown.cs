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
//      File name       : MainForm_KeyDown.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/18
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace ClientForm
{
    public partial class MainForm
    {
        /// <summary>
        ///  This is the logic of the KeyDown event.
        /// </summary>
        /// <param name="e">Key event args</param>
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
            }
            else if (sender == showPagesTextBox && e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
            }
            mapFieldPanel?.PressAnyKey(e);
        }
    }
}
