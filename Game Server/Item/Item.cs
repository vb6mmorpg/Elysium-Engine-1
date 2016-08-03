using GameServer.Common;

namespace GameServer.Item {
    public class Item : Stat {
        public int ID { get; set; }
        public string Version { get; set; }
        public bool Useable { get; set; }
        public byte Handed { get; set; }
        public int Sprite { get; set; }
        public int Price { get; set; }
        public int Durability { get; set; }
        public int Animation { get; set; }
        public byte Rare { get; set; }
        public byte AttackRange { get; set; }
        public byte Type { get; set; }
        public int ItemLevel { get; set; }
    }
}
