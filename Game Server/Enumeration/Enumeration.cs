using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Common
{
    public enum Direction {
        Up = 1,
        Down = 4,
        Left = 7,
        Right = 10
    }

    
    public enum Stats {
        Strenght,
        Dexterity,
        Agility,
        Vitality,
        Intelligence,
        Wisdom
    }

    public enum Vital {
        HP,
        MP,
        SP
    }
}
