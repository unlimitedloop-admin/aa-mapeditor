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
//      Last update     : 2023/10/22
//
//      File version    : 8
//
//
/**************************************************************/

/* sources */
namespace ClientForm
{
    /// <summary>
    ///  Class for the Application's client form.
    /// </summary>
    public partial class MainForm : Form
    {
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
            graphicChipPanel.SetPrimaryInstance(ref choiceChipPanel);
            mapFieldPanel.SetPrimaryInstance(ref choiceChipPanel);
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
    }
}
