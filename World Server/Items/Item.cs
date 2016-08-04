namespace WorldServer.Items {
    public class Item {
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID serial.
        /// </summary>
        public string UniqueID { get; set; }

        /// <summary>
        /// Quantidade.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Nivel de encantamento.
        /// </summary>
        public int Enchant { get; set; }

        /// <summary>
        /// ID de elemento
        /// </summary>
        public int Element { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        public int Durability { get; set; }

        /// <summary>
        /// ID de socket.
        /// </summary>
        public string Slots { get; set; }

        /// <summary>
        /// Tempo limite
        /// </summary>
        public string ExpireTime { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        public byte IsSoulBound { get; set; }
    }
}
