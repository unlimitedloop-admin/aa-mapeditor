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
//      Last update     : 2023/08/05
//
//      File version    : 4
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
        ///  Debug context menu commands.
        /// </summary>
        private readonly DebugCommands _examinateCommands = new();

        /// <summary>
        ///  File menu commands.
        /// </summary>
        private readonly FileCommands _fileCommands;

        public MainForm()
        {
            InitializeComponent();
            _fileCommands = new(ref _mainContainer);
        }


        /** EventHandler **/
        private void バイナリデータを開くBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileCommands.OpenBinaryMapFile(ref mapFieldTable);
        }

        private void バイナリデータを閉じるBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileCommands.CloseBinaryMapFile(ref mapFieldTable);
        }

        private void アプリケーションを終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCommands.ExitApplication();
        }

        private void バイナリファイルオープンテスト1ToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            _examinateCommands.OpenBinaryFile1();
        }
    }
}
