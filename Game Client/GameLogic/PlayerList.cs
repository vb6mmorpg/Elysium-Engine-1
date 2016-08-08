using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.GameLogic {
    public static class PlayerList {

        public static HashSet<EngineCharacter> Player { get; set; } = new HashSet<EngineCharacter>();

        public static EngineCharacter FindByID(int id) {
            var find_char = from pdata in Player
                            where pdata.ID == id
                            select pdata;

            return find_char.FirstOrDefault();
        }

        public class PlayerMoveData {
            public int dir;
            public int id;
        }

        /// <summary>
        /// Realiza a busca pelo número da sprite
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  public static PlayerData FindByID(int playerID) {
        //     var find_npc = from pData in Player
        //                     where pData.id.Equals(playerID)
        //                     select pData;

        //    return find_npc.FirstOrDefault();
        // }
    }




 
}
