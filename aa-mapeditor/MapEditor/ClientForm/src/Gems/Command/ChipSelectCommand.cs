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
//      File name       : ChipSelectCommand.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/28
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.CustomControls.Chip;



/* sources */
namespace ClientForm.src.Gems.Command
{
    /// <summary>
    ///  Command class that displays the selected graphics chip in the <see cref="ChipManagedPanel"/>.
    /// </summary>
    internal class ChipSelectCommand : Command
    {
        // Resource.
        private readonly ChipManagedPanel _targets;
        private readonly Image? _newImage;
        private readonly byte _newTileIndex;
        private readonly Image? _oldImage;
        private readonly byte _oldTileIndex;


        /// <summary>
        ///  Setting command parameter.
        /// </summary>
        /// <param name="targets">Selected chip <see cref="Panel"/></param>
        /// <param name="newimage">The <see cref="Image"/> that will be set from now on</param>
        /// <param name="newtile"><see cref="Image"/> index to be set</param>
        public ChipSelectCommand(ChipManagedPanel targets, Image? newimage, byte newtile)
        {
            _targets = targets;
            _newImage = newimage;
            _newTileIndex = newtile;
            _oldImage = _targets!.ChoiceChip;
            _oldTileIndex = (byte)Math.Max(byte.MinValue, Math.Min(byte.MaxValue, _targets!.ChoiceChipNumber));
        }

        /// <summary>
        ///  Execute a command.
        /// </summary>
        public override void Execute()
        {
            _targets.ChoiceChip = _newImage;
            _targets.ChoiceChipNumber = _newTileIndex;
        }

        /// <summary>
        ///  Cancel execution of a command.
        /// </summary>
        public override void Undo()
        {
            _targets.ChoiceChip = _oldImage;
            _targets.ChoiceChipNumber = _oldTileIndex;
        }
    }
}
