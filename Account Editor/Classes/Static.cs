using System.Collections.Generic;

namespace AccountEditor {
    public class Static {
        /// <summary>
        /// Quantidade máxima de personagens.
        /// </summary>
        public const int MAX_CHARACTER = 4;

        public static List<Classe> Classes { get; set; } = new List<Classe>();

        /// <summary>
        /// Procura o índice pelo ID da classe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int FindIndexByID(int id) {
            var count = Classes.Count;

            for (var index = 0; index < count; index++) {
                if (Classes[index].ID == id) {
                    return index;
                }
            }

            return -1;
        }
    }
}
