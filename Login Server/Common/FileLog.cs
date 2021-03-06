﻿using System;
using System.IO;

namespace LoginServer.Common {
    public static class FileLog {
        const int ENABLED = 1;
        const int DISABLED = 0;

        static string fileLog = $"{DateTime.Today.Year} - {DateTime.Today.Month} - {DateTime.Today.Day}.txt";
        static FileStream file;
        static StreamWriter writer;

        /// <summary>
        /// Abre o arquivo no modo de escrita.
        /// </summary>
        public static void OpenFileLog() {
            file = new FileStream(Environment.CurrentDirectory + $"\\Log\\{fileLog}", FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(file);
        }

        /// <summary>
        /// Fecha o arquivo e libera os recursos.
        /// </summary>
        public static void CloseFileLog() {
            writer.Close();
            file.Close();

            writer.Dispose();
            file.Dispose();
        }

        /// <summary>
        /// Escreve no arquivo de logs.
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLog(string text) {
            writer.WriteLine($"{DateTime.Now}: {text}");
            writer.Flush();
        }

        /// <summary>
        /// Escreve a mensagem na tela.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="color"></param>
        public static void WriteLog(string log, System.Drawing.Color color) {
            if (Settings.LogSystem == DISABLED) { return; }

            Settings.ConnectForm.WriteLog(log, color);
            WriteLog(log);
        }
    }
}
