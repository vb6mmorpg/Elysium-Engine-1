using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;


namespace Elysium_Diamond.Network {
    public class CommonPacket {
        public static void RequestPing() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Ping);

            NetworkSocket.SendData(NetworkSocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
            Common.Configuration.PingStart = Environment.TickCount;
        }

    }
}
