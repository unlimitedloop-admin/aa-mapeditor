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
//      Last update     : 2023/12/03
//
//      File version    : 8
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Loader;
using ClientForm.src.Gems.Command;
using static ClientForm.src.Configs.CustomColor;



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
            if (_navigator!.SetFieldData())
            {
                ActivateMapFieldPanel();
                mapFieldInfoPanel.Invalidate();
            }
            ActiveControl = null;
        }

        /// <summary>
        ///  Executes the process of closing binary data.
        /// </summary>
        private void ExecuteCloseBinaryMapFile(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_navigator!.BinFileName))
            {
                mapFieldPanel.DestroyMapField();
                mapFieldInfoPanel.Clear();
                _navigator!.BinFileName = string.Empty;
                _navigator!.Clear();
                _recorder.Clear();
                mapFieldPanel.Invalidate();
                mapFieldInfoPanel.Invalidate();
                mapFieldPanel.DoubleClick += MapFieldPanel_DoubleClick;
                showPagesTextBox.Text = "";
                showPagesTextBox.Enabled = false;
                maxPagesLabel.Text = "/ N";
            }
        }

        /// <summary>
        ///  Reloads a binary file that has already been loaded.
        /// </summary>
        private void ExecuteReloadBinaryMapFile(object sender, EventArgs args)
        {
            const string alertText = "マップフィールドの編集は失われます。この操作は元に戻せません。\r\nバイナリデータを再読み込みしますか？";
            if (!string.IsNullOrEmpty(_navigator!.BinFileName) && DialogResult.OK == MessageBox.Show(alertText, "Caution", MessageBoxButtons.OKCancel))
            {
                _navigator!.ReOpenFieldData();
                ActivateMapFieldPanel();
                _recorder.Clear();
                ActiveControl = null;
            }
        }

        /// <summary>
        ///  The process of activating the map field panel.
        /// </summary>
        private void ActivateMapFieldPanel()
        {
            mapFieldPanel.DoubleClick -= MapFieldPanel_DoubleClick; // When the map is already loaded, it will not be loaded further.
            mapFieldPanel.Invalidate();
            mapFieldInfoPanel.InitializeLabels();
            showPagesTextBox.Enabled = true;
            showPagesTextBox.Text = "01";
            maxPagesLabel.Text = "/ " + _navigator!.MaxPages.ToString("X2");
        }

        /// <summary>
        ///  Rewrites the map field according to the input value.
        /// </summary>
        /// <param name="offset">Change offset</param>
        private void ExecuteChangePages(int offset)
        {
            int maxPages = _navigator!.MaxPages;
            if (int.TryParse(showPagesTextBox.Text, System.Globalization.NumberStyles.HexNumber, null, out int number) && ((offset < 0 && 1 < number) || (offset > 0 && number < maxPages)))
            {
                showPagesTextBox.Text = (number + offset).ToString("X2");
                _navigator!.PageIndex = number + offset - 1;
                mapFieldPanel.Refresh();
                mapFieldInfoPanel.Refresh();
            }
            ActiveControl = null;
        }

        /// <summary>
        ///  Rewrites the map field according to the input value.
        /// </summary>
        /// <param name="sender"><see cref="TextBox"/> object</param>
        private void ExecuteChangePages(TextBox sender)
        {
            int v = _navigator!.ValidationInputPagesValues();
            if (int.TryParse(sender.Text, System.Globalization.NumberStyles.HexNumber, null, out int number) && 0 < number && number <= v)
            {
                sender.Text = number.ToString("X2");
                _navigator!.PageIndex = number - 1;
                mapFieldPanel.Refresh();
                mapFieldInfoPanel.Refresh();
            }
        }

        /// <summary>
        ///  Output binary data to a binary file.
        /// </summary>
        private void ExecuteSavingBinaryFile()
        {
            if (_navigator!.ExportingBinaryData() is string filename && !string.IsNullOrEmpty(filename))
            {
                _ = MessageBox.Show("バイナリファイルを保存しました。" + "\r\n" + Path.GetFileName(filename), "名前を付けて保存");
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

        /// <summary>
        ///  Event listener when the file path of IBinaryFile is changed.
        /// </summary>
        /// <param name="fieldName">Changed file path</param>
        private void BinaryArrayData_FilenameChanged(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                mapFieldPanel.BackColor = SystemColors.AppWorkspace;
                mapFieldPanel.SetToolTipActivate(true);
                Changeバイナリデータを開き直すMenuItemEnabled(false);
                Changeマップデータをバイナリへ書き出しMenuItemEnabled(false);
            }
            else
            {
                mapFieldPanel.BackColor = LightGreen;
                mapFieldPanel.SetToolTipActivate(false);
                Changeバイナリデータを開き直すMenuItemEnabled(true);
                Changeマップデータをバイナリへ書き出しMenuItemEnabled(true);
            }
        }
    }
}
