using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.GameClient {
    public static class Client {
        public static PlayerData PlayerLocal = new PlayerData();
        public static HashSet<EngineCharacter> Player = new HashSet<EngineCharacter>();

        /// <summary>
        /// Realiza uma busca pelo ID do jogador.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EngineCharacter FindPlayerByID(int id) {
            if (id == 0) { return null; }

            var find = from pData in Player
                       where pData.ID == id
                       select pData;

            return find.FirstOrDefault();
        }
    }
}
