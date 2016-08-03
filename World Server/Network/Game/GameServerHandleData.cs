using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using WorldServer.Common;

namespace WorldServer.Network {

    public class GameServerHandleData {
        public static void HandleData(int index, NetIncomingMessage data) {
            // Packet Header //
            var MsgType = data.ReadInt32();

            // Check Packet Header Number //
            if (MsgType < 0) { return; }

            // Handle Incoming Message //
            switch (MsgType) {
                case (int)PacketList.None: break;
                case (int)PacketList.Client_WorldServer_SendPlayerHexID: GameServerPacket.SendHexID(index); break;
            }
        }

    
    }
}
