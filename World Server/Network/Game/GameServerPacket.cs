using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using WorldServer.Common;
using WorldServer.Server;


namespace WorldServer.Network {
    public class GameServerPacket {
        /// <summary>
        /// Envia todos os dados para o GameServer selecionado pelo cliente / servidor.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldID"></param>
        public static void Login(string hexID, int serverID) {
            var pData = Authentication.FindByHexID(hexID);
            var buffer = GameServerNetwork.GameServer[serverID].Socket.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_GameServer_GameServerLogin);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.AccountID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.CharacterID);
            buffer.Write(pData.CharSlot);

            //pega a quantidade de serviços
            var servicesID = pData.Service.ServicesID();
            buffer.Write(servicesID.Length);

            //escreve cada um no buffer
            foreach (var id in servicesID) buffer.Write(pData.Service.ServiceTime(id));

            GameServerNetwork.GameServer[serverID].SendData(buffer);  
        }

        public static void SendHexID(int index) {
            var buffer = GameServerNetwork.GameServer[index].Socket.CreateMessage();
            buffer.Write((int)PacketList.Client_WorldServer_SendPlayerHexID);
            buffer.Write(Settings.WorldServerName);

            GameServerNetwork.GameServer[index].SendData(buffer);
        }
    }
}
