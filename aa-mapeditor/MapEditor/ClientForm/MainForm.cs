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
//      Last update     : 2023/10/28
//
//      File version    : 9
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
        private RecordSupervision _recorder = new();


        public MainForm(string applicationName)
        {
            InitializeComponent();
            Text = applicationName;  // Application name.
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
        private void MapFieldPanel_DoubleClick(object sender, EventArgs e) => ExecuteOpenBinaryMapFile(sender, e);
        private void 開く_マップデータ_Click(object sender, EventArgs e) => ExecuteOpenBinaryMapFile(sender, e);

        /// <summary>
        ///  Close binary map event handler.
        /// </summary>
        private void 閉じる_マップデータ_Click(object sender, EventArgs e) => ExecuteCloseBinaryMapFile(sender, e);

        /// <summary>
        ///  Undo event handler.
        /// </summary>
        private void 元に戻す_Click(object sender, EventArgs e) => ExecuteUndo(sender, e);

        /// <summary>
        ///  Redo event handler.
        /// </summary>
        private void やり直し_Click(object sender, EventArgs e) => ExecuteRedo(sender, e);
    }
}
