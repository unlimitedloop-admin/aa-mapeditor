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
//      File name       : RecordSupervision.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/07
//
//      File version    : 4
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Configs;
using ClientForm.src.CustomControls.Stack;
using ClientForm.src.Gems.Command;



/* sources */
namespace ClientForm.src.Apps.Core
{
    /// <summary>
    ///  An alchemy cauldron for moving through the changes of history class.
    /// </summary>
    public class RecordSupervision
    {
        private readonly MainForm _mainForm;

        /// <summary>
        ///  The stack list of MementoParameter objects for storing undo actions.
        /// </summary>
        private readonly MementoStack<Command> _undoStack = new(new CommonOption().MementoListNumber);

        /// <summary>
        ///  <para>The stack list of MementoParameter objects for storing redo actions.</para>
        ///  <para>*This is only stacked when the undo operation is performed.</para>
        /// </summary>
        private readonly MementoStack<Command> _redoStack = new(new CommonOption().MementoListNumber);


        internal RecordSupervision(MainForm mainForm)
        {
            _mainForm = mainForm;
            EnableMenuCommand();
        }

        /// <summary>
        ///  Switches activation/deactivation of Undo and Redo commands.
        /// </summary>
        private void EnableMenuCommand()
        {
            _mainForm.元に戻す_ChangeEnabled(0 < _undoStack.Count);
            _mainForm.やり直し_ChangeEnabled(0 < _redoStack.Count);
        }

        /// <summary>
        ///  Push a command onto the undo stack.
        /// </summary>
        /// <param name="command">Inherited commands</param>
        internal void PushUndoStack(Command command)
        {
            _undoStack.Push(command);
            _redoStack.Clear();
            EnableMenuCommand();
        }

        /// <summary>
        ///  Pop from the undo stack.
        /// </summary>
        /// <returns>Action commands.</returns>
        internal Command? PopUndoStack()
        {
            if (0 < _undoStack.Count)
            {
                Command command = _undoStack.Pop();
                _redoStack.Push(command);
                EnableMenuCommand();
                return command;
            }
            return null;
        }

        /// <summary>
        ///  Pop from the redo stack.
        /// </summary>
        /// <returns>Action commands.</returns>
        internal Command? PopRedoStack()
        {
            if (0 < _redoStack.Count)
            {
                Command command = _redoStack.Pop();
                _undoStack.Push(command);
                EnableMenuCommand();
                return command;
            }
            return null;
        }

        /// <summary>
        ///  Clear all stack register.
        /// </summary>
        internal void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            EnableMenuCommand();
        }
    }
}
