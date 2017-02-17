using System;
using MySql.Data.MySqlClient;
using WorldServer.ClasseData;
using WorldServer.Items;

namespace WorldServer.MySQL {
    public class Classes_DB {

        /// <summary>
        /// Carrega os items iniciais de cada classe
        /// </summary>
        public static void GetClasseItem(int index, int classeID) {
            var query = $"SELECT * FROM classes_item WHERE classe_id='{classeID}'";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            Item item;
            int slot;

            while (reader.Read()) {
                slot = (int)reader["slot"];
                item = new Item();
                item.ID = (int)reader["item_id"];
                item.ID = (int)reader["item_id"];
                item.UniqueID = (string)reader["item_unique_id"];
                item.Enchant = (int)reader["enchant"];
                item.Element = (int)reader["item_element"];
                item.Durability = (int)reader["durability"];
                item.Slots = (string)reader["slots"];
                item.ExpireTime = Convert.ToDateTime(reader["expire_time"]);
                item.IsSoulBound = Convert.ToByte(reader["is_soul_bound"]);

                Classe.Classes[index].SetItem((ItemType)slot, item);
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega todas as classes.
        /// </summary>
        public static void GetClasseStatsBase() {
            var varQuery = "SELECT * FROM classes";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();     

            while (reader.Read()) {
                // para cada classe encontrada na db
                Classe.Classes.Add(new Classe());

                var index = Classe.Classes.Count - 1;
                var _base = Classe.Classes[index];

                _base.ID = (int)reader["id"];
                _base.IncrementID = (int)reader["increment_id"];
                _base.HP = (int)reader["hp"];
                _base.MP = (int)reader["mp"];
                _base.SP = (int)reader["sp"];
                _base.Level = (int)reader["level"];
                _base.SpriteFemale = Convert.ToInt16(reader["sprite_female"]);
                _base.SpriteMale = Convert.ToInt16(reader["sprite_male"]);
                _base.Strenght = (int)reader["strenght"];
                _base.Dexterity = (int)reader["dexterity"];
                _base.Agility = (int)reader["agility"];
                _base.Constitution = (int)reader["constitution"];
                _base.Intelligence = (int)reader["intelligence"];
                _base.Wisdom = (int)reader["wisdom"];
                _base.Will = (int)reader["will"];
                _base.Mind = (int)reader["mind"];
                _base.Charisma = (int)reader["charisma"];
                _base.Points = (int)reader["points"];
                index++;
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega todos os incrementos de classe.
        /// </summary>
        public static void GetClasseStatsIncrement(int index, int incrementID) {
            var query = $"SELECT * FROM classes_increment WHERE id='{incrementID}'";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            var _increment = Classe.Classes[index].Increment;

            while (reader.Read()) {
                _increment.IncrementID = (int)reader["id"];
                _increment.SetIncrementStat(StatType.MaxHP, (string)reader["hp"]);
                _increment.SetIncrementStat(StatType.MaxMP, (string)reader["mp"]);
                _increment.SetIncrementStat(StatType.MaxSP, (string)reader["sp"]);
                _increment.SetIncrementStat(StatType.RegenHP, (string)reader["regen_hp"]);
                _increment.SetIncrementStat(StatType.RegenMP, (string)reader["regen_mp"]);
                _increment.SetIncrementStat(StatType.RegenSP, (string)reader["regen_sp"]);
                _increment.Strenght = (int)reader["strenght"];
                _increment.Dexterity = (int)reader["dexterity"];
                _increment.Agility = (int)reader["agility"];
                _increment.Constitution = (int)reader["constitution"];
                _increment.Intelligence = (int)reader["intelligence"];
                _increment.Wisdom = (int)reader["wisdom"];
                _increment.Will = (int)reader["will"];
                _increment.Mind = (int)reader["mind"];
                _increment.Charisma = (int)reader["charisma"];
                _increment.Points = (int)reader["points"];
                _increment.SetIncrementStat(StatType.CriticalRate, (string)reader["critical_rate"]);
                _increment.SetIncrementStat(StatType.CriticalDamage, (string)reader["critical_damage"]);
                _increment.SetIncrementStat(StatType.MagicCriticalRate, (string)reader["magic_critical_rate"]);
                _increment.SetIncrementStat(StatType.MagicCriticalDamage, (string)reader["magic_critical_damage"]);
                _increment.SetIncrementStat(StatType.HealingPower, (string)reader["healing_power"]);
                _increment.SetIncrementStat(StatType.Concentration, (string)reader["concentration"]);
                _increment.SetIncrementStat(StatType.Attack, (string)reader["attack"]);
                _increment.SetIncrementStat(StatType.Accuracy, (string)reader["accuracy"]);
                _increment.SetIncrementStat(StatType.Defense, (string)reader["defense"]);
                _increment.SetIncrementStat(StatType.Evasion, (string)reader["evasion"]);
                _increment.SetIncrementStat(StatType.Block, (string)reader["block"]);
                _increment.SetIncrementStat(StatType.Parry, (string)reader["parry"]);
                _increment.SetIncrementStat(StatType.MagicAttack, (string)reader["magic_attack"]);
                _increment.SetIncrementStat(StatType.MagicAccuracy, (string)reader["magic_accuracy"]);
                _increment.SetIncrementStat(StatType.MagicDefense, (string)reader["magic_defense"]);
                _increment.SetIncrementStat(StatType.MagicResist, (string)reader["magic_resist"]);
                _increment.SetIncrementStat(StatType.DamageSuppression, (string)reader["damage_suppression"]);
                _increment.SetIncrementStat(StatType.AdditionalDamage, (string)reader["additional_damage"]);
                _increment.SetIncrementStat(StatType.Enmity, (string)reader["enmity"]);
                _increment.SetIncrementStat(StatType.AttackSpeed, (string)reader["attack_speed"]);
                _increment.SetIncrementStat(StatType.CastSpeed, (string)reader["cast_speed"]);
                _increment.SetIncrementStat(StatType.AttributeFire, (string)reader["attribute_fire"]);
                _increment.SetIncrementStat(StatType.AttributeWater, (string)reader["attribute_water"]);
                _increment.SetIncrementStat(StatType.AttributeEarth, (string)reader["attribute_earth"]);
                _increment.SetIncrementStat(StatType.AttributeWind, (string)reader["attribute_wind"]);
                _increment.SetIncrementStat(StatType.ResistStun, (string)reader["resist_stun"]);
                _increment.SetIncrementStat(StatType.ResistSilence, (string)reader["resist_silence"]);
                _increment.SetIncrementStat(StatType.ResistParalysis, (string)reader["resist_paralysis"]);
                _increment.SetIncrementStat(StatType.ResistBlind, (string)reader["resist_blind"]);
                _increment.SetIncrementStat(StatType.ResistCriticalRate, (string)reader["resist_critical_rate"]);
                _increment.SetIncrementStat(StatType.ResistCriticalDamage, (string)reader["resist_critical_damage"]);
                _increment.SetIncrementStat(StatType.ResistMagicCriticalRate, (string)reader["resist_magic_critical_rate"]);
                _increment.SetIncrementStat(StatType.ResistMagicCriticalDamage, (string)reader["resist_magic_critical_damage"]);

                index++;
            }

            reader.Close();
        }
    }
}
