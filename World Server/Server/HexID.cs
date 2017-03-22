namespace WorldServer.Server {
    public class HexaID {
        /// <summary>
        /// Tempo dos dados no servidor. (30 segundos)
        /// </summary>
        public int Time { get; set; }
        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public byte LanguageID { get; set; }
        public short AccessLevel { get; set; }
        public int Cash { get; set; }

        /// <summary>
        /// Senha de segurança dos personagens.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Serviços de conta de usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public HexaID() {
            //instancia o serviço
            Service = new PlayerService();
        }
    } 
}
