using System;
using LoginServer.Common;

namespace LoginServer.Network {
    public static class WorldServerNetwork {
        static int tick;

        /// <summary>
        /// Quantidade de servidores conectados.
        /// </summary>
        public static short TotalOnline { get; set; }

        /// <summary>
        /// Dados do servidor (World).
        /// </summary>
        public static NetworkClient[] WorldServer = new NetworkClient[5];

        /// <summary>
        /// Inicializa e configura as 5 conexões com WorldServer.
        /// </summary>
        public static void InitializeWorldServer() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                WorldServer[n] = new NetworkClient();

                if (!string.IsNullOrEmpty(Settings.Server[n].Name)) {
                    WorldServer[n].InitializeClient(Settings.Server[n].WorldServerLocalIP, Settings.Server[n].WorldServerIP, Settings.Server[n].WorldServerPort);
                }
            }
        }

        /// <summary>
        /// Faz a conexão com WorldServer.
        /// </summary>
        public static void WorldServerConnect() {
            // Faz a descoberta de rede a cada 10 segundos.
            if (Environment.TickCount >= (tick + 10000)) {
                
                tick = Environment.TickCount;
                short counter = 0;

                for (var n = 0; n < Settings.MAX_SERVER; n++) {
                    WorldServer[n].DiscoverServer();

                    //Verifica se há algum servidor online
                    if (WorldServer[n].Connected()) {
                        Settings.Server[n].Online = true;
                        counter++;
                    }
                    else {
                        Settings.Server[n].Online = false;
                    }              
                }

                TotalOnline = counter;
            }
        }

        /// <summary>
        /// Recebe os dados de WorldServer.
        /// </summary>
        public static void WorldServerReceiveData() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) { WorldServer[n].ReceiveData(n); }
        }

        /// <summary>
        /// Verifica se há algum servidor conectado.
        /// </summary>
        /// <returns></returns>
        public static bool IsWorldServerConnected() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) {
                if (Settings.Server[n].Online) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Fecha as conexões.
        /// </summary>
        public static void Shutdown() {
            for (var n = 0; n < Settings.MAX_SERVER; n++) { WorldServer[n].Disconnect(); }
        }
    }
}
