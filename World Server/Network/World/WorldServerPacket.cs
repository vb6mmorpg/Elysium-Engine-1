using Lidgren.Network;
using WorldServer.Server;
using WorldServer.Common;
using WorldServer.GameGuild;

namespace WorldServer.Network {
    public class WorldServerPacket {
        /// <summary>
        /// Envia o pedido de hexid para o cliente.
        /// </summary>
        /// <param name="index"></param>
        public static void NeedHexID(NetConnection connection) {
            var buffer = WorldServerNetwork.Socket.CreateMessage(4);
            buffer.Write((int)PacketList.WorldServer_Client_NeedPlayerHexID);
            WorldServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteúdo.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void Message(string hexID, int value) {
            var buffer = WorldServerNetwork.Socket.CreateMessage(4);
            buffer.Write(value);
            WorldServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteudo.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        public static void Message(NetConnection connection, int value) {
            var buffer = WorldServerNetwork.Socket.CreateMessage(4);
            buffer.Write(value);
            WorldServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração de 'GameState'.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void GameState(string hexID, int value) {
            var buffer = WorldServerNetwork.Socket.CreateMessage(8);
            buffer.Write((int)PacketList.ChangeGameState);
            buffer.Write(value);
            WorldServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os dados básico dos personagens.
        /// </summary>
        /// <param name="hexID"></param>
        public static void PreLoad(PlayerData pData) {
            var buffer = WorldServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_Client_CharacterPreLoad);

            for (var n = 0; n < 4; n++) {
                buffer.Write(pData.Character[n].Name);
                buffer.Write(pData.Character[n].Class);
                buffer.Write(pData.Character[n].Sprite);
                buffer.Write(pData.Character[n].Level);
            }
 
            WorldServerNetwork.SendDataTo(pData.HexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    
        public static void SendGameServerData(NetConnection connection, string hexID) {
            var buffer = WorldServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_Client_GameServerData);
            buffer.Write(hexID);
            buffer.Write(Settings.GameServer[0].GameServerIP);
            buffer.Write(Settings.GameServer[0].GameServerPort);
                
            WorldServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        } 
        
        public static void SendGuildInfo(PlayerData pData) {
            Guild guild = Guild.FindGuildByID(pData.GuildID);

            var buffer = WorldServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_Client_GuildInfo);
            buffer.Write(guild.OwnerName);
            buffer.Write(guild.Name);
            buffer.Write(guild.Member.Count);
            buffer.Write(guild.OnlineMember);
            buffer.Write(guild.Announcement);      

            WorldServerNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a resposta para o login server se o usuario foi encontrado.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        /// <param name="username"></param>
        public static void SendConnectedResult(NetConnection connection, bool value, string username) {
            var buffer = WorldServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.LoginServer_WorldServer_IsPlayerConnected);
            buffer.Write(value);
            buffer.Write(username);

            WorldServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
