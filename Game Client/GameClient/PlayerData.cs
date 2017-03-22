using Elysium_Diamond.DirectX;
namespace Elysium_Diamond.GameClient {
    public class PlayerData : StatsBase {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Guild { get; set; }
        public short Sprite { get; set; }
        public byte Direction { get; set; }
        public short X { get; set; }
        public short Y { get; set; }
        public long Exp { get; set; }   
        public short RegionID { get; set; }
        public short WorldID { get; set; }

        public EngineCharacter Character = new EngineCharacter();
    }
}
