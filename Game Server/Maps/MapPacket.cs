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
       //     var buffer = GameNetwork.CreateMessage();
         //   buffer.Write((int)PacketList.GameServer_SendNpc);
        //    buffer.Write(MapManager.Map.Npc.Count);

           // foreach (var item in MapManager.Map.Npc) {
          //      buffer.Write(item.Sprite);
        //        buffer.Write(item.Level);
       //         buffer.Write(item.HP);
        //        buffer.Write(item.X);
        //        buffer.Write(item.Y);
        //    }

        //    GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendMapPlayer(NetConnection connection, int playerID, string name, short sprite, byte direction, short x, short y) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_GetMapPlayer);
            buffer.Write(playerID);
            buffer.Write(name);
            buffer.Write(sprite);
            buffer.Write(direction);
            buffer.Write(x);
            buffer.Write(y);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);

        }

        public static void RemovePlayerOnMap(NetConnection connection, int playerID) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_RemovePlayerFromMap);
            buffer.Write(playerID);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendPlayerMapMove(NetConnection connection, int playerID, byte direction) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerMapMove);
            buffer.Write(playerID);
            buffer.Write(direction);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
