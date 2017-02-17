using System.Collections.Generic;
using System.Linq;

namespace WorldServer.Server {
    public static class ProhibitedNames {

        /// <summary>
        /// Lista de nomes banidos.
        /// </summary>
        private static HashSet<string> Names { get; set; } = new HashSet<string>();

        /// <summary>
        /// Adiciona um nome a lista.
        /// </summary>
        /// <param name="name"></param>
        public static void Add(string name) {
            Names.Add(name);
        }

        /// <summary>
        /// Adiciona um array de nomes.
        /// </summary>
        /// <param name="name"></param>
        public static void AddRange(params string[] name) {
            foreach(string item in name) {
                Names.Add(item);
            }
        }
            
        /// <summary>
        /// Realiza a comparação entre dois items.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Compare(string name) {
            if (FindName(name))  return true; 
            return false;
        }

        /// <summary>
        /// Procura o item no hashset.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool FindName(string name) {
            if (string.IsNullOrEmpty(name))  return false; 

            var find_name = from nData in Names
                             where nData.CompareTo(name) == 0
                             select nData;

            return (string.IsNullOrEmpty(find_name.FirstOrDefault())) ? true : false;
        }

        /// <summary>
        /// Remove todos os items do hashset.
        /// </summary>
        public static void Clear() {
            Names.Clear();
            Names = null;
        }
    }
}
