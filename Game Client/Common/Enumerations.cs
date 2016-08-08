using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium_Diamond.Common {
    public enum Language {
        English,
        Portuguese,
        Japanese,
        Spanish,
        Korean
    }

    public enum PacketList {
        //0~199 basic message
        None = 0x0000,
        Error = 0x0001,
        Disconnect = 0x0002,
        Ping = 0x0003,
        AcceptedConnection = 0x0004,
        ChangeGameState = 0x0005,
        InvalidVersion = 0x0006,
        CantConnectNow = 0x0007,

        //200~299; cliente to login server;
        Client_LoginServer_Login = 0x00C8,
        Client_LoginServer_BackToLogin = 0x00C9,
        Client_LoginServer_WorldServerConnect = 0x00CA,

        //300~399; login server to cliente;
        LoginServer_Client_ServerList = 0x012C,
        LoginServer_Client_ChannelList = 0x012D, //使用はない
        LoginServer_Client_Maintenance = 0x012E,
        LoginServer_Client_AccountBanned = 0x012F,
        LoginServer_Client_AccountDisabled = 0x0130,
        LoginServer_Client_InvalidNamePass = 0x0131,
        LoginServer_Client_AlreadyLoggedIn = 0x0132,
        LoginServer_Client_SendPlayerHexID = 0x0133,
        LoginServer_Client_SendPin = 0x0134, //使用はない

        LoginServer_WorldServer_DisconnectPlayer = 0x0135,
        LoginServer_WorldServer_SendPlayerHexID = 0x0136,
        LoginServer_WorldServer_IsPlayerConnected = 0x0137,

        //400 ~ 499 client to world server
        Client_WorldServer_SendPlayerHexID = 0x0190,
        Client_WorldServer_DeleteCharacter = 0x0191,
        Client_WorldServer_CreateCharacter = 0x0192,
        Client_WorldServer_EnterInGame = 0x0193,

        //500 ~599 world server to client
        WorldServer_Client_CharacterCreationDisabled = 0x01F4,
        WorldServer_Client_CharacterDeleteDisabled = 0x01F5,
        WorldServer_Client_CharacterCreated = 0x01F6,
        WorldServer_Client_CharacterDeleted = 0x01F7,
        WorldServer_Client_NeedPlayerHexID = 0x01F8,
        WorldServer_Client_CharacterPreLoad = 0x01F9,
        WorldServer_Client_GuildNameInUse = 0x01FA,
        WorldServer_Client_UserAlreadyInGuild = 0x01FB,
        WorldServer_Client_GuildInfo = 0x01FC,
        WorldServer_Client_GuildMemberInfo = 0x01FD,
        WorldServer_Client_GuildHistoryInfo = 0x01FE,
        WorldServer_Client_CharNameInUse = 0x01FF,
        WorldServer_Client_InvalidLevelToDelete = 0x0200,
        WorldServer_Client_GameServerData = 0x0201,
        WorldServer_GameServer_GameServerLogin = 0x0202,

        //1000 client to game server
        Client_GameServer_SendPlayerHexID = 0x03E8,
        Client_GameServer_PlayerMove = 0x03E9,

        //2000 game server to client
        GameServer_Client_NeedHexID = 0x07D0,
        GameServer_Client_PlayerData = 0x07D1,
        GameServer_Client_GetMapPlayer = 0x07D2,
        GameServer_Client_PlayerMapMove = 0x07D3

    }
}
