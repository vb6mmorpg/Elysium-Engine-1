using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Maps {
    public class MapRegion {
        public int ID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; } 
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

    }
}
