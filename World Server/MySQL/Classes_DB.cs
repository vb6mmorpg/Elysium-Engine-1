using System;
using MySql.Data.MySqlClient;
using WorldServer.Classe;

namespace WorldServer.MySQL {
    public class Classes_DB {

        /// <summary>
        /// Carrega os items iniciais de cada classe
        /// </summary>
        public static void GetClasseItem() {
            var maxClasse = Classes.ClassesBase.Count;
            var varQuery = string.Empty;
            var cmd = new MySqlCommand();
            var list = Classes.ClassesItem;
            var index = 0;
            MySqlDataReader reader;


            for (var classeID = 0; classeID < maxClasse; classeID++) {           
                varQuery = "SELECT * FROM classes_equipped WHERE classe_id ='" + classeID + "'";
                cmd.CommandText = varQuery;
                cmd.Connection = Common_DB.Connection;

                reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    index = (int)reader["inventory_slot"];
                    list[classeID].Equipped[index].ID = (int)reader["item_id"];
                    list[classeID].Equipped[index].UniqueID = (string)reader["item_unique_id"];
                    list[classeID].Equipped[index].Enchant = (int)reader["enchant"];
                    list[classeID].Equipped[index].Element = (int)reader["item_element"];
                    list[classeID].Equipped[index].Durability = (int)reader["durability"];
                    list[classeID].Equipped[index].Slots = (string)reader["slots"];
                    list[classeID].Equipped[index].ExpireTime = (string)reader["expire_time"];
                    list[classeID].Equipped[index].IsSoulBound = Convert.ToByte(reader["is_soul_bound"]);
                }

                reader.Close();
            }
        }

        /// <summary>
        /// Carrega todas as classes.
        /// </summary>
        public static void GetClasseBase() {
            var varQuery = "SELECT * FROM classes";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            var index = 0;
            var list = Classes.ClassesBase;

            while (reader.Read()) {
                // para cada classe encontrada na db, adiciona uma nova lista de item
                Classes.ClassesItem.Add(new ClassesItem());
                list.Add(new ClassesBase());

                list[index].ID = (int)reader["id"];
                list[index].IncrementID = (int)reader["increment_id"];
                list[index].HP = (int)reader["hp"];
                list[index].MP = (int)reader["mp"];
                list[index].SP =(int)reader["sp"];
                list[index].RegenHP = (int)reader["regen_hp"];
                list[index].RegenMP = (int)reader["regen_mp"];
                list[index].RegenSP = (int)reader["regen_sp"];
                list[index].SpriteFemale = (int)reader["sprite_female"];
                list[index].SpriteMale = (int)reader["sprite_male"];
                list[index].Level = (int)reader["level"];
                list[index].Strenght = (int)reader["strenght"];
                list[index].Dexterity = (int)reader["dexterity"];
                list[index].Agility = (int)reader["agility"];
                list[index].Constitution = (int)reader["constitution"];
                list[index].Intelligence = (int)reader["intelligence"];
                list[index].Wisdom = (int)reader["wisdom"];
                list[index].Will = (int)reader["will"];
                list[index].Mind =(int)reader["mind"];
                list[index].Charisma = (int)reader["charisma"];
                list[index].Points = (int)reader["points"];
                list[index].CriticalRate =(int)reader["critical_rate"];
                list[index].CriticalDamage = (int)reader["critical_damage"];
                list[index].SpellCriticalRate = (int)reader["magic_critical_rate"];
                list[index].SpellCriticalDamage = (int)reader["magic_critical_damage"];
                list[index].HealingPower = (int)reader["healing_power"];
                list[index].Concentration = (int)reader["concentration"];
                list[index].Attack = (int)reader["attack"];
                list[index].Accuracy = (int)reader["accuracy"];
                list[index].Defense = (int)reader["defense"];
                list[index].Evasion = (int)reader["evasion"];
                list[index].Block = (int)reader["block"];
                list[index].Parry = (int)reader["parry"];
                list[index].MagicAttack = (int)reader["magic_attack"];
                list[index].MagicAccuracy = (int)reader["magic_accuracy"];
                list[index].MagicDefense = (int)reader["magic_defense"];
                list[index].MagicResist = (int)reader["magic_resist"];
                list[index].DamageSuppression = (int)reader["damage_suppression"];
                list[index].AdditionalDamage = (int)reader["additional_damage"];
                list[index].Enmity = (int)reader["enmity"];
                list[index].AttackSpeed = (int)reader["attack_speed"];
                list[index].CastSpeed = (int)reader["cast_speed"];
                list[index].AttributeFire = (int)reader["attribute_fire"];
                list[index].AttributeWater = (int)reader["attribute_water"];
                list[index].AttributeEarth = (int)reader["attribute_earth"];
                list[index].AttributeWind = (int)reader["attribute_wind"];
                list[index].ResistStun = (int)reader["resist_stun"];
                list[index].ResistSilence = (int)reader["resist_silence"];
                list[index].ResistParalysis = (int)reader["resist_paralysis"];
                list[index].ResistBlind = (int)reader["resist_blind"];
                list[index].ResistCriticalRate = (int)reader["resist_critical_rate"];
                list[index].ResistCriticalDamage = (int)reader["resist_critical_damage"];
                list[index].ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
                list[index].ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];

                index++;
            }

