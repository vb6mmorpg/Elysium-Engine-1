namespace GameServer.GameGuild {
    public class GuildMember {
        /// <summary>
        /// ID de personagem.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nível de permissão
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// Introdução.
        /// </summary>
        public string SelfIntro { get; set; }

        /// <summary>
        /// Total de contribuição.
        /// </summary>
        public long Contribution { get; set; }

        /// <summary>
        /// Nível de acesso.
        /// </summary>
        public byte Access { get; set; }

        /// <summary>
        /// Estado do personagem.
        /// </summary>
        public bool Status { get; set; }
    }
}
