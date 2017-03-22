namespace WorldServer.Common {
    /// <summary>
    /// Dados de Canal / Servidor.
    /// </summary>
    public struct ServerData {
        /// <summary>
        /// IP externo para World Server.
        /// </summary>
        public string GameServerIP { get; set; }

        /// <summary>
        /// Somente usado quando os servidores estiverem em rede local.
        /// </summary>
        public string GameServerLocalIP { get; set; }

        /// <summary>
        /// Porta de servidor.
        /// </summary>
        public int GameServerPort { get; set; }

        /// <summary>
        /// Nome de identificação.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Região ou país.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Condições de canal / servidor.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        public void Clear() {
            Name = string.Empty;
            GameServerIP = string.Empty;
            GameServerLocalIP = string.Empty;
            Region = string.Empty;
            Status = string.Empty;
        }
    }
}
