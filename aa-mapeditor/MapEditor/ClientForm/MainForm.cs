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
//      File name       : MainForm.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/25
//
//      File version    : 13
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;



/* sources */
namespace ClientForm
{
    /// <summary>
    ///  Class for the Application's client form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///  An alchemy cauldron for moving through the changes of history.
        /// </summary>
        private RecordSupervision _recorder;


        public MainForm(string applicationName)
        {
            InitializeComponent();
            Text = applicationName;  // Application name.

            _recorder = new(this);
            SetupMapBuilder();  // The primary instance that should be configured uniquely to the application.
        }

        /// <summary>
        ///  Initialization process of map container required instance.
        /// </summary>
        private void SetupMapBuilder()
        {
            graphicChipPanel.SetPrimaryInstance(ref choiceChipPanel, ref _recorder);
            mapFieldPanel.SetPrimaryInstance(ref choiceChipPanel, ref _recorder);
        }

        /// <summary>
        ///  KeyDown event handler for MainForm.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e) => KeyDownEvent(sender, e);

        /// <summary>
        ///  An event handler that terminates the application.
        /// </summary>
        private void アプリケーションの終了XToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        ///  Open graphic chip list event handler.
        /// </summary>
        private void OpenGraphChipButton_Click(object sender, EventArgs e) => ExecuteLoadGraphDialog(sender, e);
        private void GraphicChipPanel_DoubleClick(object sender, EventArgs e) => ExecuteLoadGraphDialog(sender, e);
        private void 開く_グラフィックチップ_Click(object sender, EventArgs e) => ExecuteLoadGraphDialog(sender, e);

        /// <summary>
        ///  Close graphic chip list event handler.
        /// </summary>
        private void 閉じる_グラフィックチップ_Click(object sender, EventArgs e) => ExecuteRemoveGraphicChip(sender, e);

        /// <summary>
        ///  Open binary map data event handler.
        /// </summary>
        private void OpenBinaryMapButton_Click(object sender, EventArgs e) => ExecuteOpenBinaryMapFile(sender, e);
        private void MapFieldPanel_DoubleClick(object? sender, EventArgs e) => ExecuteOpenBinaryMapFile(sender!, e);
        private void 開く_マップデータ_Click(object sender, EventArgs e) => ExecuteOpenBinaryMapFile(sender, e);

        /// <summary>
        ///  Close binary map event handler.
        /// </summary>
        private void 閉じる_マップデータ_Click(object sender, EventArgs e) => ExecuteCloseBinaryMapFile(sender, e);

        /// <summary>
        ///  Returns the loaded binary file to its pre-change state (reloads it).
        /// </summary>
        private void バイナリデータを開き直す_Click(object sender, EventArgs e) => ExecuteReloadBinaryMapFile(sender, e);
        public void Changeバイナリデータを開き直すMenuItemEnabled(bool isEnabled) => バイナリデータを開き直すRToolStripMenuItem.Enabled = isEnabled;

        /// <summary>
        ///  User interface for page transitions.
        /// </summary>
        private void PrevPagesButton_Click(object sender, EventArgs e) => ExecuteChangePages(-1);
        private void NextPagesButton_Click(object sender, EventArgs e) => ExecuteChangePages(1);
        private void ShowPagesTextBox_Leave(object sender, EventArgs e) => ExecuteChangePages((TextBox)sender!);
        private void ShowPagesTextBox_KeyDown(object sender, KeyEventArgs e) => KeyDownEvent(sender, e);

        /// <summary>
        ///  Output binary data to a binary file.
        /// </summary>
        private void マップデータをバイナリへ書き出しToolStripMenuItem_Click(object sender, EventArgs e) => ExecuteSavingBinaryFile();
        public void Changeマップデータをバイナリへ書き出しToolStripMenuItemEnabled(bool isEnabled) => マップデータをバイナリへ書き出しToolStripMenuItem.Enabled = isEnabled;

        /// <summary>
        ///  Undo event handler.
        /// </summary>
        private void 元に戻す_Click(object sender, EventArgs e) => ExecuteUndo(sender, e);
        internal void 元に戻す_ChangeEnabled(bool enabled) => 元に戻すUToolStripMenuItem.Enabled = enabled;

        /// <summary>
        ///  Redo event handler.
        /// </summary>
        private void やり直し_Click(object sender, EventArgs e) => ExecuteRedo(sender, e);
        internal void やり直し_ChangeEnabled(bool enabled) => やり直しRToolStripMenuItem.Enabled = enabled;
    }
}
