using System.Collections.Generic;
using System.Linq;

namespace GameServer.GameGuild {
    public partial class Guild {

        /// <summary>
        /// Lista de membros.
        /// </summary>
        public HashSet<GuildMember> Member { get; set; }

        /// <summary>
        /// Histórico de alterações.
        /// </summary>
        public HashSet<GuildHistory> History { get; set; }

        /// <summary>
        /// Configuação e informação de level.
        /// </summary>
        public static List<GuildData> Data { get; set; }
        /// <summary>
        /// Número de identificação
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de dono.
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// Nome de personagem de dono.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Nome de guild.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Level de guild.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Experiência de guild.
        /// </summary>
        public long Exp { get; set; }

        /// <summary>
        /// Contribuição
        /// </summary>
        public long Contribution { get; set; }

        /// <summary>
        /// Cache - Ranking.
        /// </summary>
        public int Ranking { get; set; }

        /// <summary>
        /// Anúncio.
        /// </summary>
        public string Announcement { get; set; }

        /// <summary>
        /// Quantidade de membro online.
        /// </summary>
        ///   
        public int OnlineMember {
            get {
                int count = 0;
                foreach (GuildMember mData in Member) { if (mData.Status) { count++; } }

                return count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guild() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public Guild(bool instance) {
            History = new HashSet<GuildHistory>();
            Member = new HashSet<GuildMember>();
        }

        /// <summary>
        /// Realiza uma busca pelo id de personagem.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public GuildMember FindMemberByID(int pID) {
            var find_value = from mData in Member
                             where mData.ID.CompareTo(pID) == 0
                             select mData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de personagem.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public GuildMember FindMemberByName(int pName) {
            var find_value = from mData in Member
                             where mData.Name.CompareTo(pName) == 0
                             select mData;

            return find_value.FirstOrDefault();
        }
    }
}
