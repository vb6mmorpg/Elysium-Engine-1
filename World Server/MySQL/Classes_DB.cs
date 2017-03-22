using System;
using MySql.Data.MySqlClient;
using WorldServer.Items;
using WorldServer.Server;

namespace WorldServer.MySQL {
    public class Classes_DB {

        /// <summary>
        /// Carrega os items iniciais de cada classe
        /// </summary>
        public static void GetClasseItem(int index, int classeID) {
            var query = "SELECT * FROM classes_item WHERE classe_id=?classeID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?classeID", classeID);
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
                _base.Level = (int)reader["level"];
               // _base.SpriteFemale = Convert.ToInt16(reader["sprite_female"]);
               // _base.SpriteMale = Convert.ToInt16(reader["sprite_male"]);
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
    }
}
