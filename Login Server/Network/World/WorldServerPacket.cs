using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;
using System;

namespace LoginServer.Network { 
    public class WorldServerPacket {
        /// <summary>
        /// Envia todos os dados para o WorldServer que selecionado pelo cliente.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldID"></param>
        public static void Login(string hexID, int worldID) {
            LoginServerPacket.HexID(hexID, hexID);

            var pData = Authentication.FindByHexID(hexID);
            var buffer = WorldServerNetwork.WorldServer[worldID].Socket.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_SendPlayerHexID);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.ID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);

            //pega a quantidade de serviços
            var servicesID = pData.Service.ServicesID();
            buffer.Write(servicesID.Length);

            //escreve cada um no buffer
            foreach (var id in servicesID) buffer.Write(pData.Service.ServiceTime(id));

            WorldServerNetwork.WorldServer[worldID].SendData(buffer);

            LogConfig.WriteLog($"World Server Login Attempt: {pData.Account} {pData.IP}"); 
            LogConfig.WriteLog($"World Server Login Attempt: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 
        } 

        /// <summary>
        /// Verifica se o usuário já está conectado em algum outro servidor.
        /// </summary>
        /// <param name="username"></param>
        public static void IsPlayerConnected(string username) {
            NetOutgoingMessage buffer;

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                buffer = WorldServerNetwork.WorldServer[n].Socket.CreateMessage();
                buffer.Write((int)PacketList.LoginServer_WorldServer_IsPlayerConnected);
                buffer.Write(username);

                WorldServerNetwork.WorldServer[n].SendData(buffer);
            }           
        }

        /// <summary>
        /// Desconecta o jogador em outros servidores.
        /// </summary>
        /// <param name="username"></param>
        public static void PlayerDisconnect(string username) {
            var pData = Authentication.FindByAccount(username);
            NetOutgoingMessage buffer;

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                if (pData.WorldResult[n]) {
                    buffer = WorldServerNetwork.WorldServer[n].Socket.CreateMessage();
                    buffer.Write((int)PacketList.LoginServer_WorldServer_DisconnectPlayer);
                    buffer.Write(username);

                    WorldServerNetwork.WorldServer[n].SendData(buffer);
                }               
            }
        }
    }
}
