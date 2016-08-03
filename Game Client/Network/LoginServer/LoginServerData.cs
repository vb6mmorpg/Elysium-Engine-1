using System;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.GameWindow;

namespace Elysium_Diamond.Network {
    public class LoginServerData {
        public static void HandleData(NetIncomingMessage data) {
            // Packet Header
            var msgType = data.ReadInt32();

            // Check Packet Header Number
            if (msgType < 0) { return; }

            // Handle Incoming Message /
            switch (msgType) {
                case (int)PacketList.None: break;
                case (int)PacketList.Disconnect: CommonMessage.ShowMessage(PacketList.Disconnect); break;
                case (int)PacketList.AcceptedConnection: CommonMessage.ShowMessage(PacketList.AcceptedConnection); break;
                case (int)PacketList.ChangeGameState: CommonMessage.ChangeGameState(data.ReadByte()); break;
                case (int)PacketList.CantConnectNow: CommonMessage.ShowMessage(PacketList.CantConnectNow); break;
                case (int)PacketList.InvalidVersion: CommonMessage.ShowMessage(PacketList.InvalidVersion); break;
                case (int)PacketList.LoginServer_Client_SendPlayerHexID: HexID(data.ReadString()); break;
                case (int)PacketList.LoginServer_Client_ServerList: ServerList(data); break;
                case (int)PacketList.LoginServer_Client_AlreadyLoggedIn: CommonMessage.ShowMessage(PacketList.LoginServer_Client_AlreadyLoggedIn); break;
                case (int)PacketList.LoginServer_Client_AccountBanned: CommonMessage.ShowMessage(PacketList.LoginServer_Client_AccountBanned); break;
                case (int)PacketList.LoginServer_Client_Maintenance: CommonMessage.ShowMessage(PacketList.LoginServer_Client_Maintenance); break;
                case (int)PacketList.LoginServer_Client_InvalidNamePass: CommonMessage.ShowMessage(PacketList.LoginServer_Client_InvalidNamePass); break;
                case (int)PacketList.LoginServer_Client_AccountDisabled: CommonMessage.ShowMessage(PacketList.LoginServer_Client_AccountDisabled); break;
            }
        }

        public static void HexID(string hexid) {
            Settings.HexID = hexid;
        }

        public static void ServerList(NetIncomingMessage data) {
            const int MAX_SERVER = 5;
            for (int n = 0; n < MAX_SERVER; n++) {
                WindowServer.Server[n].Name = data.ReadString();
                WindowServer.Server[n].IP = data.ReadString();
                WindowServer.Server[n].Port = data.ReadInt32();
                WindowServer.Server[n].Region = data.ReadString();
                WindowServer.Server[n].Status = data.ReadString();
            }
        }


    }
}
