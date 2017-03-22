using System;
using System.Drawing;
using System.IO;

namespace GameServer.Common {
    public class FileLog {
        // Main Form
        public static frmMain MainForm;

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
            writer.WriteLine($"{DateTime.Now}: {text}");
            writer.Flush();
        }

        public static void WriteLog(string log, Color color) {
            MainForm.general_textbox.SelectionStart = MainForm.general_textbox.TextLength;
            MainForm.general_textbox.SelectionLength = 0;

            MainForm.general_textbox.SelectionColor = color;
            MainForm.general_textbox.AppendText($"{DateTime.Now}: {log}{Environment.NewLine}");
            MainForm.general_textbox.SelectionColor = color;

            MainForm.general_textbox.ScrollToCaret();
            WriteLog(log);
        }
    }
}
