using System;
using System.Collections.Generic;

namespace GameServer.Npcs { 
    public class NpcData : ICloneable {

        public int ID { get; set; }
        public int Type { get; set; }
        public int Sprite { get; set; }
        public int Elit { get; set; }
        public int Experience { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int RegenHP { get; set; }
        public int Level { get; set; }
        public int AttackSpeed { get; set; }
        public int Attack { get; set; }
        public int Accuracy { get; set; }
        public int Defense { get; set; }
        public int Evasion { get; set; }
        public int Block { get; set; }
        public int Parry { get; set; }
        public int CriticalRate { get; set; }
        public int CriticalDamage { get; set; }
        public int MagicAttack { get; set; }
        public int MagicAccuracy { get; set; }
        public int MagicDefense { get; set; }
        public int MagicResist { get; set; }
        public int AttributeFire { get; set; }
        public int AttributeWater { get; set; }
        public int AttributeEarth { get; set; }
        public int AttributeWind { get; set; }
        public int ResistStun { get; set; }
        public int ResistParalysis { get; set; }
        public int ResistSilence { get; set; }
        public int ResistBlind { get; set; }
        public int ResistCriticalRate { get; set; }
        public int ResistCriticalDamage { get; set; }
        public int ResistMagicCriticalRate { get; set; }
        public int ResistMagicCriticalDamage { get; set; }
        public int RangeX { get; set; }
        public int RangeY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public object Clone() {
            return this.MemberwiseClone();
        }    
    }
}
