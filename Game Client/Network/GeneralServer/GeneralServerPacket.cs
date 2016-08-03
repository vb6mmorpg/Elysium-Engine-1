using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network
{
    public class GeneralServerPacket
    {
        public static void SendRequestPing() {
            var buffer = GameServerNetwork.Instance.TCPClient.CreateMessage(4);
            buffer.Write((int)PacketList.Ping);
            GameServerNetwork.Instance.SendData(buffer, NetDeliveryMethod.Unreliable);
            Settings.pingStart = Environment.TickCount;
        }

        public static void GameServerHexID() {
            var buffer = GameServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_SendPlayerHexID);
            buffer.Write(Settings.HexID);

            GameServerNetwork.Instance.SendData(buffer);
        }

        public static void PlayerMove(EngineCharacter.Direction dir) {
            var buffer = GameServerNetwork.Instance.TCPClient.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_PlayerMove);
            buffer.Write((int)dir);

            GameServerNetwork.Instance.SendData(buffer);
        }



    }
}
