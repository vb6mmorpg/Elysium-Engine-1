using WorldServer.Items;

namespace WorldServer.Classe  {
    public class ClassesItem {
        //15 = max item
        public Item[] Equipped { get; set; } = new Item[15];

        /// <summary>
        /// Construtor
        /// </summary>
        public ClassesItem() {
            //15 = max_item
            for(var index = 0; index < 15; index++) {
                Equipped[index] = new Item();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Item GetItem(ItemEnum type) {
            return Equipped[(int)type];
        }
     
    }
}
