﻿using System;
using System.Drawing;
using System.IO;

namespace GameServer.Common {
    public class LogConfig {
        // Main Form
        public static frmMain mainForm;

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
            mainForm.general_textbox.SelectionStart = mainForm.general_textbox.TextLength;
            mainForm.general_textbox.SelectionLength = 0;

            mainForm.general_textbox.SelectionColor = color;
            mainForm.general_textbox.AppendText($"{DateTime.Now}: {log}{Environment.NewLine}");
            mainForm.general_textbox.SelectionColor = color;

            mainForm.general_textbox.ScrollToCaret();
            WriteLog(log);
        }
    }
}
