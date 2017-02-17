using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public static class GameServerPacket {
        /// <summary>
        /// Envia o hexid para o game server.
        /// </summary>
        public static void GameServerHexID() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_SendPlayerHexID);
            buffer.Write(Configuration.HexID);
            NetworkSocket.SendData(NetworkSocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
        }

        /// <summary>
        /// Envia o movimento do personagem.
        /// </summary>
        /// <param name="dir"></param>
        public static void PlayerMove(EngineCharacter.Direction dir) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_PlayerMove);
            buffer.Write((int)dir);
            NetworkSocket.SendData(NetworkSocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
        }
    }
}
