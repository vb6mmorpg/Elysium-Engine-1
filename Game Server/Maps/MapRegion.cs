namespace GameServer.Maps {
    public struct MapRegion {
        /// <summary>
        /// Identificação.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Ip do game server.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Porta do game server.
        /// </summary>
        public int Port { get; set; } 
    }
}
