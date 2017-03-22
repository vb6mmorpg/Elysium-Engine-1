using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Npcs;
using GameServer.Server;
using GameServer.Network;

namespace GameServer.Maps {
    public class MapData {
        /// <summary>
        /// ID do mapa.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Lista de jogadores no mapa.
        /// </summary>
        public HashSet<int> CharacterID { get; set; } = new HashSet<int>();

        /// <summary>
        /// Lista de Npc
        /// </summary>
        public HashSet<NpcData> Npc { get; set; } = new HashSet<NpcData>();

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="id"></param>
        public MapData(int id) {
            ID = id;
        }

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
        /// Envia jogador para todos do mapa.
        /// </summary>
        /// <param name="pData"></param>
        public void SendPlayerToMap(PlayerData pData) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                MapPacket.SendMapPlayer(playerData.Connection, pData.CharacterID, pData.CharacterName, pData.Sprite, pData.Direction, pData.PosX, pData.PosY);
            }
        }

        /// <summary>
        /// Envia cada jogador do mapa para determinado jogador.
        /// </summary>
        /// <param name="pData"></param>
        public void GetPlayerOnMap(PlayerData pData) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                MapPacket.SendMapPlayer(pData.Connection, playerData.CharacterID, playerData.CharacterName, playerData.Sprite, playerData.Direction, playerData.PosX, playerData.PosY);
            }
        }

        /// <summary>
        /// Envia o movimento do jogador para o mapa.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="dir"></param>
        public void SendPlayerMove(PlayerData pData, byte dir) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                MapPacket.SendPlayerMapMove(playerData.Connection, pData.CharacterID, dir);
            }
        }

        /// <summary>
        /// Remove um jogador do mapa.
        /// </summary>
        /// <param name="id"></param>
        public void RemovePlayer(int characterID) {
            CharacterID.Remove(characterID);

            foreach (int id in CharacterID) {
                var pData = Authentication.FindByCharacterID(id);

                if (pData.CharacterID == characterID) { continue; }

                MapPacket.RemovePlayerOnMap(pData.Connection, characterID);
            }
        }
    }
}