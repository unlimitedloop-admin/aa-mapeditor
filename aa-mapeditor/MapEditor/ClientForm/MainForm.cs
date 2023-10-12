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
//      Last update     : 2023/10/12
//
//      File version    : 3
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
        readonly LoadRawSampler _sampler;     // sample driver.

        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            Text = "Authentic Action Map Editor (back-end-developer edition)";
#else
            Text = "Authentic Action Map Editor (beta version - v0.0)";
#endif
            // sample code.
            graphicChipPanel.BaseImage = Image.FromFile("C:\\Users\\you nanase\\ローカルプロジェクト\\r2-refined\\r2-refined\\r2-refined\\assets\\2_BG\\demostage_BG.png");
            graphicChipPanel.LoadChipList(8, 16);
            _sampler = new();
            _sampler.LoadImageList();
            mapFieldPanel.ImageList = _sampler.ImageList;
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
    }
}
