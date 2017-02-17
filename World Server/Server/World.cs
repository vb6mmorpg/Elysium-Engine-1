using System;
using WorldServer.Network;
using WorldServer.ClasseData;
using WorldServer.Common;
using WorldServer.MySQL;

namespace WorldServer.Server {
    public class World {
        public static void Loop() {
            try {
                //Recebe os dados do world server
                WorldNetwork.ReceivedData();

                // Verifica e tenta uma nova conexão com o game server
                GameNetwork.GameServerConnect();

                // Recebe os dados do game server
                GameNetwork.GameServerReceiveData();

                // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
                // Se verdadeiro, é retirado da lista
                Authentication.VerifyHexID();

                // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
                Authentication.VerifyPlayerHexID();
            }
            catch (Exception ex) {
                throw new Exception($"Ocorreu um erro: {ex.Message}", ex);
            }
        }

        public static void Close() {
            Common_DB.Close();
            WorldNetwork.Shutdown();
            GameNetwork.Shutdown();
            Classe.Clear();
            Configuration.Clear();
            Authentication.Clear();
            ProhibitedNames.Clear();
            FileLog.Close();
        }
    }

}
