namespace GameServer.Maps {
    public class MapRegion {
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

        /// <summary>
        /// Limites de região de mapa.
        /// </summary>
        public MapLimit RegionLimit { get; set; }

        /*
        public void SetLimit(Limit min, Limit max) {

        }

        public void SetLimit(int minx, int miny, int maxx, int maxy) {

        }

        public void SetRegion(int id, string ip, int port) {
            ID = id;
            IP = ip;
            Port = port;
        }
        */
    }
}
