using Lidgren.Network;
using LoginServer.Common;

namespace LoginServer.Network {
    public class NetworkClient {
        /// <summary>
        /// IP público de conexão.
        /// </summary>
        private string ip = string.Empty;

        /// <summary>
        /// Ip local de conexão.
        /// </summary>
        private string localIP = string.Empty;

        /// <summary>
        /// Porta de conexão.
        /// </summary>
        private int port;

        /// <summary>
        /// Socket client.
        /// </summary>
        private NetClient socket { get; set; }

        /// <summary>
        /// Dados de entrada.
        /// </summary>
        private NetIncomingMessage incMsg;

        /// <summary>
        /// Inicia o servidor.
        /// </summary>
        /// <param name="localAddress"></param>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void InitializeClient(string localAddress, string address, int port) {
            localIP = localAddress;
            ip = address;
            this.port = port;

            NetPeerConfiguration config = new NetPeerConfiguration(Settings.Discovery);
            config.ConnectionTimeout = 25;
            config.UseMessageRecycling = true;
            config.AutoFlushSendQueue = true;
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse | NetIncomingMessageType.StatusChanged | NetIncomingMessageType.Data);
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval |
                NetIncomingMessageType.ConnectionLatencyUpdated |
                NetIncomingMessageType.DebugMessage |
                NetIncomingMessageType.Error |
                NetIncomingMessageType.NatIntroductionSuccess |
                NetIncomingMessageType.Receipt |
                NetIncomingMessageType.UnconnectedData |
                NetIncomingMessageType.VerboseDebugMessage |
                NetIncomingMessageType.WarningMessage);

            socket = new NetClient(config);
            socket.Start();
            socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Cria a mensagem de envio.
        /// </summary>
        /// <returns></returns>
        public NetOutgoingMessage CreateMessage() {
            return socket.CreateMessage();
        }

        /// <summary>
        /// Cria a mensagem de envio com a capacidade inicial.
        /// </summary>
        /// <param name="initialCapacity"></param>
        /// <returns></returns>
        public NetOutgoingMessage CreateMessage(int initialCapacity) {
            return socket.CreateMessage(initialCapacity);
        }

        /// <summary>
        /// Ativa a descoberta de servidor.
        /// </summary>
        /// <returns></returns>
        public bool DiscoverServer() {
            if (Equals(null, socket))
                return false;

            if (Connected())
                return true;

            if (string.IsNullOrEmpty(localIP)) {
                if (socket.DiscoverKnownPeer(ip, port))
                    return true; 
            }
            else {
                if (socket.DiscoverKnownPeer(localIP, port))
                    return true; 
            }
                   
            return false;
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public void Disconnect() {
            socket.Disconnect("");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Shutdown() {
            if (socket.Status == NetPeerStatus.Running) { socket.Disconnect(""); }
            socket = null;
        }

        /// <summary>
        /// Verifica se o jogador está connectado
        /// </summary>
        /// <returns>bool</returns>
        public bool Connected() {
            if (Equals(null, socket))
                return false; 

            return socket.ConnectionStatus == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Envia dados para cliente (World).
        /// </summary>
        /// <param name="Data"></param>
        public void SendData(NetOutgoingMessage Data) {
            if (Equals(null, socket))
                return; 

            socket.SendMessage(Data, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Recebe dados de cliente.
        /// </summary>
        /// <param name="index"></param>
        public void ReceiveData(int index) {
            if (Equals(null, socket))
                return; 

            //recebe as mensagens
            while ((incMsg = socket.ReadMessage()) != null) {
                switch (incMsg.MessageType) {
                    case NetIncomingMessageType.DiscoveryResponse:
                        socket.Connect(incMsg.SenderEndPoint);   
                        FileLog.WriteLog($"Connected World Server #{Settings.Server[index].Name}", System.Drawing.Color.Green);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)incMsg.ReadByte();
                        if (status == NetConnectionStatus.Disconnected) {
                            FileLog.WriteLog($"World Server #{Settings.Server[index].Name} disconnected", System.Drawing.Color.Green);
                        }
                        break;

                    case NetIncomingMessageType.Data:
                        WorldData.HandleData(index, incMsg);
                        break;
                }

                socket.Recycle(incMsg);
            }
        }
    }

}

