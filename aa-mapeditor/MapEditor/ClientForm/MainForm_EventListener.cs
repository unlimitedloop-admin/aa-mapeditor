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
//      File name       : MainForm_EventListener.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/18
//
//      File version    : 5
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Loader;
using ClientForm.src.Configs;
using ClientForm.src.Gems.Command;



/* sources */
namespace ClientForm
{
    public partial class MainForm
    {
        /// <summary>
        ///  Launches the <see cref="LoadGraphDialog"/> form and passes the selected image file to the graphicChipPanel.
        /// </summary>
        private void ExecuteLoadGraphDialog(object sender, EventArgs e)
        {
            using LoadGraphDialog loadGraphDialog = new();
            if (loadGraphDialog.ShowDialog() == DialogResult.OK && null != loadGraphDialog.FileName)
            {
                graphicChipPanel.BaseImage = Image.FromFile(loadGraphDialog.FileName);
                graphicChipPanel.LoadChipList(loadGraphDialog.GraphicHeight, loadGraphDialog.GraphicWidth);
                mapFieldPanel.Invalidate();
            }
            loadGraphDialog.Dispose();
            ActiveControl = null;
        }

        /// <summary>
        ///  Permanently delete loaded graphics chip information from the entire form.
        /// </summary>
        private void ExecuteRemoveGraphicChip(object sender, EventArgs e)
        {
            graphicChipPanel.BaseImage = null;
            graphicChipPanel.DeleteAllControl();
            mapFieldPanel.Invalidate();
        }

        /// <summary>
        ///  Executes the process of opening binary data.
        /// </summary>
        private void ExecuteOpenBinaryMapFile(object sender, EventArgs e)
        {
            if (mapFieldPanel.Navigator.SetFieldData())
            {
                mapFieldPanel.DoubleClick -= MapFieldPanel_DoubleClick; // When the map is already loaded, it will not be loaded further.
                mapFieldPanel.Invalidate();
                showPagesTextBox.Enabled = true;
                showPagesTextBox.Text = "1";
                maxPagesLabel.Text = "/ " + (mapFieldPanel.Navigator.BinaryData.Length / CoreConstants.BINARY_DATA_1PAGE_SIZE).ToString();
            }
            ActiveControl = null;
        }

        /// <summary>
        ///  Executes the process of closing binary data.
        /// </summary>
        private void ExecuteCloseBinaryMapFile(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mapFieldPanel.Navigator.FieldName))
            {
                mapFieldPanel.DestroyMapField();
                mapFieldPanel.Invalidate();
                mapFieldPanel.DoubleClick += MapFieldPanel_DoubleClick;
                showPagesTextBox.Text = "";
                showPagesTextBox.Enabled = false;
                maxPagesLabel.Text = "/ N";
            }
        }

        /// <summary>
        ///  Rewrites the map field according to the input value.
        /// </summary>
        /// <param name="offset">Change offset</param>
        private void ExecuteChangePages(int offset)
        {
            int maxPages = mapFieldPanel.Navigator.BinaryData.Length / CoreConstants.BINARY_DATA_1PAGE_SIZE;
            if (int.TryParse(showPagesTextBox.Text, out int number) && ((offset < 0 && 1 < number) || (offset > 0 && number < maxPages)))
            {
                showPagesTextBox.Text = (number + offset).ToString();
                mapFieldPanel.Navigator.PageIndex = number + offset - 1;
                mapFieldPanel.Refresh();
            }
            ActiveControl = null;
        }

        /// <summary>
        ///  Rewrites the map field according to the input value.
        /// </summary>
        /// <param name="sender"><see cref="TextBox"/> object</param>
        private void ExecuteChangePages(TextBox sender)
        {
            int maxPages = mapFieldPanel.Navigator.BinaryData.Length / CoreConstants.BINARY_DATA_1PAGE_SIZE;
            mapFieldPanel.Navigator.ValidationInputPagesValues(sender, maxPages);
            if (int.TryParse(sender.Text, out int number) && 0 < number && number <= maxPages)
            {
                sender.Text = number.ToString();
                mapFieldPanel.Navigator.PageIndex = number - 1;
                mapFieldPanel.Refresh();
            }
        }

        /// <summary>
        ///  The main of the Undo process.
        /// </summary>
        private void ExecuteUndo(object sender, EventArgs e)
        {
            Command? command = _recorder!.PopUndoStack();
            command?.Undo();
        }

        /// <summary>
        ///  The main of the redo process.
        /// </summary>
        private void ExecuteRedo(object sender, EventArgs e)
        {
            Command? command = _recorder!.PopRedoStack();
            command?.Execute();
        }
    }
}
