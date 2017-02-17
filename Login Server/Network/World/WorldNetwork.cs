using System;
using LoginServer.Common;

namespace LoginServer.Network {
    public static class WorldNetwork {
        static int tick;

        /// <summary>
        /// Quantidade de servidores conectados.
        /// </summary>
        public static short TotalOnline { get; set; }

        /// <summary>
        /// Dados do servidor (World).
        /// </summary>
        public static NetworkClient[] WorldServer = new NetworkClient[Settings.MAX_SERVER];

        /// <summary>
        /// Inicializa e configura as 5 conexões com WorldServer.
        /// </summary>
        public static void InitializeWorldServer() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) {
                WorldServer[index] = new NetworkClient();

                if (!string.IsNullOrEmpty(Settings.Server[index].Name)) {
                    WorldServer[index].InitializeClient(Settings.Server[index].WorldServerLocalIP, Settings.Server[index].WorldServerIP, Settings.Server[index].WorldServerPort);
                }
            }
        }

        /// <summary>
        /// Faz a conexão com WorldServer.
        /// </summary>
        public static void WorldServerConnect() {
            // faz a descoberta de rede a cada 10 segundos.
            if (Environment.TickCount >= (tick + 10000)) {
                
                tick = Environment.TickCount;
                short counter = 0;

                for (var index = 0; index < Settings.MAX_SERVER; index++) {
                    WorldServer[index].DiscoverServer();

                    // verifica se há algum servidor online
                    if (WorldServer[index].Connected()) {
                        Settings.Server[index].Online = true;
                        counter++;
                    }
                    else {
                        Settings.Server[index].Online = false;
                    }              
                }

                TotalOnline = counter;
            }
        }

        /// <summary>
        /// Recebe os dados de WorldServer.
        /// </summary>
        public static void WorldServerReceiveData() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) { WorldServer[index].ReceiveData(index); }
        }

        /// <summary>
        /// Verifica se há algum servidor conectado.
        /// </summary>
        /// <returns></returns>
        public static bool IsWorldServerConnected() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) {
                if (Settings.Server[index].Online) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Fecha as conexões.
        /// </summary>
        public static void Shutdown() {
            for (var index = 0; index < Settings.MAX_SERVER; index++) { WorldServer[index].Shutdown(); }
        }
    }
}
