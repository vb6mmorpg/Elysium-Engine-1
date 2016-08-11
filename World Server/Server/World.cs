using System;
using WorldServer.Network;

namespace WorldServer.Server {
    public class World {
        public static void Loop() {
            try {
                //Recebe os dados do world server
                WorldServerNetwork.ReceivedData();

                // Verifica e tenta uma nova conexão com o game server
                GameServerNetwork.GameServerConnect();

                // Recebe os dados do game server
                GameServerNetwork.GameServerReceiveData();

                // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
                // Se verdadeiro, é retirado da lista
                Authentication.VerifyHexID();

                // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
                Authentication.VerifyPlayerHexID();
            }
            catch (Exception ex) {
                throw new Exception("Ocorreu um erro", ex);
            }
        }
    }

}
