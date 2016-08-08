using System.Drawing;
using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.MySQL;

namespace LoginServer.Network {
    public static class LoginServerNetwork {
        /// <summary>
        /// Socket de conexão.
        /// </summary>
        public static NetServer Socket { get; set; }

        /// <summary>
        /// Inicia e prepara a conexão.
        /// </summary>
        public static void InitializeServer() {
            var config = new NetPeerConfiguration(Settings.Discovery);
            config.Port = Settings.Port;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Settings.MaxConnection;
            config.ConnectionTimeout = 25.0f;
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
            Socket = null;
        }

        /// <summary>
        /// Recebe os dados dos clientes.
        /// </summary>
        public static void ReceivedData() {
            NetIncomingMessage msg;

            while ((msg = Socket.ReadMessage()) != null) {
                var pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                        #region Find Banned IP
                        if (Accounts_DB.BannedIP(msg.SenderEndPoint.Address.ToString()) == true) {
                            LogConfig.WriteLog("Warning: Attempted IP Banned " + msg.SenderEndPoint.Address);
                            LogConfig.WriteLog("Warning: Attempted IP Banned " + msg.SenderEndPoint.Address, Color.Coral);
                            return;
                        }
                        #endregion

                        LoginServerNetwork.Socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        LogConfig.WriteLog($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral); 
                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        LogConfig.WriteLog($"Error: {msg.ReadString()}", Color.Coral);
                        break;
  
                    case NetIncomingMessageType.StatusChanged:
                        #region Status Changed Connected
                        NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();

                        if (status == NetConnectionStatus.Connected) {
                            LogConfig.WriteLog($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
                            Authentication.Player.Add(new PlayerData(msg.SenderConnection, NetUtility.ToHexString(msg.SenderConnection.RemoteUniqueIdentifier), msg.SenderEndPoint.Address.ToString()));
                        }
                        #endregion

                        #region Status Changed Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            pData = Authentication.FindByHexID(NetUtility.ToHexString(msg.SenderConnection.RemoteUniqueIdentifier));

                            //1 - enabled, 0 - disabled
                            if (Settings.LogSystem == 1) { LogConfig.WriteLog($"Status changed to disconnected: {pData?.ID} {pData?.Account} {msg.SenderEndPoint.Address}"); }
                            if (!Settings.LogSystemScreen) { LogConfig.WriteLog($"Status changed to disconnected: {pData?.ID} {pData?.Account} {msg.SenderEndPoint.Address}", Color.Coral); }

                            Accounts_DB.UpdateLastIP(pData.Account, pData.IP);
                            Accounts_DB.UpdateLoggedIn(pData.Account, 0);

                            Authentication.Player.Remove(pData);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        LoginServerData.HandleData(pData.HexID, msg);
                        break;

                    default:
                        //Registra qualquer mensagem invalida
                        LogConfig.WriteLog($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                LoginServerNetwork.Socket.Recycle(msg);
            }
        }
        
        /// <summary>
        /// Verifica o estado da conexão pela conexão de usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static bool Connected(ref PlayerData pData) {
            return pData.Connection.Status == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Verifica se o estado da conexão pelo HexaID.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool Connected(string hexID) {
            return Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Envia dados para determinada conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            var pData = Authentication.FindByHexID(hexID);

            var outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, pData.Connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para determinada conexão usando determinado canal.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="seqChannel"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod, int seqChannel) {
            var pData = Authentication.FindByHexID(hexID);

            var outgoingPacket = Socket.CreateMessage(data.LengthBytes);
            outgoingPacket.Write(data);
            Socket.SendMessage(outgoingPacket, pData.Connection, deliveryMethod, seqChannel);
        }

        /// <summary>
        /// Envia dados para todos.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) { SendDataTo(pData.HexID, data, deliveryMethod); }
        }

        /// <summary>
        /// Envia dados para todos em determinado canal.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="seqChannel"></param>
        public static void SendDataToAll(NetOutgoingMessage data, NetDeliveryMethod deliveryMethod, int seqChannel) {
            foreach (PlayerData pData in Authentication.Player) { SendDataTo(pData.HexID, data, deliveryMethod, seqChannel); }
        }

        /// <summary>
        /// Envia dados para todos, exceto. 
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAllBut(string hexID, NetOutgoingMessage data, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                if (pData.HexID.CompareTo(hexID) != 0) { SendDataTo(pData.HexID, data, deliveryMethod); }
            }
        }
    }
}