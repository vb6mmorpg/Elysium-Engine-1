using System;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public static class NetworkPacket {
        public static void ProcessPacket(NetIncomingMessage msg) {
            var index = msg.ReadInt32();

            if (index < 0) { return; }

            switch (index) {
                case (int)PacketList.None: break;
                case (int)PacketList.Error: Message.Show(PacketList.Error); break;
                case (int)PacketList.Disconnect: Message.Show(PacketList.Disconnect); break;
                case (int)PacketList.Ping: CommonData.Ping(); break;
                case (int)PacketList.AcceptedConnection: Message.Show(PacketList.AcceptedConnection); break;
                case (int)PacketList.ChangeGameState: CommonData.ChangeGameState(msg.ReadByte()); break;
                case (int)PacketList.InvalidVersion: Message.Show(PacketList.InvalidVersion); break;
                case (int)PacketList.CantConnectNow: Message.Show(PacketList.CantConnectNow); break;
                case (int)PacketList.LoginServer_Client_Maintenance: Message.Show(PacketList.LoginServer_Client_Maintenance); break;
                case (int)PacketList.LoginServer_Client_AccountBanned: Message.Show(PacketList.LoginServer_Client_AccountBanned); break;
                case (int)PacketList.LoginServer_Client_AccountDisabled: Message.Show(PacketList.LoginServer_Client_AccountDisabled); break;
                case (int)PacketList.LoginServer_Client_InvalidNamePass: Message.Show(PacketList.LoginServer_Client_InvalidNamePass); break;
                case (int)PacketList.LoginServer_Client_AlreadyLoggedIn: Message.Show(PacketList.LoginServer_Client_AlreadyLoggedIn); break;
                case (int)PacketList.LoginServer_Client_SendPlayerHexID: LoginServerData.HexID(msg.ReadString()); break;
                case (int)PacketList.LoginServer_Client_ServerList: LoginServerData.ServerList(msg); break;

                case (int)PacketList.WorldServer_Client_CharacterDeleted: Message.Show(PacketList.WorldServer_Client_CharacterDeleted); break;
                case (int)PacketList.WorldServer_Client_CharNameInUse: Message.Show(PacketList.WorldServer_Client_CharNameInUse); break;
                case (int)PacketList.WorldServer_Client_CharacterCreationDisabled: Message.Show(PacketList.WorldServer_Client_CharacterCreationDisabled); break;
                case (int)PacketList.WorldServer_Client_CharacterDeleteDisabled: Message.Show(PacketList.WorldServer_Client_CharacterDeleteDisabled); break;           
                case (int)PacketList.WorldServer_Client_InvalidLevelToDelete: Message.Show(PacketList.WorldServer_Client_InvalidLevelToDelete); break;


                case (int)PacketList.GameServer_Client_NeedHexID: GameServerPacket.GameServerHexID(); break;
                case (int)PacketList.GameServer_Client_PlayerData: GameServerData.PlayerData(msg); break;
               // case (int)PacketList.GameServer_SendNpc: GameServerData.ReceiveNpc(msg); break;
                case (int)PacketList.GameServer_Client_GetMapPlayer: GameServerData.GetPlayerOnMap(msg); break;
                case (int)PacketList.GameServer_Client_PlayerMapMove: GameServerData.PlayerMapMove(msg); break;
  

                case (int)PacketList.WorldServer_Client_NeedPlayerHexID: WorldServerPacket.WorldServerHexID(); break;
                case (int)PacketList.WorldServer_Client_CharacterPreLoad: WorldServerData.PreLoad(msg); break;
               // case (int)PacketList.WorldServer_Client_GuildInfo: WorldServerData.WorldGuildInfo(msg); break;
                case (int)PacketList.WorldServer_Client_GameServerData: WorldServerData.GameServerData(msg); break;

                case (int)PacketList.GameServer_Client_PlayerLocation: GameServerData.PlayerLocation(msg); break;
                case (int)PacketList.GameServer_Client_PlayerStats: GameServerData.PlayerStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerVital: GameServerData.PlayerVital(msg); break;
                case (int)PacketList.GameServer_Client_PlayerVitalRegen: GameServerData.PlayerVitalRegen(msg); break;
                case (int)PacketList.GameServer_Client_PlayerPhysicalStats: GameServerData.PlayerPhysicalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerExp: GameServerData.PlayerExp(msg); break;
                case (int)PacketList.GameServer_Client_PlayerMagicalStats: GameServerData.PlayerMagicalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerUniqueStats: GameServerData.PlayerUniqueStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerElementalStats: GameServerData.PlayerElementalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerResistStats: GameServerData.PlayerResistStats(msg); break;
            }
        }
    }
}
