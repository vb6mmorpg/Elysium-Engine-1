using System;
using System.IO;

namespace WorldServer.Common {
    public static class LogConfig {
        /// <summary>
        /// Destino do arquivo.
        /// </summary>
        static string fileLog = $"{DateTime.Today.Year} - {DateTime.Today.Month} - {DateTime.Today.Day}.txt";
        static FileStream pcFile;
        static StreamWriter writer;

        /// <summary>
        /// Abre o arquivo de logs.
        /// </summary>
        public static void OpenFileLog() {
            pcFile = new FileStream($"{Environment.CurrentDirectory}\\Log\\{fileLog}", FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(pcFile);
        }

        /// <summary>
        /// Fecha o arquivo de logs.
        /// </summary>
        public static void CloseFileLog() {
            writer.Close();
            pcFile.Close();
        }

        /// <summary>
        /// Escreve no arquivo de logs.
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLog(string text) {
            writer.WriteLine(DateTime.Now + ": " + text);
            writer.Flush();
        }

        /// <summary>
        /// Imprime o texto na tela.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="color"></param>
        public static void WriteLog(string log, System.Drawing.Color color) {
            if (Settings.LogSystem == true) { WriteLog(log); }
            if (Program.WorldForm.Logs.Checked == false) { Program.WorldForm.WriteLog(log, color); }
        }
    }
}
