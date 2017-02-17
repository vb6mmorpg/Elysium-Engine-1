namespace WorldServer.Common {
    public class GameServerData {
        /// <summary>
        /// IP externo para World Server.
        /// </summary>
        public string GameServerIP { get; set; }

        /// <summary>
        /// Somente usado quando os servidores estiverem em rede local.
        /// </summary>
        public string GameServerLocalIP { get; set; }

        /// <summary>
        /// Porta de so servidor.
        /// </summary>
        public int GameServerPort { get; set; }

        /// <summary>
        /// Nome de identificação.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Condições de canal / servidor.
        /// </summary>
        public string Status { get; set; }
    }
}
