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
//      File name       : MainForm_EventListener.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Loader;



/* sources */
namespace ClientForm
{
    public partial class MainForm
    {
        /// <summary>
        ///  Launches the <see cref="LoadGraphDialog"/> form and passes the selected image file to the graphicChipPanel.
        /// </summary>
        private void ExecuteLoadGraphDialog(object sender, EventArgs e)
        {
            using LoadGraphDialog loadGraphDialog = new();
            if (loadGraphDialog.ShowDialog() == DialogResult.OK && null != loadGraphDialog.FileName)
            {
                graphicChipPanel.BaseImage = Image.FromFile(loadGraphDialog.FileName);
                graphicChipPanel.LoadChipList(loadGraphDialog.GraphicHeight, loadGraphDialog.GraphicWidth);
            }
            loadGraphDialog.Dispose();
        }
    }
}
