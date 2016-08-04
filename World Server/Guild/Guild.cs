using System.Collections.Generic;
using System.Linq;

namespace WorldServer.GameGuild {
    public partial class Guild {
        public HashSet<GuildMember> Member { get; set; }

        /// <summary>
        /// Número de identificação
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de dono.
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Nome de guild.
        /// </summary>
        public string Name { get; set; }

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
                var count = 0;
                foreach (var mData in Member) { if (mData.Status) { count++; } }

                return count;
            }
        }

        /// <summary>
        /// x
        /// </summary>
        public Guild() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public Guild(bool instance) {
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
