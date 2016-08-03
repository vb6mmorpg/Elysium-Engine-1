using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network
{
    public class GameServerNetwork
    {
        private int tick;
        // TCP Client //
        public NetClient TCPClient;
        private NetIncomingMessage incMsg;

        // Private Constructor
        private GameServerNetwork() { }

        // Singleton Accessor
        static GameServerNetwork instance;
        public static GameServerNetwork Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameServerNetwork();
                return instance;
            }
        }

        // Init Network Controller
        public void initTCP()
        {
            if (TCPClient == null)
            {
                // Networking //
                NetPeerConfiguration config = new NetPeerConfiguration("Elysium Diamond #1.0.0");
                config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
                config.ConnectionTimeout = 25.0f;
                config.PingInterval = 4.0f;
                config.UseMessageRecycling = false;
                config.AutoFlushSendQueue = true;

                TCPClient = new NetClient(config);
                TCPClient.Start();
                TCPClient.Socket.Blocking = false;
            }

            if (string.IsNullOrEmpty(Settings.GameServerIP)) { return; }

            if (Connected() == false)
            {
                // Check if server is online //
                if (Environment.TickCount >= tick + 1000)
                {
                    TCPClient.DiscoverKnownPeer(Settings.GameServerIP, Settings.GameServerPort);
                    tick = Environment.TickCount;
                }
            }
        }

        // Discover Server
        public bool DiscoverServer()
        {
            if (string.IsNullOrEmpty(Settings.GameServerIP)) { return false; }

            if (Connected())
                return true;

            if (GameServerNetwork.Instance.TCPClient.DiscoverKnownPeer(Settings.GameServerIP, Settings.GameServerPort))
                return true;

            return false;
        }

        // Check if player is connected
        public bool Connected()
        {
            if (TCPClient == null) { return false; }
            if (TCPClient.ConnectionStatus == NetConnectionStatus.Connected) return true; else return false;
        }

        // Send Message
        public void SendData(NetOutgoingMessage data)
        {
            TCPClient.SendMessage(data, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendData(NetOutgoingMessage data, NetDeliveryMethod delivery)
        {
            TCPClient.SendMessage(data, delivery);
        }

        // Check Incoming Message
        public void ReceiveData()
        {
            if (TCPClient == null) { return; }

            // READ INCOMING MESSAGE //
            while ((incMsg = TCPClient.ReadMessage()) != null)
            {
                switch (incMsg.MessageType)
                {
                    case NetIncomingMessageType.DiscoveryResponse:
                        TCPClient.Connect(incMsg.SenderEndPoint);
                        break;
                    case NetIncomingMessageType.Data:
                        GameServerHandle.HandleData(incMsg);
                        break;
                }

                TCPClient.Recycle(incMsg);
            }
        }

    }
}