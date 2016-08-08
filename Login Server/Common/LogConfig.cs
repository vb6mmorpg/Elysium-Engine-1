using System;
using System.IO;

namespace LoginServer.Common {
    public static class LogConfig {
        const int ENABLED = 1;
        const int DISABLED = 0;

        static string fileLog = $"{DateTime.Today.Year} - {DateTime.Today.Month} - {DateTime.Today.Day}.txt";
        static FileStream file;
        static StreamWriter writer;

        /// <summary>
        /// Abre o arquivo no modo de escrita.
        /// </summary>
        public static void OpenFileLog() {
            file = new FileStream(Environment.CurrentDirectory + $@"\Log\{fileLog}", FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(file);
        }

        /// <summary>
        /// Fecha o arquivo.
        /// </summary>
        public static void CloseFileLog() {
            writer.Close();
            file.Close();
        }

        /// <summary>
        /// Escreve no arquivo de logs.
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLog(string text) {
            if (Settings.LogSystem == DISABLED) { return; }
            writer.WriteLine($"{DateTime.Now}: {text}");
            writer.Flush();
        }  

        /// <summary>
        /// Escreve a mensagem na tela.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="color"></param>
        public static void WriteLog(string log, System.Drawing.Color color) {
            if (!Settings.LogSystemScreen) { Settings.ConnectForm.WriteLog(log, color); }
        }
    }
}
