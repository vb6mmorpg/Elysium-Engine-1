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
                case (int)PacketList.LoginServer_Client_SendPlayerHexID: LoginData.HexID(msg.ReadString()); break;
                case (int)PacketList.LoginServer_Client_ServerList: LoginData.ServerList(msg); break;

                case (int)PacketList.WorldServer_Client_CharacterDeleted: Message.Show(PacketList.WorldServer_Client_CharacterDeleted); break;
                case (int)PacketList.WorldServer_Client_CharNameInUse: Message.Show(PacketList.WorldServer_Client_CharNameInUse); break;
                case (int)PacketList.WorldServer_Client_CharacterCreationDisabled: Message.Show(PacketList.WorldServer_Client_CharacterCreationDisabled); break;
                case (int)PacketList.WorldServer_Client_CharacterDeleteDisabled: Message.Show(PacketList.WorldServer_Client_CharacterDeleteDisabled); break;           
                case (int)PacketList.WorldServer_Client_InvalidLevelToDelete: Message.Show(PacketList.WorldServer_Client_InvalidLevelToDelete); break;


                case (int)PacketList.GameServer_Client_NeedHexID: GamePacket.GameServerHexID(); break;
                case (int)PacketList.GameServer_Client_PlayerData: GameData.PlayerData(msg); break;
               // case (int)PacketList.GameServer_SendNpc: GameServerData.ReceiveNpc(msg); break;
                case (int)PacketList.GameServer_Client_GetMapPlayer: GameData.GetPlayerMap(msg); break;
                case (int)PacketList.GameServer_Client_PlayerMapMove: GameData.PlayerMapMove(msg); break;
  

                case (int)PacketList.WorldServer_Client_NeedPlayerHexID: WorldPacket.WorldServerHexID(); break;
                case (int)PacketList.WorldServer_Client_CharacterPreLoad: WorldData.PreLoad(msg); break;
               // case (int)PacketList.WorldServer_Client_GuildInfo: WorldServerData.WorldGuildInfo(msg); break;
                case (int)PacketList.WorldServer_Client_GameServerData: WorldData.GameServerData(msg); break;

                case (int)PacketList.GameServer_Client_PlayerLocation: GameData.PlayerLocation(msg); break;
                case (int)PacketList.GameServer_Client_PlayerStats: GameData.PlayerStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerVital: GameData.PlayerVital(msg); break;
                case (int)PacketList.GameServer_Client_PlayerVitalRegen: GameData.PlayerVitalRegen(msg); break;
                case (int)PacketList.GameServer_Client_PlayerPhysicalStats: GameData.PlayerPhysicalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerExp: GameData.PlayerExp(msg); break;
                case (int)PacketList.GameServer_Client_PlayerMagicalStats: GameData.PlayerMagicalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerUniqueStats: GameData.PlayerUniqueStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerElementalStats: GameData.PlayerElementalStats(msg); break;
                case (int)PacketList.GameServer_Client_PlayerResistStats: GameData.PlayerResistStats(msg); break;
                case (int)PacketList.GameServer_Client_RemovePlayerFromMap: GameData.RemovePlayerMap(msg.ReadInt32()); break;
            }
        }
    }
}
