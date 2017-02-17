using Lidgren.Network;
using GameServer.ClasseData;

namespace GameServer.Server {   
    public partial class PlayerData : StatsBase {
        public NetConnection Connection { get; set; }
        public string IP { get; set; }
        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public byte Gender { get; set; }
        public int CharSlot { get; set; }
        public byte LanguageID { get; set; }
        public short AccessLevel { get; set; }
        public string Pin { get; set; }
        public int GuildID { get; set; }
        public string GuildName { get; set; } = string.Empty;
        public int ClasseID { get; set; }
        public short Sprite { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int MaxSP { get; set; }
        public long Exp { get; set; }
        public int WorldID { get; set; }
        public int RegionID { get; set; }
        public short Direction { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public PlayerService Service { get; set; }

        public int BaseStrenght { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseAgility { get; set; }
        public int BaseConstitution { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseWisdom { get; set; }
        public int BaseWill { get; set; }
        public int BaseMind { get; set; }
        public int BaseCharisma { get; set; }

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
            CharacterName = string.Empty;
            Service = new PlayerService();
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
