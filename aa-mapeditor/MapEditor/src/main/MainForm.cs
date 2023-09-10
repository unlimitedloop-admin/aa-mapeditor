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
//      Last update     : 2023/09/10
//
//      File version    : 11
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


        #region EDIT_MENU_EVENT

        private void 元に戻すUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void やり直しRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        #endregion  // EDIT_MENU_EVENT


        #region COMMON_EVENT_HANDLER

        private void MainForm_Load(object sender, EventArgs e)
        {
            _customMapStructEventArgs.MouseDownEvent += MapStruct_FieldMouseDown;
            _customMapStructEventArgs.MouseUpEvent += MapStruct_FieldMouseUp;
            _customMapStructEventArgs.MouseMoveEvent += MapStruct_FieldMouseMove;
        }

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


        /// <summary>
        ///  Set an image to the selectedChipTexture object.
        /// </summary>
        /// <param name="text">Set <see cref="string"/> the selectedChipTexture.Text</param>
        /// <param name="backgroundimage">Set <see cref="Image"/> the selectedChipTexture.Image</param>
        private void SetSelectedChipTexture(string? text, Image? backgroundimage)
        {
            selectedChipTexture.Text = text;
            selectedChipTexture.Image = backgroundimage;
        }
    }
}
