using GameServer.Server;
using GameServer.Common;
using Lidgren.Network;

namespace GameServer.Network {
    public class GameData {
        public static void HandleData(NetConnection connection, NetIncomingMessage data) {
            if (data.LengthBytes < 4) { return; }

            var msgType = data.ReadInt32();

            // Check Packet Number
            if (msgType < 0) { return; }

            switch (msgType) {
                case (int)PacketList.None: break;
                case (int)PacketList.Ping: Ping(connection); break;
                case (int)PacketList.WorldServer_GameServer_GameServerLogin: Authentication.AddHexID(data); break;
                case (int)PacketList.Client_GameServer_SendPlayerHexID: Authentication.ReceiveHexID(connection, data.ReadString()); break;
                case (int)PacketList.Client_GameServer_PlayerMove: PlayerMove(connection, data.ReadByte()); break;
            }
        }

        public static void Ping(NetConnection connection) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.Ping);
            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia o movimento do jogador pelo mapa.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="dir"></param>
        public static void PlayerMove(NetConnection connection, byte dir) {
            var pData = Authentication.FindByConnection(connection);

            pData.Direction = dir;

            switch (dir) {
                case (int)Direction.Up:
                    pData.PosY--;
                    break;
                case (int)Direction.Down:
                    pData.PosY++;
                    break;
                case (int)Direction.Left:
                    pData.PosX--;
                    break;
                case (int)Direction.Right:
                    pData.PosX++;
                    break;
            }

            Maps.MapManager.FindMapByID(pData.WorldID).SendPlayerMove(pData, dir);
        }
    }
}
