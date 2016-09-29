using GameServer.Common;
using GameServer.Network;
using System.Threading;

namespace GameServer.Server{
    public class ServerLoop {

        public static void Initialize() {

        }
    
        public static void Loop() {
            // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
            // Se verdadeiro, é retirado da lista
            Authentication.VerifyHexID();

            // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyPlayerHexID();

            // Recebe os dados do game server
            GameServerNetwork.ReceiveData();

            if (Settings.Sleep > 0) { Thread.Sleep(Settings.Sleep); }          
        }

        public static void Close() {

        }
    }
}
    
   

