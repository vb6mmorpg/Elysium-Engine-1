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
            var buffer = WorldNetwork.WorldServer[worldID].CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_SendPlayerHexID);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.ID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);

            //pega e escreve a quantidade de serviços
            int[] servicesID = pData.Service.GetServicesID();

            buffer.Write(pData.Service.Count());

            //escreve cada serviço no buffer
            foreach (var id in servicesID) {
                buffer.Write(pData.Service.GetServiceTime(id));
            }

            WorldNetwork.WorldServer[worldID].SendData(buffer);

            FileLog.WriteLog($"World Server {Settings.Server[worldID].Name} Login Attempt: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 
        } 

        /// <summary>
        /// Verifica se o usuário já está conectado em algum outro servidor.
        /// </summary>
        /// <param name="username"></param>
        public static void IsPlayerConnected(string username) {
            //primeiro servidor world
            const int WORLD_N1 = 0;

            //cria a mensagem somente uma vez.
            var buffer = WorldNetwork.WorldServer[WORLD_N1]?.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_IsPlayerConnected);
            buffer.Write(username);

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                WorldNetwork.WorldServer[n].SendData(buffer);
            }
        }

        /// <summary>
        /// Desconecta o jogador em outros servidores.
        /// </summary>
        /// <param name="username"></param>
        public static void PlayerDisconnect(PlayerData pData) {
            //primeiro servidor world
            const int WORLD_N1 = 0;

            //cria a mensagem somente uma vez.
            var buffer = WorldNetwork.WorldServer[WORLD_N1]?.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_DisconnectPlayer);
            buffer.Write(pData.Username);

            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                if (pData.WorldResult[n]) {
                    WorldNetwork.WorldServer[n].SendData(buffer);
                }               
            }
        }
    }
}
