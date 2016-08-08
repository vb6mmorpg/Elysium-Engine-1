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
        public NetClient Socket { get; set; } = null;

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
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.ConnectionTimeout = 25;
            config.UseMessageRecycling = true;

            Socket = new NetClient(config);
            Socket.Start();
            Socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Ativa a descoberta de servidor.
        /// </summary>
        /// <returns></returns>
        public bool DiscoverServer() {
            if (Equals(null, Socket))
                return false;

            if (Connected())
                return true;

            if (string.IsNullOrEmpty(localIP)) {
                if (Socket.DiscoverKnownPeer(ip, port))
                    return true; 
            }
            else {
                if (Socket.DiscoverKnownPeer(localIP, port))
                    return true; 
            }
                   
            return false;
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public void Disconnect() {
            Socket.Disconnect("");
        }

        /// <summary>
        /// Verifica se o jogador está connectado
        /// </summary>
        /// <returns>bool</returns>
        public bool Connected() {
            if (Equals(null, Socket))
                return false; 

            return Socket.ConnectionStatus == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Envia dados para cliente (World).
        /// </summary>
        /// <param name="Data"></param>
        public void SendData(NetOutgoingMessage Data) {
            if (Equals(null, Socket))
                return; 

            Socket.SendMessage(Data, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Recebe dados de cliente.
        /// </summary>
        /// <param name="index"></param>
        public void ReceiveData(int index) {
            if (Equals(null, Socket))
                return; 

            //recebe as mensagens
            while ((incMsg = Socket.ReadMessage()) != null) {
                switch (incMsg.MessageType) {
                    case NetIncomingMessageType.DiscoveryResponse:
                        Socket.Connect(incMsg.SenderEndPoint);
                        LogConfig.WriteLog($"Connected World Server #{Settings.Server[index].Name}");            
                        LogConfig.WriteLog($"Connected World Server #{Settings.Server[index].Name}", System.Drawing.Color.Green);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)incMsg.ReadByte();
                        if (status == NetConnectionStatus.Disconnected) {
                            LogConfig.WriteLog($"World Server #{Settings.Server[index].Name} disconnected"); 
                            LogConfig.WriteLog($"World Server #{Settings.Server[index].Name} disconnected", System.Drawing.Color.Green);
                        }
                        break;

                    case NetIncomingMessageType.Data:
                        WorldServerData.HandleData(index, incMsg);
                        break;
                }

                Socket.Recycle(incMsg);
            }
        }
    }

}

