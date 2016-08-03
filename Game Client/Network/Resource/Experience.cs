using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.Resource {
    public static class Experience {
        public static List<long> Data { get; set; }

        public static void LoadExperience() {
            var maxLevel = (int)ConfigGet.ConfigGetLong(Settings.GamePath + @"\Data\Experience.txt", "MaxLevel");

            Data = new List<long>();
            Data.Add(0);

            for (var n = 1; n <= maxLevel; n++) {
                Data.Add(ConfigGet.ConfigGetLong(Settings.GamePath + @"\Data\Experience.txt", n + ""));
            }
            
        }
    }
}