            reader.Close();
        }
       
        /// <summary>
        /// Carrega todos os incrementos de classe.
        /// </summary>
        public static void GetClasseIncrement() {
            var varQuery = "SELECT * FROM classes_increment";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            var index = 0;
            var list = Classes.ClassesIncrement; 
        
            while (reader.Read()) {
                list.Add(new ClassesIncrement());
                list[index].IncrementID = (int)reader["id"];
                list[index].SetIncrementStat(Stats.MaxHP, (string)reader["hp"]);
                list[index].SetIncrementStat(Stats.MaxMP, (string)reader["mp"]);
                list[index].SetIncrementStat(Stats.MaxSP, (string)reader["sp"]);
                list[index].SetIncrementStat(Stats.RegenHP, (string)reader["regen_hp"]);
                list[index].SetIncrementStat(Stats.RegenMP, (string)reader["regen_mp"]);
                list[index].SetIncrementStat(Stats.RegenSP, (string)reader["regen_sp"]);
                list[index].Strenght = (int)reader["strenght"];
                list[index].Dexterity = (int)reader["dexterity"];
                list[index].Agility = (int)reader["agility"];
                list[index].Constitution = (int)reader["constitution"];
                list[index].Intelligence = (int)reader["intelligence"];
                list[index].Wisdom = (int)reader["wisdom"];
                list[index].Will = (int)reader["will"];
                list[index].Mind = (int)reader["mind"];
                list[index].Charisma = (int)reader["charisma"];
                list[index].Points = (int)reader["points"];
                list[index].SetIncrementStat(Stats.CriticalRate, (string)reader["critical_rate"]);
                list[index].SetIncrementStat(Stats.CriticalDamage, (string)reader["critical_damage"]);
                list[index].SetIncrementStat(Stats.MagicCriticalRate, (string)reader["magic_critical_rate"]);
                list[index].SetIncrementStat(Stats.MagicCriticalDamage, (string)reader["magic_critical_damage"]);
                list[index].SetIncrementStat(Stats.HealingPower, (string)reader["healing_power"]);
                list[index].SetIncrementStat(Stats.Concentration, (string)reader["concentration"]);
                list[index].SetIncrementStat(Stats.Attack, (string)reader["attack"]);
                list[index].SetIncrementStat(Stats.Accuracy, (string)reader["accuracy"]);
                list[index].SetIncrementStat(Stats.Defense, (string)reader["defense"]);
                list[index].SetIncrementStat(Stats.Evasion, (string)reader["evasion"]);
                list[index].SetIncrementStat(Stats.Block, (string)reader["block"]);
                list[index].SetIncrementStat(Stats.Parry, (string)reader["parry"]);
                list[index].SetIncrementStat(Stats.MagicAttack, (string)reader["magic_attack"]);
                list[index].SetIncrementStat(Stats.MagicAccuracy, (string)reader["magic_accuracy"]);
                list[index].SetIncrementStat(Stats.MagicDefense, (string)reader["magic_defense"]);
                list[index].SetIncrementStat(Stats.MagicResist, (string)reader["magic_resist"]);
                list[index].SetIncrementStat(Stats.DamageSuppression, (string)reader["damage_suppression"]);
                list[index].SetIncrementStat(Stats.AdditionalDamage, (string)reader["additional_damage"]);
                list[index].SetIncrementStat(Stats.Enmity, (string)reader["enmity"]);
                list[index].SetIncrementStat(Stats.AttackSpeed, (string)reader["attack_speed"]);
                list[index].SetIncrementStat(Stats.CastSpeed, (string)reader["cast_speed"]);
                list[index].SetIncrementStat(Stats.AttributeFire, (string)reader["attribute_fire"]);
                list[index].SetIncrementStat(Stats.AttributeWater, (string)reader["attribute_water"]);
                list[index].SetIncrementStat(Stats.AttributeEarth, (string)reader["attribute_earth"]);
                list[index].SetIncrementStat(Stats.AttributeWind, (string)reader["attribute_wind"]);
                list[index].SetIncrementStat(Stats.ResistStun, (string)reader["resist_stun"]);
                list[index].SetIncrementStat(Stats.ResistSilence, (string)reader["resist_silence"]);
                list[index].SetIncrementStat(Stats.ResistParalysis, (string)reader["resist_paralysis"]);
                list[index].SetIncrementStat(Stats.ResistBlind, (string)reader["resist_blind"]);
                list[index].SetIncrementStat(Stats.ResistCriticalRate, (string)reader["resist_critical_rate"]);
                list[index].SetIncrementStat(Stats.ResistCriticalDamage, (string)reader["resist_critical_damage"]);
                list[index].SetIncrementStat(Stats.ResistMagicCriticalRate, (string)reader["resist_magic_critical_rate"]);
                list[index].SetIncrementStat(Stats.ResistMagicCriticalDamage, (string)reader["resist_magic_critical_damage"]);

                index++;
            }
 
            reader.Close();
        }
    }
}
