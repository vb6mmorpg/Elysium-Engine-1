using System.Drawing;
using Lidgren.Network;
using WorldServer.Common;
using WorldServer.Server;

namespace WorldServer.Network {
    public static class WorldNetwork {
        /// <summary>
        /// Socket de conexão.
        /// </summary>
        public static NetServer Socket { get; set; }

        /// <summary>
        /// Inicia as configurações.
        /// </summary>
        public static void InitializeServer() {
            var config = new NetPeerConfiguration(Settings.Discovery);
            config.Port = Settings.Port;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Settings.MaxConnection;
            config.ConnectionTimeout = (float)Settings.ConnectionTimeOut;
            config.PingInterval = 2.0f;
            config.UseMessageRecycling = true;
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval | NetIncomingMessageType.UnconnectedData | NetIncomingMessageType.VerboseDebugMessage | NetIncomingMessageType.ConnectionLatencyUpdated);

            Socket = new NetServer(config);
            Socket.Start();
            Socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public static void Shutdown() {
            Socket.Shutdown("");
            Socket = null;
        }

        /// <summary>
        /// Recebe os dados.
        /// </summary>
        public static void ReceivedData() {
            NetIncomingMessage msg;

            while ((msg = Socket.ReadMessage()) != null) {
                var pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                         Socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                         FileLog.WriteLog($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral);

                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        #region ErrorMessage
                        var error = msg.ReadString();

                        FileLog.WriteLog($"Error: {error}", Color.Coral);

                        #endregion

                        break;
                    case NetIncomingMessageType.StatusChanged:

                        #region StatusChanged : Connected
                        NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();
                        if (status == NetConnectionStatus.Connected) {
                            FileLog.WriteLog($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
                            Authentication.Player.Add(new PlayerData(msg.SenderConnection, string.Empty, msg.SenderEndPoint.Address.ToString()));
                            WorldPacket.NeedHexID(msg.SenderConnection);
                        }
                        #endregion

                        #region StatusChanged : Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            pData = Authentication.FindByConnection(msg.SenderConnection);

                            FileLog.WriteLog($"Status changed to disconnected: {pData.AccountID} {pData?.Account} {msg.SenderEndPoint.Address} {pData.HexID}", Color.Coral);
               
                            pData.Clear();
                            Authentication.Player.Remove(pData);
                        }
                        #endregion

                        break;

                    case NetIncomingMessageType.Data:
                        WorldData.HandleData(pData.Connection, msg); 
                        break;
            
                    default:
                        if (Settings.LogSystem) { FileLog.WriteLog($"Unhandled type: {msg.MessageType}"); }

                        Program.WorldForm.WriteLog($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                Socket.Recycle(msg);
            }
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool IsConnected(string hexID) {
            if (Equals(null, Authentication.FindByHexID(hexID).Connection)) { return false; }
            return Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static bool IsConnected(NetConnection connection) {
            if (Equals(null, connection)) { return false; }
            return connection.Status == NetConnectionStatus.Connected ? true : false; 
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            var outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(NetConnection connection, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            var outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para todos os clientes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach(PlayerData pData in Authentication.Player) {
                if (IsConnected(pData.Connection)) SendDataTo(pData.Connection, data, deliveryMethod); //if (IsConnected(index)) 
            }
        }

        /// <summary>
        /// Envia dados para todos os clientes, exceto.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAllBut(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                if (pData.HexID.CompareTo(hexID) != 0) { SendDataTo(pData.Connection, data, deliveryMethod); }
            }
        }

        /// <summary>
        /// Envia dados para todos os clientes, exceto.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAllBut(NetConnection connection, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach(PlayerData pData in Authentication.Player) {
                if (!pData.Connection.Equals(connection)) { SendDataTo(pData.Connection, data, deliveryMethod); }
            }
        }
    }
}