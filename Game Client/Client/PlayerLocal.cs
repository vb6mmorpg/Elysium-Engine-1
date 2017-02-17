using Elysium_Diamond.DirectX;
namespace Elysium_Diamond.Client {
    public class PlayerLocal : StatsBase {
        public int ID { get; set; }
        public string CharacterName { get; set; }
        public string GuildName { get; set; }
        public short Sprite { get; set; }
        public short Direction { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public long Exp { get; set; }   
        public int RegionID { get; set; }
        public int WorldID { get; set; }

        public static PlayerLocal Data = new PlayerLocal();
        public static EngineCharacter Character = new EngineCharacter();
    }
}
