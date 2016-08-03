using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Linq;

// @author Paulo Soreto
// @date    03/01/2015
// @contact psoreto@gmail.com

namespace Classe_Editor {
    public static class Configuration {
        static Hashtable cache = new Hashtable();

        /// <summary>
        /// Lê o arquivo de configuração e armazena as informações.
        /// </summary>
        /// <param name="fileName"></param>
        public static void ParseConfigFile(string fileName) {
            if (!File.Exists(fileName))
                throw new Exception("cannot find server configuration file");

            using (StreamReader reader = new StreamReader(fileName, Encoding.Unicode)) {
                string[] validLines = reader.ReadToEnd().Split('\n').Where(l => !l.StartsWith("//")).ToArray();
                foreach (string line in validLines) {
                    if (line == "\r")
                        continue;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parameters = line.Split('=');
                    cache.Add(parameters[0].Trim(), parameters[1].Trim());
                }
            }
        }

        /// <summary>
        /// Fecha o arquivo.
        /// </summary>
        public static void CloseConfigFile() {
            cache = null;
        }

        /// <summary>
        /// Converte e retorna um bool.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetBoolean(string key) {
            return Convert.ToBoolean(Convert.ToInt32(cache[key]));
        }

        /// <summary>
        /// Converte e retorna em byte.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte GetByte(string key) {
            return Convert.ToByte(cache[key]);
        }
        /// <summary>
        /// Retorna um inteiro de 32 bits.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt32(string key) {
            return Convert.ToInt32(cache[key]);
        }

        /// <summary>
        /// Retorna um inteiro de 64 bits.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long GetInt64(string key) {
            return Convert.ToInt64(cache[key]);
        }

        /// <summary>
        /// Converte para string.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key) {
            return cache[key].ToString();
        }
    }
}


