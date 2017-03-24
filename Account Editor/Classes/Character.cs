namespace AccountEditor {
    public class Character {
        public int ID { get; set; }
        public int ClasseID { get; set; }
        public int CharSlot { get; set; }
        public string Name { get; set; }
        public short Sprite { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
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
        public short WorldID { get; set; }
        public short RegionID { get; set; }
        public byte Direction { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
