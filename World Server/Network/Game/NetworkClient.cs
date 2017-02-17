using Lidgren.Network;
using WorldServer.Common;

namespace WorldServer.Network {
    public class NetworkClient {
        private string IP = string.Empty;
        private string LocalIP = string.Empty;
        private int Port;

        public NetClient Socket;
        private NetIncomingMessage incMsg;

        /// <summary>
        /// Inicializa o cliente.
        /// </summary>
        /// <param name="localAddress"></param>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void InitializeClient(string localAddress, string address, int port) {
            if (Socket == null) {
                LocalIP = localAddress;
                IP = address;
                Port = port;

                // Networking //
                var config = new NetPeerConfiguration(Settings.Discovery);
                config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
                config.ConnectionTimeout = 25;

                Socket = new NetClient(config);
                Socket.Start();
                Socket.Socket.Blocking = false;
            }
        }
        
        public void Shutdown() {
            Socket.Shutdown("");
            Socket = null;
        }

        /// <summary>
        /// Descoberta de servidor.
        /// </summary>
        /// <returns></returns>
        public bool DiscoverServer() {
            if (Equals(null, Socket)) { return false; }

            if (Connected()) { return true; }

            if (string.IsNullOrEmpty(LocalIP)) {
                if (Socket.DiscoverKnownPeer(IP, Port)) { return true; }
            }
            else {
                if (Socket.DiscoverKnownPeer(LocalIP, Port)) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <returns></returns>
        public bool Connected() {
            if (Socket == null) { return false; }
            return Socket.ConnectionStatus == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Envia os dados.
        /// </summary>
        /// <param name="Data"></param>
        public void SendData(NetOutgoingMessage Data) {
            if (Socket == null) { return; }
            Socket.SendMessage(Data, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Lê e processa as informações recebidas.
        /// </summary>
        /// <param name="index"></param>
        public void ReceiveData(int index) {
            if (Socket == null) { return; }

            //lê os dados recebidos
            while ((incMsg = Socket.ReadMessage()) != null) {
                switch (incMsg.MessageType) {
                    case NetIncomingMessageType.DiscoveryResponse:
                        Socket.Connect(incMsg.SenderEndPoint);
                        Program.WorldForm.WriteLog($"Conectado ao Game Server #{Settings.GameServer[index].Name}", System.Drawing.Color.Green);
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)incMsg.ReadByte();
                        if (status == NetConnectionStatus.Disconnected) {
                            Program.WorldForm.WriteLog($"Game Server #{Settings.GameServer[index].Name} desconectado", System.Drawing.Color.Green);
                        }
                        break;
                    case NetIncomingMessageType.Data:
                        GameData.HandleData(index, incMsg);
                        break;
                }

                Socket.Recycle(incMsg);
            }
        }
    }

}

