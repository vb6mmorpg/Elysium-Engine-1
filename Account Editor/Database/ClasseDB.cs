
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AccountEditor.Database {
    public class ClasseDB {
        /// <summary>
        /// Carrega as informações de classes.
        /// </summary>
        /// <returns></returns>
        public static List<Classe> LoadClasseData() {
            var varQuery = "SELECT * FROM classes";
            var cmd = new MySqlCommand(varQuery, MySQL.GameDB.Connection);
            var reader = cmd.ExecuteReader();
            var item = new Classe();
            var list = new List<Classe>();

            while (reader.Read()) {
                item.ID = (int)reader["id"];
                item.Name = (string)reader["name"];
                item.Level = (int)reader["level"];
                item.Strenght = (int)reader["strenght"];
                item.Dexterity = (int)reader["dexterity"];
                item.Agility = (int)reader["agility"];
                item.Constitution = (int)reader["constitution"];
                item.Intelligence = (int)reader["intelligence"];
                item.Wisdom = (int)reader["wisdom"];
                item.Will = (int)reader["will"];
                item.Mind = (int)reader["mind"];
                item.Charisma = (int)reader["charisma"];
                item.Points = (int)reader["points"];

                list.Add(item);
            }

            reader.Close();

            return list;
        }
    }
}
