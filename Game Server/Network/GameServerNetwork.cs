using Lidgren.Network;
using GameServer.Common;
using GameServer.Server;

namespace GameServer.Network {
    public static class GameServerNetwork {
        // TCP Client //
        public static bool ClientStatus;
        public static NetServer Socket;
        private static NetOutgoingMessage outgoingPacket;

        public static void initServerTCP() {
            // Parse IP //
            var ip = System.Net.IPAddress.Parse(Settings.IP);

            // SERVER TCP CONFIG //
            var config = new NetPeerConfiguration(Settings.Discovery);
            config.Port = Settings.Port;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Settings.MaxConnection;
            config.ConnectionTimeout = 25.0f;
            config.PingInterval = 2.0f;
            config.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
            config.UseMessageRecycling = true;
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval | NetIncomingMessageType.UnconnectedData | NetIncomingMessageType.VerboseDebugMessage | NetIncomingMessageType.ConnectionLatencyUpdated);

            //SimulatedMinimumLatency, SimulatedRandomLatency

            Socket = new NetServer(config);
            Socket.Start();
            Socket.Socket.Blocking = false;
        }

        public static void ReceiveData() {
            if (Socket == null) { return; }
            NetIncomingMessage msg;

            while ((msg = Socket.ReadMessage()) != null) {
                var pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                        string ip = msg.SenderEndPoint.Address.ToString();

                        Socket.SendDiscoveryResponse(null, msg.SenderEndPoint);

                        //   if (Program.ConnectForm.Logs.Checked == false)
                        //   {
                        //       Program.ConnectForm.WriteLog("Discovery Response IPEndPoint: " + msg.SenderEndPoint.Address, Color.Coral); 
                        //   }
                        //   if (Settings.LogSystem == true) { LogConfig.WriteLog("Discovery Response IPEndPoint: " + msg.SenderEndPoint.Address); }

                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        #region ErrorMessage
                        var error = msg.ReadString();

                        //if (Program.ConnectForm.Logs.Checked == false)
                        //{
                        //     Program.ConnectForm.WriteLog("Error: " + error, Color.Coral); 
                        //  }

                        // if (Settings.LogSystem == true) { LogConfig.WriteLog("Error: " + error); } 
                        #endregion
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        #region StatusChanged : Connected
                        var status = (NetConnectionStatus)msg.ReadByte();

                        if (status == NetConnectionStatus.Connected) {
                            LogConfig.WriteLog($"Status changed to connected: {msg.SenderEndPoint.Address}", System.Drawing.Color.Coral);
                            Authentication.Player.Add(new PlayerData(msg.SenderConnection, string.Empty, msg.SenderEndPoint.Address.ToString()));
                            GameServerPacket.NeedHexID(msg.SenderConnection);
                        }
                        #endregion

                        #region StatusChanged : Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            LogConfig.WriteLog($"ID: {pData.CharacterID} {pData.CharacterName} Status changed to disconnected: " + msg.SenderEndPoint.Address, System.Drawing.Color.Coral);
                            MySQL.Character_DB.Save(pData);
                            pData.Clear();
                            Authentication.Player.Remove(pData);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        GameServerData.HandleData(pData.Connection, msg);
                        break;


                    default:
                        //  if (Settings.LogSystem == true) { LogConfig.WriteLog("Unhandled type: " + msg.MessageType); }

                        //  Program.ConnectForm.WriteLog("Unhandled type: " + msg.MessageType, Color.DarkRed);
                        break;
                }

                Socket.Recycle(msg);
            }
        }

        public static bool IsConnected(string hexID) {
            if (Authentication.FindByHexID(hexID).Connection == null) { return false; }
            if (Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected) { return true; }

            return false;
        }

        public static bool IsConnected(NetConnection connection) {
            if (connection == null) { return false; }
            if (connection.Status == NetConnectionStatus.Connected) { return true; }

            return false;
        }

        public static void SendDataTo(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            if (Authentication.Player.Count == 0) { return; }

            outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }

        public static void SendDataTo(NetConnection connection, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            if (Authentication.Player.Count == 0) { return; }

            outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, connection, deliveryMethod);
        }

        public static void SendDataTo(NetConnection connection, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod, int channel) {
            if (Authentication.Player.Count == 0) { return; }

            outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, connection, deliveryMethod, channel);
        }

        public static void SendDataToAll(NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                SendDataTo(pData.Connection, data, deliveryMethod); //if (IsConnected(index)) 
            }
        }

        public static void SendDataToAllBut(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                if (pData.HexID.CompareTo(hexID) != 0) { SendDataTo(pData.Connection, data, deliveryMethod); }
            }
        }

        public static void SendDataToAllBut(NetConnection connection, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                if (!pData.Connection.Equals(connection)) { SendDataTo(pData.Connection, data, deliveryMethod); }
            }
        }
    }
}