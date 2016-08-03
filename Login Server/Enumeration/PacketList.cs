namespace LoginServer.Network {
    public enum PacketList : int {
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

        //login server to world server
        LoginServer_WorldServer_DisconnectPlayer = 0x0135,
        LoginServer_WorldServer_SendPlayerHexID = 0x0136, 
        LoginServer_WorldServer_IsPlayerConnected = 0x0137, //返事する為に、同じパケットを使用する
    }
}
