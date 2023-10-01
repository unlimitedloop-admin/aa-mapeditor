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
//      Last update     : 2023/10/01
//
//      File version    : 14
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.applet;
using static MapEditor.src.common.ConstMapFieldTable;



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
        private readonly MapContainer _mainContainer;


        /// <summary>
        ///  This is the constructor for MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _mainContainer = new(ref selectedChipPanel);
        }


        #region FILE_MENU_EVENT

        private void バイナリデータを開くBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBinaryMapFile(ref mapStructPanel);
        }

        private void バイナリデータを閉じるBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBinaryMapFile(ref mapStructPanel);
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

        private void クリックで選択SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_CursorSelectButtonDesign(MAPFIELD_MODE_RANGE);
        }

        private void クリックでチップ配置PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_CursorSelectButtonDesign(MAPFIELD_MODE_CLICK);
        }

        #endregion  // EDIT_MENU_EVENT


        #region UI_CONTROL_EVENT_HANDLER

        private void CursorSelectButton_Click(object sender, EventArgs e)
        {
            // Take the Tag property of the cursor selection mode button object as an argument.
            int changetag = MAPFIELD_MODE_CLICK == (int)((Button)sender).Tag! ? MAPFIELD_MODE_RANGE : MAPFIELD_MODE_CLICK;
            Change_CursorSelectButtonDesign(changetag);
        }

        private void CursorSelectButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion  // UI_CONTROL_EVENT_HANDLER


        #region CONTROL_EVENT_HANDLER

        private void MapStructPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (_mainContainer.IsChipLists())
            {
                cursorSelectButton.Visible = true;
            }
        }

        private void MapStructPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            cursorSelectButton.Visible = false;
        }

        private void GraphicChipPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion  // CONTROL_EVENT_HANDLER


        #region COMMON_EVENT_HANDLER

        private void MainForm_Load(object sender, EventArgs e)
        {
            cursorSelectButton.Visible = false;
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

            if (e.KeyData == Keys.Enter)
            {
                _mainContainer?.MapStruct_ReplaceRangeCell(true);
                Change_CursorSelectButtonDesign(MAPFIELD_MODE_CLICK);
                return;
            }

            if (e.KeyData == Keys.Insert)
            {
                _mainContainer?.MapStruct_ReplaceRangeCell(false);
                return;
            }
        }

        #endregion  // COMMON_EVENT_HANDLER
    }
}
