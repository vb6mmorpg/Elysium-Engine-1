using System.Collections.Generic;

namespace Classe_Editor {
    public class Static {
        public static Form1 frmMain;
        public static List<int> ListClasseBase { get; set; } = new List<int>();
        public static List<int> ListClasseIncrement { get; set; } = new List<int>();
        public static List<int> ListRace { get; set; }  = new List<int>();
        public static Classe Classes { get; set; } = new Classe();
    }
}
