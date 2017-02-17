using WorldServer.MySQL;
using WorldServer.Network;
using WorldServer.Common;

namespace WorldServer.Server {
    public class PlayerLogin {
        public static void Login(PlayerData pData) {
            //Carrega os personagens para apresentar ao cliente.                                             
            Character_DB.PreLoad(pData);
 
            FileLog.WriteLog($"PreLoad ID: {pData.AccountID} Account: {pData.Account}", System.Drawing.Color.Black);

            //Envia o PreLoad
            WorldPacket.PreLoad(pData);
            //Aceita a conexão
            WorldPacket.Message(pData.Connection, (int)PacketList.AcceptedConnection);
            //Muda de janela
            WorldPacket.GameState(pData.HexID, 3);
        }
    }
}
