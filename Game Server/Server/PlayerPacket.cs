using Lidgren.Network;
using GameServer.Common;
using GameServer.Network;

namespace GameServer.Server {
    public partial class PlayerData : Stat {
        public void SendData() {
            var buffer = GameServerNetwork.Socket.CreateMessage();

            buffer.Write((int)PacketList.GameServer_Client_PlayerData);
            buffer.Write(CharacterName);
            buffer.Write(GuildName);
            buffer.Write(Sprite);
            buffer.Write(Level);
            buffer.Write(Exp);
            buffer.Write(Direction);
            buffer.Write(PosX);
            buffer.Write(PosY);

            GameServerNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }


        /// <summary>
        /// Send Exp 
        /// </summary>
        public void SendExp() {
            var buffer = GameServerNetwork.Socket.CreateMessage();

            //buffer.Write((int)PacketList.GameServer_Client_PlayerExp);
            buffer.Write(Exp);

            GameServerNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a localidade.
        /// </summary>
        public void SendLocation() {
            var buffer = GameServerNetwork.Socket.CreateMessage();

            //buffer.Write((int)PacketList.GameServer_Client_PlayerCoordinate);
            buffer.Write(WorldID);
            buffer.Write(RegionID);
            buffer.Write(PosX);
            buffer.Write(PosY);

            GameServerNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }


        /// <summary>
        /// Envia os stats.
        /// </summary>
        public void SendStats() {
            var buffer = GameServerNetwork.Socket.CreateMessage();

            //buffer.Write((int)PacketList.GameServer_Client_PlayerStats);
            buffer.Write(Strenght);
            buffer.Write(Dexterity);
            buffer.Write(Agility);
            buffer.Write(Constitution);
            buffer.Write(Intelligence);
            buffer.Write(Wisdom);
            buffer.Write(Will);
            buffer.Write(Mind);
            buffer.Write(Charisma);
            buffer.Write(StatPoint);

            GameServerNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os dados de vitalidade.
        /// </summary>
        public void SendVital() {
            var buffer = GameServerNetwork.Socket.CreateMessage();

            //buffer.Write((int)PacketList.GameServer_Client_PlayerVital);
            buffer.Write(HP);
            buffer.Write(MaxHP);
            buffer.Write(MP);
            buffer.Write(MaxMP);
            buffer.Write(SP);
            buffer.Write(MaxSP);

            GameServerNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered, 0);
        }


    }
}
