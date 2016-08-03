using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Common;

namespace GameServer.Classe {
    public class ClassesBase : Stat {
        public int ID { get; set; }
        public int IncrementID { get; set; }
        public int SpriteFemale { get; set; }
        public int SpriteMale { get; set; }
    }
}
