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
//      File name       : IStandardFileIO.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/10
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.app.IO
{
    /// <summary>
    ///  A user-defined interface that enforces the implementation of file open and close functionality.
    /// </summary>
    internal interface IStandardFileIO
    {
        bool FileOpen(string path);

        bool FileClose(string path);
    }
}
