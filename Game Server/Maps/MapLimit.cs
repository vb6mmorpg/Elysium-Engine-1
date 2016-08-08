namespace GameServer.Maps {
    public struct MapLimit {
        public Limit Min { get; set; }
        public Limit Max { get; set; }
     }

    public struct Limit {
        public int X { get; set; }
        public int Y { get; set; }
    }

}


