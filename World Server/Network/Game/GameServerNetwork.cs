using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.Common;

namespace WorldServer.Network {
    public class GameServerNetwork {
        static int tick;
        public static NetworkClient[] GameServer = new NetworkClient[5];

        /// <summary>
        /// Inicializa e configura as 5 conexões com WorldServer
        /// </summary>
        public static void InitializeGameServer() {
            for (var n = 0; n < 5; n++) {
                GameServer[n] = new NetworkClient();

                if (!string.IsNullOrEmpty(Settings.GameServer[n].Name)) {
                    GameServer[n].initTCP(Settings.GameServer[n].GameServerLocalIP, Settings.GameServer[n].GameServerIP, Settings.GameServer[n].GameServerPort);
                }
            }
        }

        /// <summary>
        /// Faz a conexão com WorldServer
        /// </summary>
        public static void GameServerConnect() {
            // Faz a descoberta de rede a cada 10 segundos.
            if (Environment.TickCount >= (tick + 10000)) {

                tick = Environment.TickCount;

                for (var n = 0; n < 5; n++) {
                    GameServer[n].DiscoverServer();
                }
            }
        }

        /// <summary>
        /// Recebe os dados de WorldServer
        /// </summary>
        public static void GameServerReceiveData() {
            for (var n = 0; n < 5; n++) {
                GameServer[n].ReceiveData(n);
            }
        }
    }
}
