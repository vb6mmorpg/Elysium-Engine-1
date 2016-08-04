using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.Common;

namespace WorldServer.Network {
    public class GameServerNetwork {
        /// <summary>
        /// Tick do tempo de descoberta de rede. 
        /// </summary>
        static int tick;

        /// <summary>
        /// Cliente de conexão com o game server.
        /// </summary>
        public static NetworkClient[] GameServer = new NetworkClient[5];

        /// <summary>
        /// Inicializa e configura as 5 conexões com GameServer
        /// </summary>
        public static void InitializeGameServer() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                GameServer[n] = new NetworkClient();

                //se possível, manter a conexão do game server em rede local para maior desempenho.
                if (!string.IsNullOrEmpty(Settings.GameServer[n].Name)) {
                    GameServer[n].initTCP(Settings.GameServer[n].GameServerLocalIP, Settings.GameServer[n].GameServerIP, Settings.GameServer[n].GameServerPort);
                }
            }
        }

        /// <summary>
        /// Faz a conexão com GameServer
        /// </summary>
        public static void GameServerConnect() {
            // Faz a descoberta de rede a cada 10 segundos, se inativo, tenta uma nova conexão.
            if (Environment.TickCount >= (tick + 10000)) {
                tick = Environment.TickCount;

                for (var n = 0; n < Settings.MAX_SERVER; n++) {
                    GameServer[n].DiscoverServer();
                }
            }
        }

        /// <summary>
        /// Recebe os dados de cada GameServer
        /// </summary>
        public static void GameServerReceiveData() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                GameServer[n].ReceiveData(n);
            }
        }
    }
}
