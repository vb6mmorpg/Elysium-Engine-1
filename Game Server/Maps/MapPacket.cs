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
            var buffer = GameServerNetwork.sSock.CreateMessage();
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
    }
}
