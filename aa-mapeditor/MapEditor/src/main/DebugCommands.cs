/**************************************************************/
//
//
//      Copyright (c) 20XX UNLIMITED LOOP ROOT-ONE
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
//      File name       : DebugCommands.cs
//
//      Author          : u7
//
//      Last update     : 2023/08/02
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.app.IO;



/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  The command class is for development purposes only.
    /// </summary>
    internal class DebugCommands
    {
        internal void OpenBinaryFile1()
        {
            using OpenFileDialog openbin = new()
            {
                Filter = "binファイル(*bin)|*bin|すべてのファイル(*.*)|*.*",
                Title = "ファイルを選択",
            };
            if (openbin.ShowDialog() == DialogResult.OK)
            {
                BinMapFile file = new("sample!");
                if (file.FileOpen(openbin.FileName))
                {
                    //MessageBox.Show("メッセージが表示できます。");
                    //MessageBox.Show(Path.GetFileName(openbin.FileName) + "が選択されました。");
                    MessageBox.Show("指定の番号のバイナリデータバイトは0x" + file.GetDataByte(0xD5)?.ToString("X2") + "です。");
                }
            }
        }
    }
}
