namespace GameServer.Server {
    public class HexaID {
        public int Time { get; set; }
        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public int CharacterID { get; set; }
        public int CharSlot { get; set; }
        public int LanguageID { get; set; }
        public int AccessLevel { get; set; }
        public string Pin { get; set; } // nao usado
        public PlayerService Service { get; set; }

        public HexaID() {
            Service = new PlayerService();
        }
    } 
}
