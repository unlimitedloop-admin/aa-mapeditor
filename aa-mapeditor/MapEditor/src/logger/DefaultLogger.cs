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
//      File name       : DefaultLogger.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/30
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.logger
{
    /// <summary>
    ///  A class that encapsulates methods for controlling log output.
    /// </summary>
    internal class DefaultLogger
    {
        /// <summary>
        ///  Output log filepath.
        /// </summary>
        private static readonly string _logFilePath = "";


        static DefaultLogger()
        {
            string exedirectory = AppDomain.CurrentDomain.BaseDirectory;
            string currentdate = DateTime.Now.ToString("yyyyMMdd");
            string logfilename = $"{currentdate}_system.log";
            _logFilePath = Path.Combine(exedirectory, logfilename);
        }

        /// <summary>
        ///  Please use this to output error log information.
        /// </summary>
        /// <param name="message">Specify exception messages, etc.</param>
        public static void LogError(string message)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        /// <summary>
        ///  Please use this to output infomation log.
        /// </summary>
        /// <param name="message">The log content you want to output</param>
        public static void LogInfo(string message)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}
