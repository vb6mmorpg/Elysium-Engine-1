using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldServer.Common {
    public class GameSettings {
        public static bool CharacterCreation { get; set; }
        public static bool CharacterDelete { get; set; }
        public static int CharacterDeleteMinLevel { get; set; }
        public static int CharacterDeleteMaxLevel { get; set; }
    }
}
