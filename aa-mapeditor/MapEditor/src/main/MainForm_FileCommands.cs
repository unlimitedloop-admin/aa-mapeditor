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
//      File name       : MainForm_FileCommands.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/01
//
//      File version    : 10
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  A collection of event handlers for file menu commands.
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        ///  Open the binary file and expand it to the panel.
        /// </summary>
        /// <param name="panel">An object responsible for deploying other objects</param>
        internal void OpenBinaryMapFile(ref Panel panel)
        {
            if (null != _mainContainer && _mainContainer.IsChipLists())
            {
                _mainContainer?.LoadMapFileFromGraphic(ref panel);
                cursorSelectButton.Tag = 0;
            }
            else
            {
                _mainContainer?.LoadMapFileFromHexText(ref panel);
            }
        }

        /// <summary>
        ///  Close the binary file.
        /// </summary>
        /// <param name="panel">The target object to demolish</param>
        internal void CloseBinaryMapFile(ref Panel panel)
        {
            _mainContainer?.DestroyMapFile(ref panel);
            Change_CursorSelectButtonDesign(0);
        }

        /// <summary>
        ///  Open the graphic chip file and expand it to the panel.
        /// </summary>
        /// <param name="panel">Object to deploy</param>
        internal void OpenGraphicChipFile(ref Panel panel)
        {
            _mainContainer?.LoadGraphicChipList(ref panel);
        }

        /// <summary>
        ///  Close the graphic chip list.
        /// </summary>
        /// <param name="panel">Object to destroy</param>
        internal void CloseGraphicChipFile(ref Panel panel)
        {
            _mainContainer.DestroyGraphicChip(ref panel);
            _mainContainer._chipHolder.SetSelectedChipTexture("", null);
        }
    }
}
