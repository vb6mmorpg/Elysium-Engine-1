using System.Collections.Generic;
using WorldServer.Common;
using WorldServer.Items;

namespace WorldServer.Server {
    public class Classe {
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Mind { get; set; }
        public int Charisma { get; set; }
        public int Points { get; set; }

        /// <summary>
        /// ID de classe.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de icnremento
        /// </summary>
        public int IncrementID { get; set; }

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<Classe> Classes { get; set; }

        /// <summary>
        /// Items de inicialização do personagem.
        /// </summary>
        private Item[] _item = new Item[Settings.MAX_ITEM];

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            for (var index = 0; index < Settings.MAX_ITEM; index++) {
                _item[index] = new Item();
            }
        }

        /// <summary>
        /// Obtem o item.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Item GetItem(ItemType type) {
            return _item[(int)type];
        }

        /// <summary>
        /// Altera um item.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        public void SetItem(ItemType type, Item item) {
            _item[(int)type] = item;
        }

        /// <summary>
        /// Procura pelo indice da classe na lista.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int FindClasseIndexByID(int classeID) {
            for(var index = 0; index < Classes.Count; index++) {
                if (Classes[index].ID == classeID) return index;
            }

            return -1;
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        private void ClearData() {
            Classes.Clear();
            Classes = null;

            _item = null;         
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        public static void Clear() {
            foreach(var classe in Classes) { classe.ClearData(); }
        }
    }
}
