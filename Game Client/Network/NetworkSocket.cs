using System;
using Lidgren.Network;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network {
    public static class NetworkSocket {
        static int[] tick = new int[Configuration.MAX_GAME_SERVER];
        static NetClient[] client = new NetClient[Configuration.MAX_GAME_SERVER];
        static NetIncomingMessage[] incMsg = new NetIncomingMessage[Configuration.MAX_GAME_SERVER];

        /// <summary>
        /// Delegate 
        /// </summary>
        /// <param name="data"></param>
        public delegate void TargetData(NetIncomingMessage data);
        public static TargetData ProcessData { get; set; }

        public static void Initialize() {
            //Delegate
            ProcessData += NetworkPacket.ProcessPacket;

            NetPeerConfiguration config = new NetPeerConfiguration("Elysium Diamond #1.0.0");
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.ConnectionTimeout = 25.0f;
            config.PingInterval = 4.0f;
            config.UseMessageRecycling = false;
            config.AutoFlushSendQueue = true;

            for (var index = 0; index < Configuration.MAX_GAME_SERVER; index++) {
                client[index] = new NetClient(config);
                client[index].Start();
                client[index].Socket.Blocking = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static NetOutgoingMessage CreateMessage() {
            return client[0].CreateMessage();
        }

        public static NetOutgoingMessage CreateMessage(int initialCapacity) {
            return client[0].CreateMessage(initialCapacity);
        }

        /// <summary>
        /// Descoberta de servidor.
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool DiscoverServer(NetworkSocketEnum socket) {
            //verificar ip
            if (string.IsNullOrEmpty(Configuration.IPAddress[(int)socket].IP)) { return false; }

            if (Connected(socket))
                return true;

            if (client[(int)socket].DiscoverKnownPeer(Configuration.IPAddress[(int)socket].IP, Configuration.IPAddress[(int)socket].Port))
                return true;

            return false;
        }

        /// <summary>
        /// Verifica se está conectado com o servidor.
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool Connected(NetworkSocketEnum socket) {
            if (client[(int)socket] == null) { return false; }
            if (client[(int)socket].ConnectionStatus == NetConnectionStatus.Connected) return true; else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        public static void Disconnect(NetworkSocketEnum socket) {
            if (client[(int)socket] != null) { client[(int)socket].Disconnect(""); }
        }

        /// <summary>
        /// Envia dados para o servidor.
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        public static void SendData(NetworkSocketEnum socket, NetOutgoingMessage data) {
            client[(int)socket].SendMessage(data, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia dados para o servidor.
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        /// <param name="delivery"></param>
        public static void SendData(NetworkSocketEnum socket, NetOutgoingMessage data, NetDeliveryMethod delivery) {
            client[(int)socket].SendMessage(data, delivery);
        }

        /// <summary>
        /// Lê e processa os dados recebidos.
        /// </summary>
        public static void ReceiveData() {
            for (var index = 0; index < Configuration.MAX_GAME_SERVER; index++) {
                if (client[index] == null) { continue; }

                // Read incoming message
                while ((incMsg[index] = client[index].ReadMessage()) != null) {

                    switch (incMsg[index].MessageType) {
                        case NetIncomingMessageType.DiscoveryResponse:
                            client[index].Connect(incMsg[index].SenderEndPoint);
                            break;
                        case NetIncomingMessageType.Data:
                            ProcessData?.Invoke(incMsg[index]);
                            break;
                    }

                    client[index].Recycle(incMsg);
                }
            }
        }
    }
}


