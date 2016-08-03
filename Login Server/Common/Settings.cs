using System;
using System.Collections.Generic;

namespace LoginServer.Common {
    public static class Settings {
        public const string FileConfig = "LoginConfig.txt";
        public const int MAX_SERVER = 5;
        /// <summary>
        /// Chave para criptografia.
        /// </summary>
        public static string Key { get; set; }
        
        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// IP de Login.
        /// </summary>
        public static string IP { get; set; }

        /// <summary>
        /// Porta de Login.
        /// </summary>
        public static int Port { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaxConnection { get; set; }

        /// <summary>
        /// Ativa ou desativa o sistema de logs.
        /// </summary>
        public static int LogSystem { get; set; }

        /// <summary>
        /// Ativa ou desativa mensagens de logs na tela.
        /// </summary>
        public static bool LogSystemScreen { get; set; }
          
        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

        /// <summary>
        /// Desativa o login temporariamente.
        /// </summary>
        public static bool CantConnectNow { get; set; }

        /// <summary>
        /// Versão do cliente e servidor
        /// </summary>
        public static string Version { get; set; }

        /// <summary>
        /// Caminho do executável.
        /// </summary>
        public static string ServerPath { get; } = Environment.CurrentDirectory;

        /// <summary>
        /// Lista de Canal / Servidor.
        /// </summary>
        public static List<ServerData> Server { get; set; }

        /// <summary>
        /// Formulário único e príncipal.
        /// </summary>
        public static frmMain ConnectForm { get; set; }       
    }
}
