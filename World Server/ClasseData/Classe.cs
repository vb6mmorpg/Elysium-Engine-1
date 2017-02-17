using System.Collections.Generic;
using WorldServer.Common;
using WorldServer.Items;

namespace WorldServer.ClasseData {
    public class Classe : StatsBase {
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
        /// Atributos de incremento
        /// </summary>
        public StatsIncrement Increment { get; set; }

        /// <summary>
        /// Items de inicialização do personagem.
        /// </summary>
        private Item[] _item = new Item[Constant.MAX_ITEM];

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            Increment = new StatsIncrement();

            for (var index = 0; index < Constant.MAX_ITEM; index++) {
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
        /// Obtém os stats de classe.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="cID"></param>
        /// <returns></returns>
        public int GetStat(StatType stat) {
            // Pega os valores para calculo
            int[] value = new int[Constant.MAX_STATS];
            value[0] = Level;
            value[1] = Strenght;
            value[2] = Dexterity;
            value[3] = Agility;
            value[4] = Constitution;
            value[5] = Intelligence;
            value[6] = Wisdom;
            value[7] = Will;
            value[8] = Mind;
            value[9] = Charisma;

            //stats base + level * incremento por level
            switch (stat) {
                case StatType.MaxHP: return HP + Increment.GetIncrementStat(StatType.MaxHP, value);
                case StatType.MaxMP: return MP + Increment.GetIncrementStat(StatType.MaxMP, value);
                case StatType.MaxSP: return SP + Increment.GetIncrementStat(StatType.MaxSP, value);
                case StatType.Level: return Level;
            }

            return 0;
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

            Increment.Clear();
            Increment = null;

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
