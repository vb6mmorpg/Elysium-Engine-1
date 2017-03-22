namespace LoginServer.Common {
    /// <summary>
    /// Dados de Canal / Servidor.
    /// </summary>
    public struct ServerData {
        /// <summary>
        /// IP externo para World Server.
        /// </summary>
        public string WorldServerIP { get; set; }

        /// <summary>
        /// Somente usado quando os servidores estiverem em rede local.
        /// </summary>
        public string WorldServerLocalIP { get; set; }

        /// <summary>
        /// Porta de conexão.
        /// </summary>
        public int WorldServerPort { get; set; }

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
        /// 
        /// </summary>
        public bool Online { get; set; }
    }
}
