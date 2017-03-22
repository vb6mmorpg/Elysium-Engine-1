using System.Drawing;
using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.MySQL;

namespace LoginServer.Network {
    public static class LoginNetwork {
        /// <summary>
        /// Socket de conexão.
        /// </summary>
        private static NetServer socket;

        /// <summary>
        /// Recebe as mensagens.
        /// </summary>
        private static NetIncomingMessage msg;

        /// <summary>
        /// 
        /// </summary>
        private static PlayerData pData;

        /// <summary>
        /// Inicia e prepara a conexão.
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
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval |
                NetIncomingMessageType.ConnectionLatencyUpdated |
                NetIncomingMessageType.DebugMessage |
                NetIncomingMessageType.DiscoveryResponse |
                NetIncomingMessageType.Error |
                NetIncomingMessageType.NatIntroductionSuccess |
                NetIncomingMessageType.Receipt |
                NetIncomingMessageType.UnconnectedData |
                NetIncomingMessageType.VerboseDebugMessage |
                NetIncomingMessageType.WarningMessage) ;
    
            socket = new NetServer(config);
            socket.Start();
            socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Cria a mensagem de envio.
        /// </summary>
        /// <returns></returns>
        public static NetOutgoingMessage CreateMessage() {
            return socket.CreateMessage();
        }

        /// <summary>
        /// Cria a mensagem de envio com a capacidade inicial.
        /// </summary>
        /// <param name="initialCapacity"></param>
        /// <returns></returns>
        public static NetOutgoingMessage CreateMessage(int initialCapacity) {
            return socket.CreateMessage(initialCapacity);
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public static void Shutdown() {
            socket.Shutdown("");
            socket = null;
        }

        /// <summary>
        /// Recebe os dados dos clientes.
        /// </summary>
        public static void ReceivedData() {
            while ((msg = socket.ReadMessage()) != null) {

                pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:

                        #region Find Banned Country
                        var ip = msg.SenderEndPoint.Address.ToString();

                        if (GeoIp.Enabled) {

                            //Verifica se o ip já está bloqueado temporariamente (evitar processamento desnecessario)
                            if (!GeoIp.IsIpBlocked(ip)) {

                                //verifica se o ip do país está na lista de bloqueados.
                                if (GeoIp.IsCountryIpBlocked(ip)) {
                                    var country = GeoIp.FindCountryByIp(ip);

                                    //adiciona na lista de bloqueado temporareamente
                                    GeoIp.AddIpAddress(ip);
                                    FileLog.WriteLog($"Banned country trying to connect: {ip} {country.Country}-{country.Code}", Color.Coral);
                                    return;
                               }    
                            }
                            else {
                                return;
                            }
                        }

                        #endregion

                        #region Find Banned IP
                        if (Accounts_DB.IsBannedIp(msg.SenderEndPoint.Address.ToString()) == true) {
                            FileLog.WriteLog("Warning: Attempted IP Banned " + msg.SenderEndPoint.Address, Color.Coral);
                            return;
                        }
                        #endregion

                        LoginNetwork.socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        FileLog.WriteLog($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral); 
                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        FileLog.WriteLog($"Error: {msg.ReadString()}", Color.Coral);
                        break;
  
                    case NetIncomingMessageType.StatusChanged:
                        #region Status Changed Connected
                        NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();
                        if (status == NetConnectionStatus.Connected) {     
                            FileLog.WriteLog($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
                            Authentication.Player.Add(new PlayerData(msg.SenderConnection, NetUtility.ToHexString(msg.SenderConnection.RemoteUniqueIdentifier), msg.SenderEndPoint.Address.ToString()));
                        }
                        #endregion

                        #region Status Changed Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            if (pData == null) { return; }
      
                            FileLog.WriteLog($"Status changed to disconnected: {pData?.ID} {pData?.Account} {msg?.SenderEndPoint.Address} {pData?.HexID}", Color.Coral); 
    
                            Accounts_DB.UpdateLastIP(pData.Account, pData.IP);
                            Accounts_DB.UpdateLoggedIn(pData.Account, 0); //0 disconnect
                            Accounts_DB.UpdateCurrentIP(pData.Account, string.Empty); //limpa o ip atual

                            Authentication.Player.Remove(pData);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        LoginData.HandleData(pData.HexID, msg);
                        break;

                    default:
                        //Registra qualquer mensagem invalida
                        FileLog.WriteLog($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                LoginNetwork.socket.Recycle(msg);
            }
        }
        
        /// <summary>
        /// Verifica o estado da conexão pela conexão de usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static bool Connected(ref PlayerData pData) {
            return (pData.Connection.Status == NetConnectionStatus.Connected) ? true : false;
        }

        /// <summary>
        /// Verifica se o estado da conexão pelo HexaID.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool Connected(string hexID) {
            return (Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected) ? true : false;
        }

        /// <summary>
        /// Envia dados para determinada conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para determinada conexão usando determinado canal.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="seqChannel"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod, int seqChannel) {
            socket.SendMessage(msg, Authentication.FindByHexID(hexID).Connection, deliveryMethod, seqChannel);
        }

        /// <summary>
        /// Envia dados para todos.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) { SendDataTo(pData.HexID, msg, deliveryMethod); }
        }

        /// <summary>
        /// Envia dados para todos em determinado canal.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="seqChannel"></param>
        public static void SendDataToAll(NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod, int seqChannel) {
            foreach (PlayerData pData in Authentication.Player) { SendDataTo(pData.HexID, msg, deliveryMethod, seqChannel); }
        }

        /// <summary>
        /// Envia dados para todos, exceto. 
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAllBut(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            foreach (PlayerData pData in Authentication.Player) {
                if (pData.HexID.CompareTo(hexID) != 0) { SendDataTo(pData.HexID, msg, deliveryMethod); }
            }
        }
    }
}