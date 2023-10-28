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
//      Last update     : 2023/10/28
//
//      File version    : 4
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Loader;
using ClientForm.src.Gems.Command;



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
                mapFieldPanel.Invalidate();
            }
            loadGraphDialog.Dispose();
        }

        /// <summary>
        ///  Permanently delete loaded graphics chip information from the entire form.
        /// </summary>
        private void ExecuteRemoveGraphicChip(object sender, EventArgs e)
        {
            graphicChipPanel.BaseImage = null;
            graphicChipPanel.DeleteAllControl();
            mapFieldPanel.Invalidate();
        }

        /// <summary>
        ///  Executes the process of opening binary data.
        /// </summary>
        private void ExecuteOpenBinaryMapFile(object sender, EventArgs e)
        {
            if (mapFieldPanel.Navigator.SetFieldData())
            {
                mapFieldPanel.Invalidate();
            }
        }

        /// <summary>
        ///  Executes the process of closing binary data.
        /// </summary>
        private void ExecuteCloseBinaryMapFile(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mapFieldPanel.Navigator.FieldName))
            {
                mapFieldPanel.DestroyMapField();
                mapFieldPanel.Invalidate();
            }
        }

        /// <summary>
        ///  The main of the Undo process.
        /// </summary>
        private void ExecuteUndo(object sender, EventArgs e)
        {
            Command? command = _recorder!.PopUndoStack();
            command?.Undo();
        }

        /// <summary>
        ///  The main of the redo process.
        /// </summary>
        private void ExecuteRedo(object sender, EventArgs e)
        {
            Command? command = _recorder!.PopRedoStack();
            command?.Execute();
        }
    }
}
