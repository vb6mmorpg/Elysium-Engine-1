using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Classe_Editor {
    public class MySQL {
        public static MySqlConnection Connection { get; set; } = null;      
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }

        /// <summary>
        /// Realiza a conexão com o banco de dados.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool Connect(out string error) {
            var varQuery = "Server=" + Server + ";";
            varQuery += "Port=" + Port + ";";
            varQuery += "Database=" + Database + ";";
            varQuery += "User ID=" + Username + ";";
            varQuery += "Password=" + Password + ";";

            try {
                Connection = new MySqlConnection();
                Connection.ConnectionString = varQuery;
                Connection.Open();
            }
            catch (MySqlException ex) {
                error = ex.Message;
                return false;
            }
            finally {
                varQuery = string.Empty;
            }

            error = string.Empty;
            return true;
        }

        /// <summary>
        /// Desconexão com a DB.
        /// </summary>
        /// <returns></returns>
        public static bool Disconnect() {
            if (Connection.State != ConnectionState.Closed) {
                Connection.Close();
                Connection.Dispose();
            }

            if (Connection.State == ConnectionState.Closed)
                return true;
            else
                return false;
        }

        #region Classe Base
        /// <summary>
        /// Obtem as informações iniciais de classe base.
        /// </summary>
        public static List<ClasseData> InitialClasseBase() {
            var varQuery = "SELECT id, name FROM classes";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            var listData = new List<ClasseData>();
            var id = 0;

            while (reader.Read()) {
                id = Convert.ToInt32(reader["id"]);
                listData.Add(new ClasseData(id, id + ": " + (string)reader["name"]));
            }

            reader.Close();
            return listData;
        }

        /// <summary>
        /// Verifica se algum ID existe no banco.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool ExistClasseID(int index) {
            var varQuery = "SELECT id FROM classes WHERE id='" + index + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == true) {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;
        }

        /// <summary>
        /// Obtém todas as informação de uma classe.
        /// </summary>
        /// <param name="index"></param>
        public static void GetClasseBase(int index) {
            var varQuery = "SELECT * FROM classes WHERE id='" + Static.ListClasseBase[index] + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            Static.Classes.ID = (int)reader["id"]; 
            Static.Classes.ClasseIncrementID = (int)reader["increment_id"];
            Static.Classes.ClasseName = (string)reader["name"];
            Static.Classes.SetBaseStat(Stat.MaxHP, (int)reader["hp"]);
            Static.Classes.SetBaseStat(Stat.MaxMP, (int)reader["mp"]);
            Static.Classes.SetBaseStat(Stat.MaxSP, (int)reader["sp"]);
            Static.Classes.SetBaseStat(Stat.RegenHP, (int)reader["regen_hp"]);
            Static.Classes.SetBaseStat(Stat.RegenMP, (int)reader["regen_mp"]);
            Static.Classes.SetBaseStat(Stat.RegenSP, (int)reader["regen_sp"]);
            Static.Classes.SpriteFemale =  Convert.ToInt16(reader["sprite_female"]);
            Static.Classes.SpriteMale = Convert.ToInt16(reader["sprite_male"]);
            Static.Classes.SetBaseStat(Stat.Level, (int)reader["level"]);
            Static.Classes.SetBaseStat(Stat.Strenght, (int)reader["strenght"]);
            Static.Classes.SetBaseStat(Stat.Dexterity, (int)reader["dexterity"]);
            Static.Classes.SetBaseStat(Stat.Agility, (int)reader["agility"]);
            Static.Classes.SetBaseStat(Stat.Constitution, (int)reader["constitution"]);
            Static.Classes.SetBaseStat(Stat.Intelligence, (int)reader["intelligence"]);
            Static.Classes.SetBaseStat(Stat.Wisdom, (int)reader["wisdom"]);
            Static.Classes.SetBaseStat(Stat.Will, (int)reader["will"]);
            Static.Classes.SetBaseStat(Stat.Mind, (int)reader["mind"]);
            Static.Classes.SetBaseStat(Stat.Charisma, (int)reader["charisma"]);
            Static.Classes.SetBaseStat(Stat.Point, (int)reader["points"]);
            Static.Classes.SetBaseStat(Stat.CriticalRate, (int)reader["critical_rate"]);
            Static.Classes.SetBaseStat(Stat.CriticalDamage, (int)reader["critical_damage"]);
            Static.Classes.SetBaseStat(Stat.MagicCriticalRate, (int)reader["magic_critical_rate"]);
            Static.Classes.SetBaseStat(Stat.MagicCriticalDamage, (int)reader["magic_critical_damage"]);
            Static.Classes.SetBaseStat(Stat.HealingPower, (int)reader["healing_power"]);
            Static.Classes.SetBaseStat(Stat.Concentration, (int)reader["concentration"]);
            Static.Classes.SetBaseStat(Stat.Attack, (int)reader["attack"]);
            Static.Classes.SetBaseStat(Stat.Accuracy, (int)reader["accuracy"]);
            Static.Classes.SetBaseStat(Stat.Defense, (int)reader["defense"]);
            Static.Classes.SetBaseStat(Stat.Evasion, (int)reader["evasion"]);
            Static.Classes.SetBaseStat(Stat.Block, (int)reader["block"]);
            Static.Classes.SetBaseStat(Stat.Parry, (int)reader["parry"]);
            Static.Classes.SetBaseStat(Stat.MagicAttack, (int)reader["magic_attack"]);
            Static.Classes.SetBaseStat(Stat.MagicAccuracy, (int)reader["magic_accuracy"]);
            Static.Classes.SetBaseStat(Stat.MagicDefense, (int)reader["magic_defense"]);
            Static.Classes.SetBaseStat(Stat.MagicResist, (int)reader["magic_resist"]);
            Static.Classes.SetBaseStat(Stat.DamageSuppression, (int)reader["damage_suppression"]);
            Static.Classes.SetBaseStat(Stat.AdditionalDamage, (int)reader["additional_damage"]);
            Static.Classes.SetBaseStat(Stat.Enmity, (int)reader["enmity"]);
            Static.Classes.SetBaseStat(Stat.AttackSpeed, (int)reader["attack_speed"]);
            Static.Classes.SetBaseStat(Stat.CastSpeed, (int)reader["cast_speed"]);
            Static.Classes.SetBaseStat(Stat.AttributeFire, (int)reader["attribute_fire"]);
            Static.Classes.SetBaseStat(Stat.AttributeWater, (int)reader["attribute_water"]);
            Static.Classes.SetBaseStat(Stat.AttributeEarth, (int)reader["attribute_earth"]);
            Static.Classes.SetBaseStat(Stat.AttributeWind, (int)reader["attribute_wind"]);
            Static.Classes.SetBaseStat(Stat.ResistStun, (int)reader["resist_stun"]);
            Static.Classes.SetBaseStat(Stat.ResistSilence, (int)reader["resist_silence"]);
            Static.Classes.SetBaseStat(Stat.ResistParalysis, (int)reader["resist_paralysis"]);
            Static.Classes.SetBaseStat(Stat.ResistBlind, (int)reader["resist_blind"]);
            Static.Classes.SetBaseStat(Stat.ResistCriticalRate, (int)reader["resist_critical_rate"]);
            Static.Classes.SetBaseStat(Stat.ResistCriticalDamage, (int)reader["resist_critical_damage"]);
            Static.Classes.SetBaseStat(Stat.ResistMagicCriticalRate, (int)reader["resist_magic_critical_rate"]);
            Static.Classes.SetBaseStat(Stat.ResistMagicCriticalDamage, (int)reader["resist_magic_critical_damage"]);

            reader.Close();
        }

        /// <summary>
        /// Deleta uma classe.
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteClasseBase(int index) {
            var varQuery = "DELETE FROM classes WHERE id='" + Static.ListClasseBase[index] + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza informação de classe.
        /// </summary>
        /// <param name="index"></param>
        public static void UpdateClasseBase(int index) {
            var varQuery = new StringBuilder();
            varQuery.Append("UPDATE classes SET id='" + Static.Classes.ID + "', ");
            varQuery.Append("increment_id='" + Static.Classes.ClasseIncrementID + "', ");
            varQuery.Append("name='" + Static.Classes.ClasseName + "', ");
//            varQuery.Append("gender='" + Static.Classes.Gender + "', ");
            varQuery.Append("sprite_female='" + Static.Classes.SpriteFemale + "', ");
            varQuery.Append("sprite_male='" + Static.Classes.SpriteMale + "', ");
            varQuery.Append("level='" + Static.Classes.GetBaseStat(Stat.Level) + "', ");
            varQuery.Append("hp='" + Static.Classes.GetBaseStat(Stat.MaxHP) + "', ");
            varQuery.Append("mp='" + Static.Classes.GetBaseStat(Stat.MaxMP) + "', ");
            varQuery.Append("sp='" + Static.Classes.GetBaseStat(Stat.MaxSP) + "', ");
            varQuery.Append("regen_hp='" + Static.Classes.GetBaseStat(Stat.RegenHP) + "', ");
            varQuery.Append("regen_mp='" + Static.Classes.GetBaseStat(Stat.RegenMP) + "', ");
            varQuery.Append("regen_sp='" + Static.Classes.GetBaseStat(Stat.RegenSP) + "', ");
            varQuery.Append("strenght='" + Static.Classes.GetBaseStat(Stat.Strenght) + "', ");
            varQuery.Append("dexterity='" + Static.Classes.GetBaseStat(Stat.Dexterity) + "', ");
            varQuery.Append("agility='" + Static.Classes.GetBaseStat(Stat.Agility) + "', ");
            varQuery.Append("constitution='" + Static.Classes.GetBaseStat(Stat.Constitution) + "', ");
            varQuery.Append("intelligence='" + Static.Classes.GetBaseStat(Stat.Intelligence) + "', ");
            varQuery.Append("wisdom='" + Static.Classes.GetBaseStat(Stat.Wisdom) + "', ");
            varQuery.Append("will='" + Static.Classes.GetBaseStat(Stat.Will) + "', ");
            varQuery.Append("mind='" + Static.Classes.GetBaseStat(Stat.Mind) + "', ");
            varQuery.Append("charisma='" + Static.Classes.GetBaseStat(Stat.Charisma) + "', ");
            varQuery.Append("points='" + Static.Classes.GetBaseStat(Stat.Point) + "', ");
            varQuery.Append("critical_rate='" + Static.Classes.GetBaseStat(Stat.CriticalRate) + "', ");
            varQuery.Append("critical_damage='" + Static.Classes.GetBaseStat(Stat.CriticalDamage) + "', ");
            varQuery.Append("magic_critical_rate='" + Static.Classes.GetBaseStat(Stat.MagicCriticalRate) + "', ");
            varQuery.Append("magic_critical_damage='" + Static.Classes.GetBaseStat(Stat.MagicCriticalDamage) + "', ");
            varQuery.Append("healing_power='" + Static.Classes.GetBaseStat(Stat.HealingPower) + "', ");
            varQuery.Append("concentration='" + Static.Classes.GetBaseStat(Stat.Concentration) + "', ");
            varQuery.Append("attack='" + Static.Classes.GetBaseStat(Stat.Attack) + "', ");
            varQuery.Append("accuracy='" + Static.Classes.GetBaseStat(Stat.Accuracy) + "', ");
            varQuery.Append("defense='" + Static.Classes.GetBaseStat(Stat.Defense) + "', ");
            varQuery.Append("evasion='" + Static.Classes.GetBaseStat(Stat.Evasion) + "', ");
            varQuery.Append("block='" + Static.Classes.GetBaseStat(Stat.Block) + "', ");
            varQuery.Append("parry='" + Static.Classes.GetBaseStat(Stat.Parry) + "', ");
            varQuery.Append("magic_attack='" + Static.Classes.GetBaseStat(Stat.MagicAttack) + "', ");
            varQuery.Append("magic_accuracy='" + Static.Classes.GetBaseStat(Stat.MagicAccuracy) + "', ");
            varQuery.Append("magic_defense='" + Static.Classes.GetBaseStat(Stat.MagicDefense) + "', ");
            varQuery.Append("magic_resist='" + Static.Classes.GetBaseStat(Stat.MagicResist) + "', ");
            varQuery.Append("damage_suppression='" + Static.Classes.GetBaseStat(Stat.DamageSuppression) + "', ");
            varQuery.Append("additional_damage='" + Static.Classes.GetBaseStat(Stat.AdditionalDamage) + "', ");
            varQuery.Append("enmity='" + Static.Classes.GetBaseStat(Stat.Enmity) + "', ");
            varQuery.Append("attack_speed='" + Static.Classes.GetBaseStat(Stat.AttackSpeed) + "', ");
            varQuery.Append("cast_speed='" + Static.Classes.GetBaseStat(Stat.CastSpeed) + "', ");
            varQuery.Append("attribute_fire='" + Static.Classes.GetBaseStat(Stat.AttributeFire) + "', ");
            varQuery.Append("attribute_water='" + Static.Classes.GetBaseStat(Stat.AttributeWater) + "', ");
            varQuery.Append("attribute_earth='" + Static.Classes.GetBaseStat(Stat.AttributeEarth) + "', ");
            varQuery.Append("attribute_wind='" + Static.Classes.GetBaseStat(Stat.AttributeWind) + "', ");
            varQuery.Append("resist_stun='" + Static.Classes.GetBaseStat(Stat.ResistStun) + "', ");
            varQuery.Append("resist_silence='" + Static.Classes.GetBaseStat(Stat.ResistSilence) + "', ");
            varQuery.Append("resist_paralysis='" + Static.Classes.GetBaseStat(Stat.ResistParalysis) + "', ");
            varQuery.Append("resist_blind='" + Static.Classes.GetBaseStat(Stat.ResistBlind) + "', ");
            varQuery.Append("resist_critical_rate='" + Static.Classes.GetBaseStat(Stat.ResistCriticalRate) + "', ");
            varQuery.Append("resist_critical_damage='" + Static.Classes.GetBaseStat(Stat.ResistCriticalDamage) + "', ");
            varQuery.Append("resist_magic_critical_rate='" + Static.Classes.GetBaseStat(Stat.ResistMagicCriticalRate) + "', ");
            varQuery.Append("resist_magic_critical_damage='" + Static.Classes.GetBaseStat(Stat.ResistMagicCriticalDamage) + "' ");
            varQuery.Append("WHERE id='" + Static.ListClasseBase[index] + "'");

            var cmd = new MySqlCommand(varQuery.ToString(), Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Insere uma nova classe ao banco.
        /// </summary>
        public static void InsertClasseBase() {
            var varQuery = new StringBuilder();
            varQuery.Append("INSERT INTO classes (id, increment_id, name, ");
            varQuery.Append("sprite_female, sprite_male, ");
            varQuery.Append("level, hp, mp, sp, regen_hp, regen_mp, regen_sp, ");
            varQuery.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, points, ");
            varQuery.Append("critical_rate, critical_damage, ");
            varQuery.Append("magic_critical_rate, magic_critical_damage, ");
            varQuery.Append("healing_power, concentration, ");
            varQuery.Append("attack, accuracy, defense, evasion, block, parry, ");
            varQuery.Append("magic_attack, magic_accuracy, magic_defense, magic_resist, ");
            varQuery.Append("damage_suppression, additional_damage, enmity, ");
            varQuery.Append("attack_speed, cast_speed, ");
            varQuery.Append("attribute_fire, attribute_water, attribute_earth, attribute_wind, ");
            varQuery.Append("resist_stun, resist_silence, resist_paralysis, resist_blind, ");
            varQuery.Append("resist_critical_rate, resist_critical_damage, resist_magic_critical_rate, resist_magic_critical_damage) ");
            varQuery.Append("VALUES ('" + Static.Classes.ID + "', '");
            varQuery.Append(Static.Classes.ClasseIncrementID + "', '");
            varQuery.Append(Static.Classes.ClasseName + "', '");
            varQuery.Append(Static.Classes.SpriteFemale + "', '");
            varQuery.Append(Static.Classes.SpriteMale + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Level) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MaxHP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MaxMP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MaxSP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.RegenHP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.RegenMP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.RegenSP) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Strenght) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Dexterity) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Agility) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Constitution) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Intelligence) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Wisdom) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Will) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Mind) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Charisma) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Point) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.CriticalRate) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.CriticalDamage) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicCriticalRate) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicCriticalDamage) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.HealingPower) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Concentration) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Attack) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Accuracy) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Defense) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Evasion) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Block) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Parry) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicAttack) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicAccuracy) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicDefense) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.MagicResist) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.DamageSuppression) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AdditionalDamage) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.Enmity) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AttackSpeed) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.CastSpeed) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AttributeFire) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AttributeWater) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AttributeEarth) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.AttributeWind) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistStun) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistSilence) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistParalysis) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistBlind) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistCriticalRate) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistCriticalDamage) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistMagicCriticalRate) + "', '");
            varQuery.Append(Static.Classes.GetBaseStat(Stat.ResistMagicCriticalDamage) + "')");

            var cmd = new MySqlCommand(varQuery.ToString(), Connection);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region Classe Increment
        /// <summary>
        /// Verifica se algum ID existe no banco.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool ExistIncrementID(int index) {
            var varQuery = "SELECT id FROM classes_increment WHERE id='" + index + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == true) {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;
        }

        /// <summary>
        /// Obtem as informações iniciais de incremento de classe.
        /// </summary>
        /// <returns></returns>
        public static List<ClasseData> InitialClasseIncrement() {
            var varQuery = "SELECT id, name FROM classes_increment";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            var listData = new List<ClasseData>();
            var id = 0;

            while (reader.Read()) {
                id = Convert.ToInt32(reader["id"]);
                listData.Add(new ClasseData(id, id + ": " + (string)reader["name"]));
            }

            reader.Close();
            return listData;
        }

        /// <summary>
        /// Obtem as informações iniciais de classe increment.
        /// </summary>
        /// <param name="index"></param>
        public static void GetClasseIncrement(int index) {
            var varQuery = "SELECT * FROM classes_increment WHERE id='" + Static.ListClasseIncrement[index] + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            Static.Classes.IncrementID = (int)reader["id"];
            Static.Classes.IncrementName = (string)reader["name"];

            ParseData(Stat.MaxHP, (string)reader["hp"]);
            ParseData(Stat.MaxMP, (string)reader["mp"]);
            ParseData(Stat.MaxSP, (string)reader["sp"]);
            ParseData(Stat.RegenHP, (string)reader["regen_hp"]);
            ParseData(Stat.RegenMP, (string)reader["regen_mp"]);
            ParseData(Stat.RegenSP, (string)reader["regen_sp"]);
            Static.Classes.SetIncrementStat(Stat.Strenght, (int)reader["strenght"]);
            Static.Classes.SetIncrementStat(Stat.Dexterity, (int)reader["dexterity"]);
            Static.Classes.SetIncrementStat(Stat.Agility, (int)reader["agility"]);
            Static.Classes.SetIncrementStat(Stat.Constitution, (int)reader["constitution"]);
            Static.Classes.SetIncrementStat(Stat.Intelligence, (int)reader["intelligence"]);
            Static.Classes.SetIncrementStat(Stat.Wisdom, (int)reader["wisdom"]);
            Static.Classes.SetIncrementStat(Stat.Will, (int)reader["will"]);
            Static.Classes.SetIncrementStat(Stat.Mind, (int)reader["mind"]);
            Static.Classes.SetIncrementStat(Stat.Charisma, (int)reader["charisma"]);
            Static.Classes.SetIncrementStat(Stat.Point, (int)reader["points"]);
            ParseData(Stat.CriticalRate, (string)reader["critical_rate"]);
            ParseData(Stat.CriticalDamage, (string)reader["critical_damage"]);
            ParseData(Stat.MagicCriticalRate, (string)reader["magic_critical_rate"]);
            ParseData(Stat.MagicCriticalDamage, (string)reader["magic_critical_damage"]);
            ParseData(Stat.HealingPower, (string)reader["healing_power"]);
            ParseData(Stat.Concentration, (string)reader["concentration"]);
            ParseData(Stat.Attack, (string)reader["attack"]);
            ParseData(Stat.Accuracy, (string)reader["accuracy"]);
            ParseData(Stat.Defense, (string)reader["defense"]);
            ParseData(Stat.Evasion, (string)reader["evasion"]);
            ParseData(Stat.Block, (string)reader["block"]);
            ParseData(Stat.Parry, (string)reader["parry"]);
            ParseData(Stat.MagicAttack, (string)reader["magic_attack"]);
            ParseData(Stat.MagicAccuracy, (string)reader["magic_accuracy"]);
            ParseData(Stat.MagicDefense, (string)reader["magic_defense"]);
            ParseData(Stat.MagicResist, (string)reader["magic_resist"]);
            ParseData(Stat.DamageSuppression, (string)reader["damage_suppression"]);
            ParseData(Stat.AdditionalDamage, (string)reader["additional_damage"]);
            ParseData(Stat.Enmity, (string)reader["enmity"]);
            ParseData(Stat.AttackSpeed, (string)reader["attack_speed"]);
            ParseData(Stat.CastSpeed, (string)reader["cast_speed"]);
            ParseData(Stat.AttributeFire, (string)reader["attribute_fire"]);
            ParseData(Stat.AttributeWater, (string)reader["attribute_water"]);
            ParseData(Stat.AttributeEarth, (string)reader["attribute_earth"]);
            ParseData(Stat.AttributeWind, (string)reader["attribute_wind"]);
            ParseData(Stat.ResistStun, (string)reader["resist_stun"]);
            ParseData(Stat.ResistSilence, (string)reader["resist_silence"]);
            ParseData(Stat.ResistParalysis, (string)reader["resist_paralysis"]);
            ParseData(Stat.ResistBlind, (string)reader["resist_blind"]);
            ParseData(Stat.ResistCriticalRate, (string)reader["resist_critical_rate"]);
            ParseData(Stat.ResistCriticalDamage, (string)reader["resist_critical_damage"]);
            ParseData(Stat.ResistMagicCriticalRate, (string)reader["resist_magic_critical_rate"]);
            ParseData(Stat.ResistMagicCriticalDamage, (string)reader["resist_magic_critical_damage"]);

            reader.Close();
        }

        /// <summary>
        /// Deleta um incremento.
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteClasseIncrement(int index) {
            var varQuery = "DELETE FROM classes_increment WHERE id='" + Static.ListClasseIncrement[index] + "'";
            var cmd = new MySqlCommand(varQuery, Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza informação de incremento.
        /// </summary>
        /// <param name="index"></param>
        public static void UpdateClasseIncrement(int index) {
            var varQuery = new StringBuilder();
            varQuery.Append("UPDATE classes_increment SET id='" + Static.Classes.IncrementID + "', ");
            varQuery.Append("name='" + Static.Classes.IncrementName + "', ");
            varQuery.Append("hp='" + MakeData(Stat.MaxHP) + "', ");
            varQuery.Append("mp='" + MakeData(Stat.MaxMP) + "', ");
            varQuery.Append("sp='" + MakeData(Stat.MaxSP) + "', ");
            varQuery.Append("regen_hp='" + MakeData(Stat.RegenHP) + "', ");
            varQuery.Append("regen_mp='" + MakeData(Stat.RegenMP) + "', ");
            varQuery.Append("regen_sp='" + MakeData(Stat.RegenSP) + "', ");
            varQuery.Append("strenght='" + Static.Classes.GetIncrementStat(Stat.Strenght) + "', ");
            varQuery.Append("dexterity='" + Static.Classes.GetIncrementStat(Stat.Dexterity) + "', ");
            varQuery.Append("agility='" + Static.Classes.GetIncrementStat(Stat.Agility) + "', ");
            varQuery.Append("constitution='" + Static.Classes.GetIncrementStat(Stat.Constitution) + "', ");
            varQuery.Append("intelligence='" + Static.Classes.GetIncrementStat(Stat.Intelligence) + "', ");
            varQuery.Append("wisdom='" + Static.Classes.GetIncrementStat(Stat.Wisdom) + "', ");
            varQuery.Append("will='" + Static.Classes.GetIncrementStat(Stat.Will) + "', ");
            varQuery.Append("mind='" + Static.Classes.GetIncrementStat(Stat.Mind) + "', ");
            varQuery.Append("charisma='" + Static.Classes.GetIncrementStat(Stat.Charisma) + "', ");
            varQuery.Append("points='" + Static.Classes.GetIncrementStat(Stat.Point) + "', ");
            varQuery.Append("critical_rate='" + MakeData(Stat.CriticalRate) + "', ");
            varQuery.Append("critical_damage='" + MakeData(Stat.CriticalDamage) + "', ");
            varQuery.Append("magic_critical_rate='" + MakeData(Stat.MagicCriticalRate) + "', ");
            varQuery.Append("magic_critical_damage='" + MakeData(Stat.MagicCriticalDamage) + "', ");
            varQuery.Append("healing_power='" + MakeData(Stat.HealingPower) + "', ");
            varQuery.Append("concentration='" + MakeData(Stat.Concentration) + "', ");
            varQuery.Append("attack='" + MakeData(Stat.Attack) + "', ");
            varQuery.Append("accuracy='" + MakeData(Stat.Accuracy) + "', ");
            varQuery.Append("defense='" + MakeData(Stat.Defense) + "', ");
            varQuery.Append("evasion='" + MakeData(Stat.Evasion) + "', ");
            varQuery.Append("block='" + MakeData(Stat.Block) + "', ");
            varQuery.Append("parry='" + MakeData(Stat.Parry) + "', ");
            varQuery.Append("magic_attack='" + MakeData(Stat.MagicAttack) + "', ");
            varQuery.Append("magic_accuracy='" + MakeData(Stat.MagicAccuracy) + "', ");
            varQuery.Append("magic_defense='" + MakeData(Stat.MagicDefense) + "', ");
            varQuery.Append("magic_resist='" + MakeData(Stat.MagicResist) + "', ");
            varQuery.Append("damage_suppression='" + MakeData(Stat.DamageSuppression) + "', ");
            varQuery.Append("additional_damage='" + MakeData(Stat.AdditionalDamage) + "', ");
            varQuery.Append("enmity='" + MakeData(Stat.Enmity) + "', ");
            varQuery.Append("attack_speed='" + MakeData(Stat.AttackSpeed) + "', ");
            varQuery.Append("cast_speed='" + MakeData(Stat.CastSpeed) + "', ");
            varQuery.Append("attribute_fire='" + MakeData(Stat.AttributeFire) + "', ");
            varQuery.Append("attribute_water='" + MakeData(Stat.AttributeWater) + "', ");
            varQuery.Append("attribute_earth='" + MakeData(Stat.AttributeEarth) + "', ");
            varQuery.Append("attribute_wind='" + MakeData(Stat.AttributeWind) + "', ");
            varQuery.Append("resist_stun='" + MakeData(Stat.ResistStun) + "', ");
            varQuery.Append("resist_silence='" + MakeData(Stat.ResistSilence) + "', ");
            varQuery.Append("resist_paralysis='" + MakeData(Stat.ResistParalysis) + "', ");
            varQuery.Append("resist_blind='" + MakeData(Stat.ResistBlind) + "', ");
            varQuery.Append("resist_critical_rate='" + MakeData(Stat.ResistCriticalRate) + "', ");
            varQuery.Append("resist_critical_damage='" + MakeData(Stat.ResistCriticalDamage) + "', ");
            varQuery.Append("resist_magic_critical_rate='" + MakeData(Stat.ResistMagicCriticalRate) + "', ");
            varQuery.Append("resist_magic_critical_damage='" + MakeData(Stat.ResistMagicCriticalDamage) + "' ");
            varQuery.Append("WHERE id='" + Static.ListClasseIncrement[index] + "'");

            var cmd = new MySqlCommand(varQuery.ToString(), Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Insere um novo incremento ao banco.
        /// </summary>
        public static void InsertClasseIncrement() {
            var varQuery = new StringBuilder();
            varQuery.Append("INSERT INTO classes_increment (id, name, ");
            varQuery.Append("hp, mp, sp, regen_hp, regen_mp, regen_sp, ");
            varQuery.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, points, ");
            varQuery.Append("critical_rate, critical_damage, ");
            varQuery.Append("magic_critical_rate, magic_critical_damage, ");
            varQuery.Append("healing_power, concentration, ");
            varQuery.Append("attack, accuracy, defense, evasion, block, parry, ");
            varQuery.Append("magic_attack, magic_accuracy, magic_defense, magic_resist, ");
            varQuery.Append("damage_suppression, additional_damage, enmity, ");
            varQuery.Append("attack_speed, cast_speed, ");
            varQuery.Append("attribute_fire, attribute_water, attribute_earth, attribute_wind, ");
            varQuery.Append("resist_stun, resist_silence, resist_paralysis, resist_blind, ");
            varQuery.Append("resist_critical_rate, resist_critical_damage, resist_magic_critical_rate, resist_magic_critical_damage) ");
            varQuery.Append("VALUES ('" + Static.Classes.IncrementID + "', '");
            varQuery.Append(Static.Classes.IncrementName + "', '");
            varQuery.Append(MakeData(Stat.MaxHP) + "', '");
            varQuery.Append(MakeData(Stat.MaxMP) + "', '");
            varQuery.Append(MakeData(Stat.MaxSP) + "', '");
            varQuery.Append(MakeData(Stat.RegenHP) + "', '");
            varQuery.Append(MakeData(Stat.RegenMP) + "', '");
            varQuery.Append(MakeData(Stat.RegenSP) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Strenght) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Dexterity) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Agility) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Constitution) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Intelligence) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Wisdom) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Will) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Mind) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Charisma) + "', '");
            varQuery.Append(Static.Classes.GetIncrementStat(Stat.Point) + "', '");
            varQuery.Append(MakeData(Stat.CriticalRate) + "', '");
            varQuery.Append(MakeData(Stat.CriticalDamage) + "', '");
            varQuery.Append(MakeData(Stat.MagicCriticalRate) + "', '");
            varQuery.Append(MakeData(Stat.MagicCriticalDamage) + "', '");
            varQuery.Append(MakeData(Stat.HealingPower) + "', '");
            varQuery.Append(MakeData(Stat.Concentration) + "', '");
            varQuery.Append(MakeData(Stat.Attack) + "', '");
            varQuery.Append(MakeData(Stat.Accuracy) + "', '");
            varQuery.Append(MakeData(Stat.Defense) + "', '");
            varQuery.Append(MakeData(Stat.Evasion) + "', '");
            varQuery.Append(MakeData(Stat.Block) + "', '");
            varQuery.Append(MakeData(Stat.Parry) + "', '");
            varQuery.Append(MakeData(Stat.MagicAttack) + "', '");
            varQuery.Append(MakeData(Stat.MagicAccuracy) + "', '");
            varQuery.Append(MakeData(Stat.MagicDefense) + "', '");
            varQuery.Append(MakeData(Stat.MagicResist) + "', '");
            varQuery.Append(MakeData(Stat.DamageSuppression) + "', '");
            varQuery.Append(MakeData(Stat.AdditionalDamage) + "', '");
            varQuery.Append(MakeData(Stat.Enmity) + "', '");
            varQuery.Append(MakeData(Stat.AttackSpeed) + "', '");
            varQuery.Append(MakeData(Stat.CastSpeed) + "', '");
            varQuery.Append(MakeData(Stat.AttributeFire) + "', '");
            varQuery.Append(MakeData(Stat.AttributeWater) + "', '");
            varQuery.Append(MakeData(Stat.AttributeEarth) + "', '");
            varQuery.Append(MakeData(Stat.AttributeWind) + "', '");
            varQuery.Append(MakeData(Stat.ResistStun) + "', '");
            varQuery.Append(MakeData(Stat.ResistSilence) + "', '");
            varQuery.Append(MakeData(Stat.ResistParalysis) + "', '");
            varQuery.Append(MakeData(Stat.ResistBlind) + "', '");
            varQuery.Append(MakeData(Stat.ResistCriticalRate) + "', '");
            varQuery.Append(MakeData(Stat.ResistCriticalDamage) + "', '");
            varQuery.Append(MakeData(Stat.ResistMagicCriticalRate) + "', '");
            varQuery.Append(MakeData(Stat.ResistMagicCriticalDamage) + "')");

            var cmd = new MySqlCommand(varQuery.ToString(), Connection);
            cmd.ExecuteNonQuery();
        }
        #endregion

        /// <summary>
        /// Quebra a string de dados obtida a partir do banco.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        private static void ParseData(Stat type, string data)
        {
            string[] var = data.Split(';');

            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[0]), 0);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[1]), 1);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[2]), 2);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[3]), 3);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[4]), 4);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[5]), 5);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[6]), 6);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[7]), 7);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[8]), 8);
            Static.Classes.SetIncrementStat(type, Convert.ToInt32(var[9]), 9);
        }

        /// <summary>
        /// Cria a string de dados para inserir ao banco.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string MakeData(Stat type)
        {
            StringBuilder result = new StringBuilder();
            result.Append(Static.Classes.GetIncrementStat(type, 0) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 1) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 2) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 3) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 4) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 5) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 6) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 7) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 8) + ";");
            result.Append(Static.Classes.GetIncrementStat(type, 9));
            return result.ToString();
        }
    }
}
