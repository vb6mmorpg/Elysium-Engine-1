using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;
using System;

namespace LoginServer.Network { 
    public class WorldPacket {
        /// <summary>
        /// Envia todos os dados para o WorldServer que selecionado pelo cliente.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldID"></param>
        public static void Login(string hexID, int worldID) {
            LoginPacket.HexID(hexID, hexID);

            var pData = Authentication.FindByHexID(hexID);
            var buffer = WorldNetwork.WorldServer[worldID].Socket.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_SendPlayerHexID);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.ID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);

            //pega a quantidade de serviços
            int[] servicesID = pData.Service.ServicesID();
            buffer.Write(pData.Service.Count());

            //escreve cada serviço no buffer
            foreach (var id in servicesID) buffer.Write(pData.Service.ServiceTime(id));

            WorldNetwork.WorldServer[worldID].SendData(buffer);

            FileLog.WriteLog($"World Server {Settings.Server[worldID].Name} Login Attempt: {pData.Account} {pData.IP}"); 
            FileLog.WriteLog($"World Server {Settings.Server[worldID].Name} Login Attempt: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 
        } 

        /// <summary>
        /// Verifica se o usuário já está conectado em algum outro servidor.
        /// </summary>
        /// <param name="username"></param>
        public static void IsPlayerConnected(string username) {
            NetOutgoingMessage buffer;

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                buffer = WorldNetwork.WorldServer[n].Socket.CreateMessage();
                buffer.Write((int)PacketList.LoginServer_WorldServer_IsPlayerConnected);
                buffer.Write(username);

                WorldNetwork.WorldServer[n].SendData(buffer);
            }           
        }

        /// <summary>
        /// Desconecta o jogador em outros servidores.
        /// </summary>
        /// <param name="username"></param>
        public static void PlayerDisconnect(PlayerData pData) {
            NetOutgoingMessage buffer;

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                if (pData.WorldResult[n]) {
                    buffer = WorldNetwork.WorldServer[n].Socket.CreateMessage();
                    buffer.Write((int)PacketList.LoginServer_WorldServer_DisconnectPlayer);
                    buffer.Write(pData.Username);

                    WorldNetwork.WorldServer[n].SendData(buffer);
                }               
            }
        }
    }
}
