using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Network
{
    /// <summary>
    /// Mirage XNA
    /// </summary>
    public class WorldServerNetwork
    {
        private int tick;
        // TCP Client //
        public NetClient TCPClient;
        private NetIncomingMessage incMsg;

        // Private Constructor
        private WorldServerNetwork() { }

        // Singleton Accessor
        static WorldServerNetwork instance;
        public static WorldServerNetwork Instance
        {
            get
            {
                if (instance == null)
                    instance = new WorldServerNetwork();
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
                config.ConnectionTimeout = 25;
                config.UseMessageRecycling = true;

                TCPClient = new NetClient(config);
                TCPClient.Start();
                TCPClient.Socket.Blocking = false;
            }

            if (Connected() == false)
            {
                if (string.IsNullOrEmpty(Settings.WorldServerIP)) { return; }
                // Check if server is online //
                if (Environment.TickCount >= tick + 1000)
                {
                    TCPClient.DiscoverKnownPeer(Settings.WorldServerIP, Settings.WorldServerPort);
                    tick = Environment.TickCount;
                }
            }
        }

        // Discover Server
        public bool DiscoverServer()
        {
            if (Connected())
                return true;

            if (TCPClient.DiscoverKnownPeer(Settings.WorldServerIP, Settings.WorldServerPort))
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
        public void SendData(NetOutgoingMessage Data)
        {
            if (!Connected()) { return; }
            TCPClient.SendMessage(Data, NetDeliveryMethod.ReliableOrdered);
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
                        WorldServerData.HandleData(incMsg);
                        break;
                }

                TCPClient.Recycle(incMsg);
            }
        }

    }
}