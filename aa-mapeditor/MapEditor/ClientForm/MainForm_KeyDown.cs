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
//      Last update     : 2023/11/09
//
//      File version    : 1
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
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
            }
            mapFieldPanel?.PressAnyKey(e);
        }
    }
}
