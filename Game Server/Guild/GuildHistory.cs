namespace GameServer.GameGuild {
    public struct GuildHistory {
        /// <summary>
        /// Data do ocorrido.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Usuário / Personagem 
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
    }
}
