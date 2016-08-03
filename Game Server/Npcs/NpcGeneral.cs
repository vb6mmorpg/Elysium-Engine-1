using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Npcs {
    public class NpcGeneral {
        public static HashSet<NpcData> Npc { get; set; } 

        /// <summary>
        /// Encontra um npc pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NpcData FindByID(int id) {
            var find_npc = from nData in Npc
                           where nData.ID == id
                           select nData;

            return find_npc.FirstOrDefault();
        }
    }
}
