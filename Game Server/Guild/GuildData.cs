namespace GameServer.GameGuild {
    public class GuildData {
        /// <summary>
        /// Limite de level.
        /// </summary>
        public static int MaxLevel { get; set; }

        /// <summary>
        /// Quantida de experiência necessário para o próximo level.
        /// </summary>
        public long Exp { get; set; }

        /// <summary>
        /// Quantidade de pontos necessário para o próximo level.
        /// </summary>
        public long Contribution { get; set; }

        /// <summary>
        /// Quantidade dinheiro necessário para o próximo level.
        /// </summary>
        public long Money { get; set; }

        /// <summary>
        /// Limite de membros em cada level.
        /// </summary>
        public int MaxMember { get; set; }
    }
}
