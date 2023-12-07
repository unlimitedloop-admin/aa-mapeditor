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
//      File name       : BinaryHeaderChangeCommand.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/07
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.CustomControls.Map;



/* sources */
namespace ClientForm.src.Gems.Command
{
    /// <summary>
    ///  Command class to modify binary headers.
    /// </summary>
    /// <param name="targets"><see cref="HeaderInfoPanel"/> reference</param>
    /// <param name="headerInfo">Header information character array</param>
    internal class BinaryHeaderChangeCommand(HeaderInfoPanel targets, string[] headerInfo) : Command
    {
        private string[]? _oldHeaderInfo;

        /// <summary>
        ///  Execute command.
        /// </summary>
        public override void Execute()
        {
            _oldHeaderInfo = targets.GetBaseBinaryHeadBytes();
            targets.SetBaseBinaryHeadBytes(headerInfo);
            targets.Refresh();
        }

        /// <summary>
        ///  Cancel execution of a command.
        /// </summary>
        public override void Undo()
        {
            if (null != _oldHeaderInfo && 0 < _oldHeaderInfo.Length)
            {
                targets.SetBaseBinaryHeadBytes(_oldHeaderInfo);
                targets.Refresh();
            }
        }
    }
}
