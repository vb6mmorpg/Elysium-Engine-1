using System;
using MySql.Data.MySqlClient;

namespace AccountEditor.Database {
    public class CharacterDB {
        public static bool ExistCharacter(string charname) {
            var query = "SELECT id FROM players WHERE name=?charname";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?charname", charname);
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();
            reader.Close();

            return tempvar;
        }

        /// <summary>
        /// Insere um novo personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="pData"></param>
        /// <param name="cData"></param>
        /// <returns></returns>
        public static int InsertCharacter(int accountID, Character pData, Classe cData) {
            var query = "INSERT INTO players (account_id, classe_id, char_slot, name, sprite, ";
            query += "level, strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, statpoints, ";
            query += "world_id, region_id, posx, posy) VALUES (?account, ?classe, ?charslot, ?name, ?sprite, ";
            query += "?level, ?strenght, ?dexterity, ?agility, ?constitution, ?intelligence, ?wisdom, ?will, ?mind, ?charisma, ?points, ";
            query += "?world, ?region, ?x, ?y)";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?account", accountID);
            cmd.Parameters.AddWithValue("?classe", pData.ClasseID);
            cmd.Parameters.AddWithValue("?charslot", pData.CharSlot); 
            cmd.Parameters.AddWithValue("?name", pData.Name);
            cmd.Parameters.AddWithValue("?sprite", pData.Sprite);
            cmd.Parameters.AddWithValue("?level", cData.Level);
            cmd.Parameters.AddWithValue("?strenght", cData.Strenght);
            cmd.Parameters.AddWithValue("?dexterity", cData.Dexterity);
            cmd.Parameters.AddWithValue("?agility", cData.Agility);
            cmd.Parameters.AddWithValue("?constitution", cData.Constitution);
            cmd.Parameters.AddWithValue("?intelligence", cData.Intelligence);
            cmd.Parameters.AddWithValue("?wisdom", cData.Wisdom);
            cmd.Parameters.AddWithValue("?will", cData.Will);
            cmd.Parameters.AddWithValue("?mind", cData.Mind);
            cmd.Parameters.AddWithValue("?charisma", cData.Charisma);
            cmd.Parameters.AddWithValue("?points", cData.Points);
            cmd.Parameters.AddWithValue("?world", pData.WorldID);
            cmd.Parameters.AddWithValue("?region", pData.RegionID);
            cmd.Parameters.AddWithValue("?x", pData.PosX);
            cmd.Parameters.AddWithValue("?y", pData.PosY);
            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public static string[] GetCharacterNames(int accountID) {
            var query = "SELECT char_slot, name FROM players WHERE account_id=?accountid";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?accountid", accountID);
            var reader = cmd.ExecuteReader();

            string[] names = new string[4] { "...", "...", "...", "..." };

            while (reader.Read()) {
                var slot = (int)reader["char_slot"];
                names[slot] = (string)reader["name"];
            }

            reader.Close();

            return names;
        }

        /// <summary>
        /// Carrega as informações dos personagens.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Character LoadCharacterData(string charname) {
            var varQuery = "SELECT * FROM players WHERE name=?charname";
            var cmd = new MySqlCommand(varQuery, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?charname", charname);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return null;
            }

            var pData = new Character();

            pData.ID = (int)reader["id"];
            pData.ClasseID = (int)reader["classe_id"];
            pData.CharSlot = (int)reader["char_slot"];
            pData.Name = (string)reader["name"];
            pData.Sprite = Convert.ToInt16(reader["sprite"]);
            pData.Level = (int)reader["level"];
            pData.Exp = Convert.ToInt64(reader["exp"]);
            pData.Strenght = (int)reader["strenght"];
            pData.Dexterity = (int)reader["dexterity"];
            pData.Agility = (int)reader["agility"];
            pData.Constitution = (int)reader["constitution"];
            pData.Intelligence = (int)reader["intelligence"];
            pData.Wisdom = (int)reader["wisdom"];
            pData.Will = (int)reader["will"];
            pData.Mind = (int)reader["mind"];
            pData.Charisma = (int)reader["charisma"];
            pData.Points = (int)reader["statpoints"];
            pData.WorldID = Convert.ToInt16(reader["world_id"]);
            pData.RegionID = Convert.ToInt16(reader["region_id"]);
            pData.PosX = Convert.ToInt16(reader["posx"]);
            pData.PosY = Convert.ToInt16(reader["posy"]);

            reader.Close();

            return pData;
        }

        /// <summary>
        /// Salva as informaçãoes do personagem.
        /// </summary>
        /// <param name="pData"></param>
        public static int SaveCharacterData(Character pData) {
            var query = "UPDATE players SET classe_id=?classe, name=?name, sprite=?sprite, level=?level, exp=?exp, strenght=?strenght, dexterity=?dexterity, ";
            query += "agility=?agility, constitution=?constitution, intelligence=?intelligence, wisdom=?wisdom, will=?will, mind=?mind, charisma=?charisma, ";
            query += "statpoints=?points, world_id=?world, region_id=?region, posx=?x, posy=?y WHERE id=?id";

            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?classe", pData.ClasseID);
            cmd.Parameters.AddWithValue("?name", pData.Name);
            cmd.Parameters.AddWithValue("?sprite", pData.Sprite);
            cmd.Parameters.AddWithValue("?level", pData.Level);
            cmd.Parameters.AddWithValue("?exp", pData.Exp);
            cmd.Parameters.AddWithValue("?strenght", pData.Strenght);
            cmd.Parameters.AddWithValue("?dexterity", pData.Dexterity);
            cmd.Parameters.AddWithValue("?agility", pData.Agility);
            cmd.Parameters.AddWithValue("?constitution", pData.Constitution);
            cmd.Parameters.AddWithValue("?intelligence", pData.Intelligence);
            cmd.Parameters.AddWithValue("?wisdom", pData.Wisdom);
            cmd.Parameters.AddWithValue("?will", pData.Will);
            cmd.Parameters.AddWithValue("?mind", pData.Mind);
            cmd.Parameters.AddWithValue("?charisma", pData.Charisma);
            cmd.Parameters.AddWithValue("?points", pData.Points);
            cmd.Parameters.AddWithValue("?world", pData.WorldID);
            cmd.Parameters.AddWithValue("?region", pData.RegionID);
            cmd.Parameters.AddWithValue("?x", pData.PosX);
            cmd.Parameters.AddWithValue("?y", pData.PosY);
            cmd.Parameters.AddWithValue("?id", pData.ID);
            var result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Deleta todos os personagens.
        /// </summary>
        /// <param name="accountID"></param>
        public static int DeleteAllCharacter(int accountID) {
            var varQuery = "DELETE FROM players WHERE account_id=?accountid";
            var cmd = new MySqlCommand(varQuery, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?accountid", accountID);
            var result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Deleta um personagem.
        /// </summary>
        /// <param name="charID"></param>
        public static int DeleteCharacter(int charID) {
            var varQuery = "DELETE FROM players WHERE id=?id";
            var cmd = new MySqlCommand(varQuery, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?id", charID);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
