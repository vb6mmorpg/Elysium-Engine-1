using System.Collections.Generic;
using System.Linq;

namespace WorldServer.GameGuild {
    public partial class Guild {
        public static HashSet<Guild> Guilds { get; set; }

        /// <summary>
        /// Realiza uma busca pelo ID de guild.
        /// </summary>
        /// <param name="gID"></param>
        /// <returns></returns>
        public static Guild FindGuildByID(int gID) {
            var find_value = from gData in Guilds
                          where gData.ID.CompareTo(gID) == 0
                          select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de guild.
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public static Guild FindGuildByName(string gName) {
            var find_value = from gData in Guilds
                          where gData.Name.CompareTo(gName) == 0
                          select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID do dono de guild.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static Guild FindGuildByOwnerID(int pID) {
            var find_value = from gData in Guilds
                          where gData.OwnerID.CompareTo(pID) == 0
                          select gData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome do dono de guild.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static Guild FindGuildByOwnerName(int pName) {
            var find_value = from gData in Guilds
                          where gData.OwnerName.CompareTo(pName) == 0
                          select gData;

            return find_value.FirstOrDefault();
        }
    }
}
