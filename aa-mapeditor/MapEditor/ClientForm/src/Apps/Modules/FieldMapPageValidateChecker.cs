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
//      File name       : FieldMapPageValidateChecker.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/03
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Apps.Modules
{
    /// <summary>
    ///  Provides input check function for field map page.
    /// </summary>
    internal class FieldMapPageValidateChecker
    {
        // Used to hold pre-input information for showPagesTextBox used when moving pages.
        // This is only manipulated by the ValidationInputPagesValues method. Anything else is not allowed.
        private string _previousPageText = "1";

        /// <summary>
        ///  Validate the input value in the page number <see cref="TextBox"/>.
        /// </summary>
        /// <param name="sender">showPagesTextBox object</param>
        /// <param name="maxPages">Maximum number of pages that can be set</param>
        internal void ValidationInputPagesValues(TextBox sender, int maxPages)
        {
            if (int.TryParse(sender.Text, out int number))
            {
                // If the input value is within the range, keep the value; if it is outside the range, restore the input value.
                if (number <= 0 || number > maxPages)
                {
                    RestorePreviousText(sender);
                }
                else
                {
                    _previousPageText = sender.Text;
                }
            }
            else if (!string.IsNullOrEmpty(sender.Text))
            {
                RestorePreviousText(sender);
            }
            else // Default behavior when sender.Text is empty.
            {
                _previousPageText = "1";
                sender.Text = _previousPageText;
            }
        }

        /// <summary>
        ///  Undo <see cref="TextBox"/> changes.
        /// </summary>
        /// <param name="sender"><see cref="TextBox"/> object</param>
        private void RestorePreviousText(TextBox sender)
        {
            System.Media.SystemSounds.Beep.Play();
            sender.Text = _previousPageText;
            sender.SelectionStart = sender.Text.Length;
        }
    }
}
