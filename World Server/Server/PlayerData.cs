using Lidgren.Network;

namespace WorldServer.Server {
    public class PlayerData : HexaID {
        const int MAX_CHAR = 4;
        /// <summary>
        /// Dados temporários de personagem.
        /// </summary>
        public Character[] Character = new Character[MAX_CHAR];

        /// <summary>
        /// Player Socket.
        /// </summary>
        public NetConnection Connection { get; set; } = null;

        /// <summary>
        /// ID de guild.
        /// </summary>
        public int GuildID { get; set; }

        /// <summary>
        /// IP de usuário.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ID de personagem.
        /// </summary>
        public int CharacterID { get; set; }

        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string CharacterName { get; set; }

        /// <summary>
        /// Slot de personagem.
        /// </summary>
        public int CharSlot { get; set; }

        /// <summary>
        /// ID de mundo / mapa.
        /// </summary>
        public int WorldID { get; set; }

        /// <summary>
        /// ID de região.
        /// </summary>
        public int RegionID { get; set; }
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        /// <param name="ip"></param>
        public PlayerData(NetConnection connection, string hexID, string ip) {
            Connection = connection;
            HexID = hexID;
            IP = ip;
            Account = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            AccountID = 0;
            Account = IP = string.Empty;
        }
    }
}
