using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Npcs;
using GameServer.Server;
using GameServer.Network;

namespace GameServer.Maps {
    public class MapData {
        public HashSet<NpcData> Npc { get; set; } = new HashSet<NpcData>();
        //public HashSet<PlayerData> Player { get; set; } = new HashSet<PlayerData>();
        public List<int> Player { get; set; } = new List<int>();

        /// <summary>
        /// Encontra um npc pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NpcData FindByID(int id) {
            var find_npc = from nData in Npc
                           where nData.ID == id
                           select nData;

            return find_npc.FirstOrDefault();
        }

        public void GetPlayersOnMap(PlayerData pData) {
            foreach (int playerID in Player) {
                var tempData = Authentication.FindByID(playerID);

                if (pData.AccountID == tempData.AccountID) { continue; }

                GameServerPacket.SendMapPlayer(pData.Connection, tempData.AccountID, tempData.CharacterName, tempData.Sprite, tempData.PosX, tempData.PosY);

            }
        }

    }
}



/* public void InitializeMap() {
     var npc = (NpcData)NpcGeneral.FindByID(1).Clone();
     npc.X = 10 * 32;
     npc.Y = 5 * 32;

     Npc.Add(npc);

     npc = null;
     npc = (NpcData)NpcGeneral.FindByID(2).Clone();
     npc.X = 15 * 32;
     npc.Y = 13 * 32;

     Npc.Add(npc);

     npc = null;
     npc = (NpcData)NpcGeneral.FindByID(3).Clone();
     npc.X = 3 * 32;
     npc.Y = 10 * 32;

     Npc.Add(npc); 
}*/
