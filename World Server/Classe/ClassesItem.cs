using WorldServer.Items;
using WorldServer.Common;

namespace WorldServer.Classe  {
    public class ClassesItem {
        //15 = max item
        public Item[] Equipped { get; set; } = new Item[Constant.MAX_ITEM];

        /// <summary>
        /// Construtor
        /// </summary>
        public ClassesItem() {
            //15 = max_item
            for(var index = 0; index < Constant.MAX_ITEM; index++) {
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
