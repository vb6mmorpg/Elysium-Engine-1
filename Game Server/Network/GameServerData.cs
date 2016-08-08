using GameServer.Server;
using GameServer.Common;
using Lidgren.Network;

namespace GameServer.Network {
    public class GameServerData {
        public static void HandleData(NetConnection connection, NetIncomingMessage data) {
            // Packet Header //
            var MsgType = data.ReadInt32();

            // Check Packet Number
            if (MsgType < 0) { return; }

            switch (MsgType) {
                case (int)PacketList.None: break;
                case (int)PacketList.Ping: Ping(connection); break;
                case (int)PacketList.WorldServer_GameServer_GameServerLogin: Authentication.AddHexID(data); break;
                case (int)PacketList.Client_GameServer_SendPlayerHexID: Authentication.ReceiveHexID(connection, data.ReadString()); break;
                case (int)PacketList.Client_GameServer_PlayerMove: PlayerMove(connection, data.ReadInt32()); break;
            }
        }
        public static void Ping(NetConnection connection) {
            var buffer = GameServerNetwork.sSock.CreateMessage();
            buffer.Write((int)PacketList.Ping);
            GameServerNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        public static void PlayerMove(NetConnection connection, int dir) {
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

            Maps.MapGeneral.Map.SendPlayerMove(pData, dir);

            LogConfig.WriteLog(pData.CharacterName + " Dir: " + dir + " X: " + pData.PosX + " Y: " + pData.PosY, System.Drawing.Color.Blue);
        }
    }
}
