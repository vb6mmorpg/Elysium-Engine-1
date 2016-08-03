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
        public int Sprite { get; set; }

        /// <summary>
        /// Level de personagem.
        /// </summary>
        public int Level { get; set; }   
    }
}
