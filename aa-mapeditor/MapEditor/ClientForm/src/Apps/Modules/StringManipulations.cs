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
//      File name       : StringManipulations.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/07
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace ClientForm.src.Apps.Modules
{
    /// <summary>
    ///  General-purpose class related to string manipulation.
    /// </summary>
    internal static class StringManipulations
    {
        /// <summary>
        ///  Separates a 2-digit hexadecimal number into character units.
        /// </summary>
        /// <param name="hexBytes">Expression bytes</param>
        /// <param name="upperBytes">Output parameter 1</param>
        /// <param name="lowerBytes">Output parameter 2</param>
        internal static void SplitHexBytes(string hexBytes, out string upperBytes, out string lowerBytes)
        {
            if (hexBytes.Length == 1)
            {
                // If the string is one character, the upper byte is "0" and the lower byte is that character.
                upperBytes = "0";
                lowerBytes = hexBytes;
            }
            else if (hexBytes.Length >= 2)
            {
                // If the string has two or more characters, the first character is the high byte and the next character is the low byte.
                upperBytes = "0" + hexBytes[0];
                lowerBytes = "0" + hexBytes[1];
            }
            else
            {
                // If empty, set both to "00".
                upperBytes = "00";
                lowerBytes = "00";
            }
        }
    }
}
