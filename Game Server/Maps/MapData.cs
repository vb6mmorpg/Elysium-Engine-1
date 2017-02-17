using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Npcs;
using GameServer.Server;
using GameServer.Network;

namespace GameServer.Maps {
    public class MapData {
        public HashSet<int> PlayerID { get; set; } = new HashSet<int>();
        public HashSet<NpcData> Npc { get; set; } = new HashSet<NpcData>();

        //public MapLimit RegionLimit { get; set; }
        //public HashSet<ObjectData> MapObject { get; set; }
        //public HashSet<ItemDrop> MapItems { get; set; }
        //public HashSet<MapAttributeData> MapAttribute { get; set; }

        /// <summary>
        /// Encontra um npc pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NpcData FindNpcByID(int npcID) {
            var find_npc = from nData in Npc
                           where nData.ID == npcID
                           select nData;

            return find_npc.FirstOrDefault();
        }

        /// <summary>
        /// Envia determinado jogador para todos do mapa.
        /// </summary>
        /// <param name="pData"></param>
        public void SendPlayerToMap(PlayerData pData) {
            foreach (int playerID in PlayerID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByAccountID(playerID);

                //se for o mesmo jogador, ignora
                if (playerData.AccountID == pData.AccountID) { continue; }

                MapPacket.SendMapPlayer(playerData.Connection, pData.AccountID, pData.CharacterName, pData.Sprite, pData.Direction, pData.PosX, pData.PosY);
            }
        }

        /// <summary>
        /// Envia cada jogador do mapa para determinado jogador.
        /// </summary>
        /// <param name="pData"></param>
        public void GetPlayerOnMap(PlayerData pData) {
            foreach (int playerID in PlayerID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByAccountID(playerID);

                //se for o mesmo jogador, ignora
                if (playerData.AccountID == pData.AccountID) { continue; }

                MapPacket.SendMapPlayer(pData.Connection, playerData.AccountID, playerData.CharacterName, playerData.Sprite, playerData.Direction, playerData.PosX, playerData.PosY);
            }
        }

        public void SendPlayerMove(PlayerData pData, short dir) {
            foreach (int playerID in PlayerID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByAccountID(playerID);

                //se for o mesmo jogador, ignora
                if (playerData.AccountID == pData.AccountID) { continue; }

                MapPacket.SendPlayerMapMove(playerData.Connection, pData.AccountID, dir);
            }
        }


        public void ExecuteMapAI() {

        }
        public void ExecuteNpcAI() {

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
