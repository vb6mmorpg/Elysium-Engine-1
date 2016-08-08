using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using GameServer.Common;
using GameServer.Server;
using GameServer.GameGuild;

namespace GameServer.Network {
    public class GameServerPacket {
        /// <summary>
        /// Envia o pedido de hexid
        /// </summary>
        /// <param name="index"></param>
        public static void NeedHexID(NetConnection connection) {
            var buffer = GameServerNetwork.sSock.CreateMessage(4);
            buffer.Write((int)PacketList.GameServer_Client_NeedHexID);
            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteúdo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void Message(string hexID, int value) {
            var buffer = GameServerNetwork.sSock.CreateMessage(8);
            buffer.Write(value);
            GameServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void Message(NetConnection connection, int value) {
            var buffer = GameServerNetwork.sSock.CreateMessage(4);
            buffer.Write(value);
            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração de 'GameState'
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void GameState(string hexID, int value) {
            var buffer = GameServerNetwork.sSock.CreateMessage(8);
            buffer.Write((int)PacketList.ChangeGameState);
            buffer.Write(value);
            GameServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia informações de guild.
        /// </summary>
        /// <param name="hexID"></param>
        public static void SendGuild(string hexID) {
            var pData = Authentication.FindByHexID(hexID);

            if (pData.GuildID == 0) { return; }

            var gData = Guild.FindGuildByID(pData.GuildID);

            var buffer = GameServerNetwork.sSock.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_Client_GuildInfo);
            buffer.Write(gData.OwnerName);
            buffer.Write(gData.Name);
            buffer.Write(gData.Member.Count);
            buffer.Write(gData.OnlineMember);
            buffer.Write(gData.Announcement);

            GameServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia membros de guild.
        /// </summary>
        /// <param name="hexID"></param>
        public static void SendMember(string hexID) {
            var pData = Authentication.FindByHexID(hexID);

            if (pData.GuildID == 0) { return; }

            var gData = Guild.FindGuildByID(pData.GuildID);

            var buffer = GameServerNetwork.sSock.CreateMessage();
            buffer.Write((int)PacketList.WorldServer_Client_GuildMemberInfo);

            buffer.Write(gData.Member.Count - 1);

            foreach (var mData in gData.Member) {
                buffer.Write(mData.Name);
                buffer.Write(mData.SelfIntro);
                buffer.Write(mData.Status);
            }

            GameServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendPlayerData(string hexID) {
            var pData = Authentication.FindByHexID(hexID);

            var buffer = GameServerNetwork.sSock.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerData);
            buffer.Write(pData.CharacterName);
            buffer.Write(Guild.FindGuildByID(pData.GuildID)?.Name ?? string.Empty);
            buffer.Write(pData.Sprite);
            buffer.Write(pData.Level);
            buffer.Write(pData.Exp);
            buffer.Write(pData.Direction);
            buffer.Write(pData.PosX);
            buffer.Write(pData.PosY);

            GameServerNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
