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
//      Last update     : 2023/09/05
//
//      File version    : 10
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.applet;



/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Application power window.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///  The main functionality instance of the map editor.
        /// </summary>
        private readonly MapContainer _mainContainer = new();


        /// <summary>
        ///  This is the constructor for MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        #region FILE_MENU_EVENT

        private void バイナリデータを開くBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBinaryMapFile(ref mapFieldTable);
        }

        private void バイナリデータを閉じるBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBinaryMapFile(ref mapFieldTable);
        }

        private void グラフィックチップリストを開くGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGraphicChipFile(ref graphicChipPanel);
        }

        private void グラフィックチップリストを閉じるGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseGraphicChipFile(ref graphicChipPanel);
        }

        private void アプリケーションを終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion  // FILE_MENU_EVENT


        #region INTERRUPT_EVENT

        /// <summary>
        ///  Physical button click event handler for graphics chip list.
        /// </summary>
        /// <param name="sender">Image data set in <see cref="PictureBox"/></param>
        /// <param name="e">Unused event argument</param>
        private void ChipLists_GraphicChipClick(object? sender, EventArgs e)
        {
            Image image = (Image)sender!;
            if (null != selectedChipTexture)
            {
                selectedChipTexture.Image = image;
            }
        }

        #endregion  // INTERRUPT_EVENT


        #region COMMON_EVENT_HANDLER

        private void MainForm_Activated(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
                return;
            }
        }

        #endregion  // COMMON_EVENT_HANDLER
    }
}
