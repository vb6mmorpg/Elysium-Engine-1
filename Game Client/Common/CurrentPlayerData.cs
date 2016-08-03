using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium_Diamond.Common {
    public static class CurrentPlayerData {
        public static string Name { get; set; }
        public static string Guild { get; set; }
        public static long Exp { get; set; }
        public static long MaxExp { get; set; }
        public static int Level { get; set; }
        public static int Sprite { get; set; }

        public static int PosX { get; set; }
        public static int PosY { get; set; }

    }
}
