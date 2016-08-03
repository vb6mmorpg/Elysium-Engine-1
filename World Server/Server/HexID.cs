namespace WorldServer.Server {
    public class HexaID {
        /// <summary>
        /// Tempo dos dados no servidor.
        /// </summary>
        public int Time { get; set; }
        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public int LanguageID { get; set; }
        public int AccessLevel { get; set; }
        public int Cash { get; set; }
        public string Pin { get; set; }
        public PlayerService Service { get; set; }

        public HexaID() {
            Service = new PlayerService();
        }

    } 
}
