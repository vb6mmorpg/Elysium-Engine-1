using System.Collections;

namespace GameServer.Server {
    public class Experience {        
        Hashtable experience = new Hashtable();

        /// <summary>
        /// Experiência de level.
        /// </summary>
        public static Experience Level { get; set; } = new Experience();

        /// <summary>
        /// Level máximo.
        /// </summary>
        public int LevelMax { get; set; }

        /// <summary>
        /// Indice de experiencia.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public long this[int level] {
            get {
                return (long)experience[level];
            }
            set {
                experience[level] = value;
            }

        }

        /// <summary>
        /// Adiciona o level e a experiência.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exp"></param>
        public void Add(int level, long exp) {
            experience.Add(level, exp);
        }
        
        /// <summary>
        /// Obtem a exp do próximo level.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public long GetNextLevelExp(int level) {
            if (level >= LevelMax)
                return (long)experience[LevelMax];

            return (long)experience[++level];
        }

        /// <summary>
        /// Obtem a exp máxima.
        /// </summary>
        /// <returns></returns>
        public long GetMaxExp() {
            return (long)experience[LevelMax];
        }
        /// <summary>
        /// Limpa os dados do hashset.
        /// </summary>
        public void Clear() {
            experience.Clear();
            experience = null;
        }
    }
}
