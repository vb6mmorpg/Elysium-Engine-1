namespace WorldServer.Server {
    public struct Character {
        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID de classe.
        /// </summary>
        public int Class { get; set; }

        /// <summary>
        /// ID de sprite.
        /// </summary>
        public short Sprite { get; set; }

        /// <summary>
        /// Level de personagem.
        /// </summary>
        public int Level { get; set; }   

        /// <summary>
        /// Limpa todos os dados
        /// </summary>
        public void Clear() {
            Name = string.Empty;
            Class = 0;
            Sprite = 0;
            Level = 0;
        }
    }
}
