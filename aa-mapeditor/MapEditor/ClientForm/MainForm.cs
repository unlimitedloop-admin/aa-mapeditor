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
//      Last update     : 2023/10/15
//
//      File version    : 5
//
//
/**************************************************************/

// test modules.
using ClientForm.driver;



/* sources */
namespace ClientForm
{
    /// <summary>
    ///  Class for the Application's client form.
    /// </summary>
    public partial class MainForm : Form
    {
        private LoadRawSampler? _sampler;   // sample driver.

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            Text = "Authentic Action Map Editor (back-end-developer edition)";
#else
            Text = "Authentic Action Map Editor (beta version - v0.0)";
#endif
            SetupMapBuilder();  // The primary instance that should be configured uniquely to the application.
            DoSampleCode();     // Do it sample code.
        }

        private void SetupMapBuilder()
        {
            graphicChipPanel.SetPrimaryInstance(ref choiceChipPanel);
            mapFieldPanel.SetPrimaryInstance(ref choiceChipPanel);
        }

        private void DoSampleCode()
        {
            // sample code.
            _sampler = new();
            _sampler.LoadMapFields();
            mapFieldPanel.MapTile = _sampler.MapFields;
        }


        /// <summary>
        ///  An event handler that terminates the application.
        /// </summary>
        private void アプリケーションの終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        ///  Click of openGraphChipButton event handler.
        /// </summary>
        private void OpenGraphChipButton_Click(object sender, EventArgs e) => ExecuteLoadGraphDialog(sender, e);
    }
}
