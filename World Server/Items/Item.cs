using System;
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
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        public byte IsSoulBound { get; set; }

        /// <summary>
        /// Se o item está no inventário ou não.
        /// </summary>
        public bool IsInInventory { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public Item() {
            this.UniqueID = string.Empty;
            this.Slots = string.Empty;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="item"></param>
        public Item(Item item) {
            this.ID = item.ID;
            this.UniqueID = item.UniqueID;
            this.Quantity = item.Quantity;
            this.Enchant = item.Enchant;
            this.Element = item.Element;
            this.Durability = item.Durability;
            this.Slots = item.Slots;
            this.ExpireTime = item.ExpireTime;
            this.IsSoulBound = item.IsSoulBound;
            this.IsInInventory = item.IsInInventory;
        }
    }
}
