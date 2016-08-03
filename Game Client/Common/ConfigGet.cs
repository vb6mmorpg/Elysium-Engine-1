using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Elysium_Diamond.Common
{
    public static class ConfigGet
    {
        /// <summary>
        /// Retorna uma string contida em um arquivo de texto.
        /// </summary>
        /// <param name="pcFile">Arquivo</param>
        /// <param name="Target">Secção</param>
        /// <returns></returns>
        public static string ConfigGetString(string pcFile, string Target)
        {
            var pcLine = string.Empty;
            var pcResult = string.Empty;
            string[] pcFind;

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
        /// Retorna um long contido em um arquivo de texto.
        /// </summary>
        /// <param name="pcFile">Arquivo</param>
        /// <param name="Target">Secção</param>
        /// <returns></returns>
        public static long ConfigGetLong(string pcFile, string Target)
        {
            var pcLine = string.Empty;
            long pcResult = 0x00;
            string[] pcFind;

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


