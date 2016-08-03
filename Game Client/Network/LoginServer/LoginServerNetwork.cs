using System;
using Lidgren.Network;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network {
    public class LoginServerNetwork {
        private int tick;
        // TCP Client //
        public NetClient TCPClient;
        private NetIncomingMessage incMsg;

        // Private Constructor
        private LoginServerNetwork() { }

        // Singleton Accessor
        static LoginServerNetwork instance;

        public static LoginServerNetwork Instance {
            get {
                if (instance == null)
                    instance = new LoginServerNetwork();
                return instance;
            }
        }

        // Init Network Controller
        public void initTCP() {
            if (TCPClient == null) {
                // Networking //
                var config = new NetPeerConfiguration("Elysium Diamond #1.0.0");
                config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
                config.ConnectionTimeout = 25.0f;
                config.PingInterval = 4.0f;
                config.UseMessageRecycling = false;
                config.AutoFlushSendQueue = true;

                TCPClient = new NetClient(config);
                TCPClient.Start();
                TCPClient.Socket.Blocking = false;
            }

            if (Connected() == false) {
                // Check if server is online //
                if (Environment.TickCount >= tick + 1000) {
                    TCPClient.DiscoverKnownPeer(Settings.LoginServerIP, Settings.LoginServerPort);
                    tick = Environment.TickCount;
                }
            }
        }

        // Discover Server
        public bool DiscoverServer() {
            if (Connected())
                return true;

            if (LoginServerNetwork.Instance.TCPClient.DiscoverKnownPeer(Settings.LoginServerIP, Settings.LoginServerPort))
                return true;

            return false;
        }

        // Check if player is connected
        public bool Connected() {
            if (TCPClient == null) { return false; }
            if (TCPClient.ConnectionStatus == NetConnectionStatus.Connected) return true; else return false;
        }

        // Send Message
        public void SendData(NetOutgoingMessage data) {
            TCPClient.SendMessage(data, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendData(NetOutgoingMessage data, NetDeliveryMethod delivery) {
            TCPClient.SendMessage(data, delivery);
        }

        // Check Incoming Message
        public void ReceiveData() {
            if (TCPClient == null) { return; }

            // READ INCOMING MESSAGE //
            while ((incMsg = TCPClient.ReadMessage()) != null) {
                switch (incMsg.MessageType) {
                    case NetIncomingMessageType.DiscoveryResponse:
                        TCPClient.Connect(incMsg.SenderEndPoint);
                        break;
                    case NetIncomingMessageType.Data:
                        LoginServerData.HandleData(incMsg);
                        break;
                }

                TCPClient.Recycle(incMsg);
            }
        }

    }
}