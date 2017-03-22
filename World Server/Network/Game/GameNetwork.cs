using System;
using WorldServer.Common;

namespace WorldServer.Network {
    public class GameNetwork {
        /// <summary>
        /// Tick do tempo de descoberta de rede. 
        /// </summary>
        private static int tick;

        /// <summary>
        /// Cliente de conexão com o game server.
        /// </summary>
        public static NetworkClient[] GameServer = new NetworkClient[Settings.MAX_SERVER];

        /// <summary>
        /// Inicializa e configura as 5 conexões com GameServer
        /// </summary>
        public static void InitializeGameServer() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) {
                GameServer[index] = new NetworkClient();

                //se possível, manter a conexão do game server em rede local para maior desempenho.
                if (!string.IsNullOrEmpty(Settings.GameServer[index].Name)) {
                    GameServer[index].InitializeClient(Settings.GameServer[index].GameServerLocalIP, Settings.GameServer[index].GameServerIP, Settings.GameServer[index].GameServerPort);
                }
            }
        }

        public static void Shutdown() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) {
                GameServer[index].Shutdown();
            }
        }

        /// <summary>
        /// Faz a conexão com GameServer
        /// </summary>
        public static void GameServerConnect() {
            // Faz a descoberta de rede a cada 10 segundos, se inativo, tenta uma nova conexão.
            if (Environment.TickCount >= (tick + 10000)) {
                tick = Environment.TickCount;

                for (var index = 0; index < Settings.MAX_SERVER; index++) {
                    GameServer[index].DiscoverServer();
                }
            }
        }

        /// <summary>
        /// Recebe os dados de cada GameServer
        /// </summary>
        public static void GameServerReceiveData() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) {
                GameServer[index].ReceiveData(index);
            }
        }
    }
}
