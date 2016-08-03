using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.GameLogic {
    public static class PlayerList {

        public static HashSet<EngineCharacter> Player { get; set; } = new HashSet<EngineCharacter>();

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
