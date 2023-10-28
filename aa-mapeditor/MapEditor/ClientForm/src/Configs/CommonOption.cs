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
//      File name       : CommonOption.cs
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
namespace ClientForm.src.Configs
{
    /// <summary>
    ///  A collection of parameters determined by various application settings.
    /// </summary>
    public class CommonOption
    {
        /// <summary>
        ///  Maximum number of history management for undo (redo) processing.
        /// </summary>
        private uint _mementoListNumber = 100;

        // TODO : コンフィグレーションで元に戻す処理の上限回数を設定できるようにする。(別途画面設計要)
        /// <summary>
        ///  Scale of memento list.
        /// </summary>
        public uint MementoListNumber { get => _mementoListNumber; set => _mementoListNumber = value; }
    }
}
