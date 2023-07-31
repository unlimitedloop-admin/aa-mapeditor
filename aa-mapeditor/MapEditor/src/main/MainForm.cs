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
//      Last update     : 2023/08/01
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Application power window.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///  File menu commands.
        /// </summary>
        private readonly FileCommands _fileCommands = new();

        public MainForm()
        {
            InitializeComponent();
        }


        /** EventHandler **/
        private void アプリケーションを終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCommands.ExitApplication();
        }
    }
}
