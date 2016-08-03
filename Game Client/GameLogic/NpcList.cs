using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.GameLogic {
    public class NpcData {
        public static HashSet<EngineNpc> Npc { get; set; }

        /// <summary>
        /// Realiza a busca pelo número da sprite
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EngineNpc FindByID(int id) {
            var find_npc = from nData in Npc
                               where nData.ID.Equals(id)
                               select nData;

            return find_npc.FirstOrDefault();
        }
    }
}
