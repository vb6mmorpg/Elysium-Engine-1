using System;
using System.Collections.Generic;

namespace WorldServer.Common {
    public static class Settings {
        /// <summary>
        /// Chave para criptografia.
        /// </summary>
        public static string Key { get; set; }

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Nome de identificação
        /// </summary>
        public static string WorldServerName { get; set; }

        /// <summary>
        /// IP de World.
        /// </summary>
        public static string IP { get; set; }

        /// <summary>
        /// Porta de World.
        /// </summary>
        public static int Port { get; set; }

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
        public static List<ServerData> GameServer { get; set; }

        /// <summary>
        /// Caminho do executável.
        /// </summary>
        public static string ServerPath { get; } = Environment.CurrentDirectory;

        /// <summary>
        /// Arquivo de configuração.
        /// </summary>
        public const string FileConfig = "WorldConfig.txt";

        public static bool CharacterCreation { get; set; }
        public static bool CharacterDelete { get; set; }
        public static int CharacterDeleteMinLevel { get; set; }
        public static int CharacterDeleteMaxLevel { get; set; }
    }


}
