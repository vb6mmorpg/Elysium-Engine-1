using System;
using System.IO;

namespace Account_Editor.Common
{
    public static class ConfigGet
    {
        /// <summary>
        /// Retorna uma string a partir de um arquivo de texto.
        /// </summary>
        /// <param name="pcFile">Arquivo</param>
        /// <param name="target">Cabeçalho</param>
        /// <returns></returns>
        public static string ConfigGetString(string pcFile, string Target)
        {
            string pcLine = string.Empty;
            string[] pcFind;
            string pcResult = string.Empty;

            if (!File.Exists(pcFile)) { return string.Empty; }

            Stream fs;
            fs = File.Open(pcFile, FileMode.Open, FileAccess.Read);
            if (fs == null) { return string.Empty; }

            StreamReader fh = new StreamReader(fs);
            if (fh == null) { return string.Empty; }

            do
            {
                pcLine = fh.ReadLine();

                if (pcLine == null) { break; }

                pcFind = pcLine.Split('=');

                if (pcFind[0].Trim().CompareTo(Target) == 0)
                {
                    pcResult = pcFind[1].Trim();
                    break;
                }
            }
            while (pcLine != null);

            fs.Flush();
            fs.Close();
            fs.Dispose();
            fh.Close();
            fh.Dispose();

            return pcResult;
        }

        /// <summary>
        /// Retorna um inteiro a partir de um arquivo de texto.
        /// </summary>
        /// <param name="pcFile">Arquivo</param>
        /// <param name="target">Cabeçalho</param>
        /// <returns></returns>
        public static long ConfigGetLong(string pcFile, string Target)
        {
            string pcLine = string.Empty;
            string[] pcFind;
            long pcResult;

            pcResult = 0x00;

            if (!File.Exists(pcFile)) { return 0; }

            Stream fs;
            fs = File.Open(pcFile, FileMode.Open, FileAccess.Read);
            if (fs == null) { return 0; }

            StreamReader fh = new StreamReader(fs);
            if (fh == null) { return 0; }

            do
            {
                pcLine = fh.ReadLine();
                if (pcLine == null) { break; }

                pcFind = pcLine.Split('=');

                if (pcFind[0].Trim().CompareTo(Target) == 0)
                {
                    foreach (char n in pcFind[1]) { if (!char.IsNumber(n)) { break; } }

                    pcResult = Convert.ToInt64(pcFind[1].Trim());
                    break;
                }
            }
            while (pcLine != null);

            fs.Flush();
            fs.Close();
            fs.Dispose();
            fh.Close();
            fh.Dispose();

            return pcResult;
        }
    }
}
