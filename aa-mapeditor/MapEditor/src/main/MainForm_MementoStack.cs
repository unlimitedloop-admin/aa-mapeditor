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
//      Last update     : 2023/09/17
//
//      File version    : 2
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Parameter class for remembering past actions.
    /// </summary>
    internal class MementoParameter
    {
        public int? MapRow { get; set; } = null;
        public int? MapColumn { get; set; } = null;
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
                    // TODO : The process of reverting to the MapStructs area.
                    else
                    {

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
                    // TODO : The process of redoing to the MapStructs area.
                    else
                    {

                    }
                }
                _undoMemento.Push(changes);
            }
        }
    }
}