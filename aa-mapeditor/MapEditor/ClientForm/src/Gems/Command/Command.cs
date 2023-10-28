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
//      File name       : Command.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/28
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Gems.Command
{
    /// <summary>
    ///  Command class. Used to encapsulate actions to track behavior.
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}
