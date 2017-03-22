namespace GameServer.Server {
    public class HexaID {
        public int Time { get; set; }
        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public int CharacterID { get; set; }
        public int CharSlot { get; set; }
        public byte LanguageID { get; set; }
        public short AccessLevel { get; set; }
        public PlayerService Service { get; set; }

        public HexaID() {
            Service = new PlayerService();
        }
    } 
}
