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
//      File name       : ExceptionHandler.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/28
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Logger;
using System.Runtime.CompilerServices;



/* sources */
namespace ClientForm.src.Exceptions
{
    /// <summary>
    ///  A collection of callback methods that contain exception handling code.
    /// </summary>
    internal static class ExceptionHandler
    {
        /// <summary>
        ///  Provides an external action listener that does try and catch and logs when necessary.
        /// </summary>
        /// <param name="action">Lambda expression</param>
        /// <returns>Returns false if an exception occurs.</returns>
        internal static bool TryCatchWithLogging(Action action,
            [CallerFilePath] string sourceFilePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                action();
                return true;
            }
            catch(Exception ex)
            {
                if (ex is ArgumentException)
                {
                    _ = MessageBox.Show("無効な引数です。" + "\r\n" + ex, "ArgumentException info");
                }
                else if (ex is ArgumentNullException)
                {
                    _ = MessageBox.Show("無効なオブジェクト、または無効なメンバへのアクセスがありました。" + "\r\n" + ex, "ArgumentNullException info");
                }
                else if (ex is ArgumentOutOfRangeException)
                {
                    _ = MessageBox.Show("不測のメモリアクセス違反がありました。" + "\r\n" + ex, "ArgumentOutOfRangeException info");
                }
                else if (ex is FileNotFoundException)
                {
                    _ = MessageBox.Show("ファイルが見つかりませんでした。" + "\r\n" + ex, "FileNotFoundException info");
                }
                else if (ex is IndexOutOfRangeException)
                {
                    _ = MessageBox.Show("インデックスが配列の境界外でした。" + "\r\n" + ex, "IndexOutOfRangeException info");
                }
                else if (ex is InvalidCastException)
                {
                    _ = MessageBox.Show("無効なキャストが行われようとしました。" + "\r\n" + ex, "InvalidCastException info");
                }
                else if (ex is NullReferenceException)
                {
                    _ = MessageBox.Show("nullオブジェクトは参照できません。" + "\r\n" + ex, "NullReferenceException info");
                }
                else if (ex is ObjectDisposedException)
                {
                    _ = MessageBox.Show("オブジェクトは既に破棄されているか、アクセスできませんでした。" + "\r\n" + ex, "ObjectDisposedException info");
                }
                else
                {
                    _ = MessageBox.Show("想定しない例外が発生しました。" + "\r\n" + ex, "Exception info");
                }
                DefaultLogger.LogError(
                    "ファイル名：" + sourceFilePath + 
                    "、メンバ名：" + memberName + 
                    "、例外発生行：" + sourceLineNumber + 
                    "、例外メッセージ：" + ex);
                return false;
            }
        }
    }
}
