using GameServer.Common;
using GameServer.Network;

namespace GameServer.Server{
    public class ServerLoop {
    
        public static void Loop() {
            // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
            // Se verdadeiro, é retirado da lista
            Authentication.VerifyHexID();

            // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyPlayerHexID();

            // Recebe os dados do game server
            GameNetwork.ReceiveData();      
        }

        public static void Close() {

        }
    }
}
    
   

