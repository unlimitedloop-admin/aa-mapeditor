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
//      File name       : mainForm_MementoStack.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/30
//
//      File version    : 3
//
//
/**************************************************************/

/* using namespace */
using static MapEditor.src.common.ConstBinaryData;



/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Parameter class for remembering past actions.
    /// </summary>
    internal class MementoParameter
    {
        public int? MapAddress { get; set; } = null;
        public bool Holder { get; set; } = false;
        public byte? OldImageBinNum { get; set; } = null;
        public byte? NewImageBinNum { get; set; } = null;
    }



    /// <summary>
    ///  A split class that maintains an event stack for undo and redo.
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        ///  The stack list of MementoParameter objects for storing undo actions.
        /// </summary>
        private static readonly Stack<List<MementoParameter>> _undoMemento = new();

        /// <summary>
        ///  <para>The stack list of MementoParameter objects for storing redo actions.</para>
        ///  <para>*This is only stacked when the undo operation is performed.</para>
        /// </summary>
        private static readonly Stack<List<MementoParameter>> _redoMemento = new();


        /// <summary>
        ///  Stacking the list of memories onto the stack.
        /// </summary>
        /// <param name="parameters">The list parameter containing objects for executing the undo process</param>
        internal static void Recollection(List<MementoParameter> parameters)
        {
            _undoMemento.Push(parameters);
            _redoMemento.Clear();
        }

        /// <summary>
        ///  Undo operation.
        /// </summary>
        private void Undo()
        {
            if (0 < _undoMemento.Count)
            {
                List<MementoParameter> changes = _undoMemento.Pop();
                foreach (var change in changes)
                {
                    // The process of reverting to the SelectedChipTexture object.
                    if (change.Holder)
                    {
                        _mainContainer?._chipHolder.SetSelectedChipTexture(change.OldImageBinNum.ToString(), _mainContainer?.GetChipListImage(change.OldImageBinNum));
                    }
                    else
                    {
                        if (null != change.MapAddress && null != cursorSelectButton.Tag && (_mainContainer?.GetMapPages()) == (change.MapAddress / 0x100))
                        {
                            PictureBox picturebox = new()
                            {
                                Text = change.OldImageBinNum.ToString(),
                                Image = _mainContainer?.GetChipListImage(change.OldImageBinNum),
                            };
                            // Calculates and identifies the TableLayoutPanel cell position from a binary address.
                            int row = ((int)(change.MapAddress % MAP_PAGESIZE) - MAP_HEADERSIZE) / 0x10;
                            int col = ((int)(change.MapAddress % MAP_PAGESIZE) - MAP_HEADERSIZE) % 0x10;
                            bool transparents = 1 == (int)cursorSelectButton.Tag;
                            _mainContainer?.SetPanelFromMapFieldPosition(col, row, picturebox, transparents);
                        }
                    }
                }
                _redoMemento.Push(changes);
            }
        }

        /// <summary>
        ///  Redo operation.
        /// </summary>
        private void Redo()
        {
            if (0 < _redoMemento.Count)
            {
                List<MementoParameter> changes = _redoMemento.Pop();
                foreach (var change in changes)
                {
                    // The process of redoing the SelectedChipTexture object.
                    if (change.Holder)
                    {
                        _mainContainer?._chipHolder.SetSelectedChipTexture(change.NewImageBinNum.ToString(), _mainContainer?.GetChipListImage(change.NewImageBinNum));
                    }
                    else
                    {
                        if (null != change.MapAddress && null != cursorSelectButton.Tag && (_mainContainer?.GetMapPages()) == (change.MapAddress / 0x100))
                        {
                            PictureBox picturebox = new()
                            {
                                Text = change.NewImageBinNum.ToString(),
                                Image = _mainContainer?.GetChipListImage(change.NewImageBinNum),
                            };
                            // Calculates and identifies the TableLayoutPanel cell position from a binary address.
                            int row = ((int)(change.MapAddress % MAP_PAGESIZE) - MAP_HEADERSIZE) / 0x10;
                            int col = ((int)(change.MapAddress % MAP_PAGESIZE) - MAP_HEADERSIZE) % 0x10;
                            bool transparents = 1 == (int)cursorSelectButton.Tag;
                            _mainContainer?.SetPanelFromMapFieldPosition(col, row, picturebox, transparents);
                        }
                    }
                }
                _undoMemento.Push(changes);
            }
        }
    }
}