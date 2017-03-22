using System;
using System.Collections.Generic;

namespace WorldServer.Common {
    public static class Settings {
        /// <summary>
        /// Arquivo de configuração.
        /// </summary>
        public const string FILE_CONFIG = "WorldConfig.txt";

        /// <summary>
        /// Quantidade de personagem.
        /// </summary>
        public const int MAX_CHAR = 4;

        /// <summary>
        /// Quantidade de servidores. 
        /// </summary>
        public const int MAX_SERVER = 5;

        /// <summary>
        /// Quantidade de items.
        /// </summary>
        public const int MAX_ITEM = 15;

        /// <summary>
        /// Quantidade de stats.
        /// </summary>
        public const int MAX_STATS = 10;

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Nome de identificação
        /// </summary>
        public static string WorldServerName { get; set; }

        /// <summary>
        /// Porta de World.
        /// </summary>
        public static int Port { get; set; }

        /// <summary>
        /// Porta de World.
        /// </summary>
        public static int ConnectionTimeOut { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaxConnection { get; set; }

        /// <summary>
        /// Ativa ou desativa o sistema de logs.
        /// </summary>
        public static bool LogSystem { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

        /// <summary>
        /// Lista de Canal / Servidor.
        /// </summary>
        public static ServerData[] GameServer { get; set; } = new ServerData[MAX_SERVER];

        /// <summary>
        /// Caminho do executável.
        /// </summary>
        public static string ServerPath { get; } = Environment.CurrentDirectory;
    }
}
