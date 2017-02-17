using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Network;
using GameServer.Common;
using Lidgren.Network;

namespace GameServer.Maps {
    public class MapPacket {
        public static void SendNpc(NetConnection connection, int index) {
            var buffer = GameServerNetwork.Socket.CreateMessage();
        //    buffer.Write((int)PacketList.GameServer_SendNpc);
            buffer.Write(MapGeneral.Map.Npc.Count);

            foreach (var item in MapGeneral.Map.Npc) {
                buffer.Write(item.Sprite);
                buffer.Write(item.Level);
                buffer.Write(item.HP);
                buffer.Write(item.X);
                buffer.Write(item.Y);
            }

            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendMapPlayer(NetConnection connection, int playerID, string name, short sprite, short direction, short x, short y) {
            var buffer = GameServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_GetMapPlayer);
            buffer.Write(playerID);
            buffer.Write(name);
            buffer.Write(sprite);
            buffer.Write(direction);
            buffer.Write(x);
            buffer.Write(y);

            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);

        }

        public static void SendPlayerMapMove(NetConnection connection, int playerID, short direction) {
            var buffer = GameServerNetwork.Socket.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerMapMove);
            buffer.Write(playerID);
            buffer.Write(direction);

            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
