﻿namespace WorldServer.ClasseData {
    public abstract class StatsBase {
        public short SpriteFemale { get; set; }
        public short SpriteMale { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int SP { get; set; }
        public int RegenHP { get; set; }
        public int RegenMP { get; set; }
        public int RegenSP { get; set; }
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Mind { get; set; }
        public int Charisma { get; set; }
        public int Points { get; set; }
        public int DamageSuppression { get; set; }
        public int Enmity { get; set; }
        public int AdditionalDamage { get; set; }
        public int HealingPower { get; set; }
        public int Concentration { get; set; }
        public int AttackSpeed { get; set; }
        public int CastSpeed { get; set; }
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
        public int MagicCriticalRate { get; set; }
        public int MagicCriticalDamage { get; set; }
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
    }
}

