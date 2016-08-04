using WorldServer.MySQL;
using WorldServer.Network;
using WorldServer.Common;

namespace WorldServer.Server {
    public class PlayerLogin {
        public static void Login(PlayerData pData) {
            // Carrega os personagens para aprensetar ao cliente.
            //4 = max_character
            const int MAX_CHAR = 4;

            for (var n = 0; n < MAX_CHAR; n++) {
                pData.Character[n] = new Character() { Name = string.Empty } ;
                                              
                Character_DB.PreLoad(pData, n);
            }

            LogConfig.WriteLog("PreLoad ID: " + pData.AccountID + " Account: " + pData.Account, System.Drawing.Color.Black);

            // Envia o PreLoad
            WorldServerPacket.PreLoad(pData);

            //Aceita a conexão
            WorldServerPacket.Message(pData.Connection, (int)PacketList.AcceptedConnection);

            // Muda de janela
            WorldServerPacket.GameState(pData.HexID, 3);
        }

    }
}
