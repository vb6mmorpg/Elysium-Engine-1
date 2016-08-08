using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameLogic;
using Elysium_Diamond.GameWindow;

namespace Elysium_Diamond.Network
{
    public class GameServerHandle
    {
        public static void HandleData(NetIncomingMessage data)
        {
            // Packet Header //
            var MsgType = data.ReadInt32();

            // Check Packet Header Number //
            if (MsgType < 0) { return; }

            // Handle Incoming Message //
            switch (MsgType)
            {
                case (int)PacketList.None: break;
                case (int)PacketList.Ping: Ping(); break;
                case (int)PacketList.Disconnect: CommonMessage.ShowMessage(PacketList.Disconnect); break;
                case (int)PacketList.AcceptedConnection: CommonMessage.ShowMessage(PacketList.AcceptedConnection); break;
                case (int)PacketList.ChangeGameState: CommonMessage.ChangeGameState(data.ReadByte()); break;
                case (int)PacketList.CantConnectNow: CommonMessage.ShowMessage(PacketList.CantConnectNow); break;
                case (int)PacketList.InvalidVersion: CommonMessage.ShowMessage(PacketList.InvalidVersion); break;

                case (int)PacketList.GameServer_Client_NeedHexID: GeneralServerPacket.GameServerHexID(); break;
                case (int)PacketList.GameServer_Client_PlayerData: GeneralServerData.PlayerData(data); break;
                // case (int)PacketList.GameServer_SendNpc: GeneralServerData.ReceiveNpc(data); break;
                case (int)PacketList.GameServer_Client_GetMapPlayer: GetPlayerOnMap(data); break;
                case (int)PacketList.GameServer_Client_PlayerMapMove: PlayerMapMove(data); break;


            }
        }

        public static void GetPlayerOnMap(NetIncomingMessage data) {
            var pData = new EngineCharacter();
            pData.ID  = data.ReadInt32();
            pData.Name = data.ReadString();
            pData.Sprite = data.ReadInt32();
            pData.Dir = (EngineCharacter.Direction)data.ReadInt32();
            pData.PositionX = data.ReadInt32() * 16;
            pData.PositionY = data.ReadInt32() * 16;
            pData.Enabled = false;

            PlayerList.Player.Add(pData);
        }

        public static void PlayerMapMove(NetIncomingMessage data) {
            var pData = PlayerList.FindByID(data.ReadInt32());
            
            pData.Dir = (EngineCharacter.Direction)data.ReadInt32();

            if (pData.Dir == EngineCharacter.Direction.Up) {
                pData.OffSetY =+ 16;
            }

            if (pData.Dir == EngineCharacter.Direction.Down) {
                pData.OffSetY =+ -16;
            }

            if (pData.Dir == EngineCharacter.Direction.Left) {
                pData.OffSetX =+ 16;
            }

            if (pData.Dir == EngineCharacter.Direction.Right) {
                pData.OffSetX =+ -16;
            }

            pData.Move = true;
        }

      


        public static void Ping() {
            Settings.pingEnd = Environment.TickCount;
            Settings.ping = Settings.pingEnd - Settings.pingStart;
            Settings.pingSend = true;
        }
    }
}
