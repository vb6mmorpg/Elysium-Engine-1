using Lidgren.Network;

namespace WorldServer.Network {

    public class GameData {
        public static void HandleData(int index, NetIncomingMessage msg) {
            if (msg.LengthBytes < 4) { return; }
            // Packet Header //
            var MsgType = msg.ReadInt32();

            // Check Packet Header Number //
            if (MsgType < 0) { return; }

            // Handle Incoming Message //
            switch (MsgType) {
                case (int)PacketList.None: break;
                case (int)PacketList.Client_WorldServer_SendPlayerHexID: GamePacket.HexID(index); break;
            }
        }
    }
}
