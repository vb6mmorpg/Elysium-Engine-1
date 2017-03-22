using Lidgren.Network;
using GameServer.Common;
using GameServer.Network;
using GameServer.ClasseData;

namespace GameServer.Server {
    public partial class PlayerData : StatsBase {
        /// <summary>
        /// Envia informações básicas.
        /// </summary>
        public void SendPlayerBasicData() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerData);
            buffer.Write(CharacterName);
            buffer.Write(Sprite);
            buffer.Write(Level);
            buffer.Write(Exp);
            buffer.Write(Points);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }    

        /// <summary>
        /// Envia a experiência.
        /// </summary>
        public void SendPlayerExp() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerExp);
            buffer.Write(Exp);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia o vital.
        /// </summary>
        public void SendPlayerVital() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerVital);
            buffer.Write(MaxHP);
            buffer.Write(HP);
            buffer.Write(MaxMP);
            buffer.Write(MP);
            buffer.Write(MaxSP);
            buffer.Write(SP);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a regeneração.
        /// </summary>
        public void SendPlayerVitalRegen() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerVitalRegen);
            buffer.Write(RegenHP);
            buffer.Write(RegenMP);
            buffer.Write(RegenSP);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
        
        /// <summary>
        /// Envia as coordenadas e direção.
        /// </summary>
        public void SendPlayerLocation() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerLocation);
            buffer.Write(WorldID);
            buffer.Write(RegionID);
            buffer.Write(Direction);
            buffer.Write(PosX);
            buffer.Write(PosY);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos.
        /// </summary>
        public void SendPlayerStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerStats);
            buffer.Write(Strenght);
            buffer.Write(Dexterity);
            buffer.Write(Agility);
            buffer.Write(Constitution);
            buffer.Write(Intelligence);
            buffer.Write(Wisdom);
            buffer.Write(Will);
            buffer.Write(Mind);
            buffer.Write(Charisma);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
        
        /// <summary>
        /// Envia os atributos fisicos
        /// </summary>
        public void SendPlayerPhysicalStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerPhysicalStats);
            buffer.Write(Attack);
            buffer.Write(Accuracy);
            buffer.Write(Defense);
            buffer.Write(Evasion);
            buffer.Write(Block);
            buffer.Write(Parry);
            buffer.Write(CriticalRate);
            buffer.Write(CriticalDamage);
            buffer.Write(AttackSpeed);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
 
        /// <summary>
        /// Envia os atributos magicos
        /// </summary>
        public void SendPlayerMagicStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerMagicalStats);
            buffer.Write(MagicAttack);
            buffer.Write(MagicAccuracy);
            buffer.Write(MagicDefense);
            buffer.Write(MagicResist);
            buffer.Write(MagicCriticalRate);
            buffer.Write(MagicCriticalDamage);
            buffer.Write(CastSpeed);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos unicos
        /// </summary>
        public void SendPlayerUniqueStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerUniqueStats);
            buffer.Write(Concentration);
            buffer.Write(HealingPower);
            buffer.Write(Enmity);
            buffer.Write(DamageSuppression);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos elementais
        /// </summary>
        public void SendPlayerElementalStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerElementalStats);
            buffer.Write(AttributeEarth);
            buffer.Write(AttributeFire);
            buffer.Write(AttributeWater);
            buffer.Write(AttributeWind);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos de resistencia
        /// </summary>
        public void SendPlayerResistStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerResistStats);
            buffer.Write(ResistStun);
            buffer.Write(ResistParalysis);
            buffer.Write(ResistBlind);
            buffer.Write(ResistSilence);
            buffer.Write(ResistCriticalRate);
            buffer.Write(ResistCriticalDamage);
            buffer.Write(ResistMagicCriticalRate);
            buffer.Write(ResistMagicCriticalDamage);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
