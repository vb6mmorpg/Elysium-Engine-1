using System;
using System.Text;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldServer.Server;

namespace WorldServer.MySQL {
    public class Character_DB {
        /// <summary>
        /// Pega o ID do personagem.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ID(string name) {
            var varQuery = "SELECT id FROM players WHERE name=?name";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?name", name);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return -1;
            }

            var result = (int)reader["id"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Verifica se o nome existe no banco de dados.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Exist(string name) {
            var varQuery = "SELECT id FROM players WHERE name=?name";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?name", name);
            var reader = cmd.ExecuteReader();

            var result = reader.Read();
            reader.Close();

            return result;
        }

        /// <summary>
        /// Retorna o nome do personagem a partir do slot.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static string GetName(int accountID, int charSlot) {
            var varQuery = "SELECT name FROM players WHERE account_id=?accountID and char_slot=?charSlot";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charSlot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return string.Empty;
            }

            var result = (string)reader["name"];

            reader.Close();

            return result;
        }

        /// <summary>
        /// Retorna o level de um personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static int GetLevel(int accountID, int charSlot) {
            var varQuery = "SELECT level FROM players WHERE account_id=?accountID and char_slot=?charslot";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var result = (int)reader["level"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Deleta o personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        public static bool Delete(int accountID, int charSlot) {
            var varQuery = "DELETE FROM players WHERE account_id=?accountID AND char_slot=?charslot";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);

            try {
                cmd.ExecuteNonQuery();
            }
            catch {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Carrega dados temporarios dos personagens.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="charSlot"></param>
        public static void PreLoad(PlayerData pData) {
            var varQuery = "SELECT class_id, char_slot, name, sprite, level FROM players WHERE account_id=?accountID";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", pData.AccountID);
            var reader = cmd.ExecuteReader();

            pData.ClearCharacter();

            while (reader.Read()) {
                var slot = (int)reader["char_slot"];

                pData.Character[slot].Name = (string)reader["name"];
                pData.Character[slot].Level = (int)reader["level"];
                pData.Character[slot].Class = (int)reader["class_id"];
                pData.Character[slot].Sprite = Convert.ToInt16(reader["sprite"]);
            }


            reader.Close();
        }

        /// <summary>
        /// Carrega todos os dados do personagem.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="charSlot"></param>
        public static void Load(PlayerData pData, int charSlot) {
            var varQuery = "SELECT id, guild_id, name, world_id, region_id FROM players WHERE account_id=?accountID and char_slot=?charSlot";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", pData.AccountID);
            cmd.Parameters.AddWithValue("?charSlot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            pData.CharSlot = charSlot;
            pData.CharacterID = (int)reader["id"];
            pData.GuildID = (int)reader["guild_id"];
            pData.CharacterName = (string)reader["name"];
            pData.WorldID = (int)reader["world_id"];
            pData.RegionID = (int)reader["region_id"];

            reader.Close();
        }

        /// <summary>
        /// Insere um novo personagem ao banco de dados.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="gender"></param>
        /// <param name="classeID"></param>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="charSlot"></param>
        public static void InsertNewCharacter(string hexID, int gender, int classeID, string name, int sprite, int charSlot) {
            var query = new StringBuilder();
            var pData = Authentication.FindByHexID(hexID);
            var index = Classe.FindClasseIndexByID(classeID);

            query.Append("INSERT INTO players (account_id, class_id, char_slot, name, level, gender, sprite, ");
            query.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, statpoints)");
            query.Append("VALUES (?accountID, ?classeID, ?charSlot, ?name, ?level, ?gender, ?sprite, ?strenght, ?dexterity, ?agility, ");
            query.Append("?constitution, ?intelligence, ?wisdom, ?will, ?mind, ?charisma, ?statpoints)");

            var list = new List<MySqlParameter>();
            list.Add(new MySqlParameter("?accountID", pData.AccountID));
            list.Add(new MySqlParameter("?classeID", classeID));
            list.Add(new MySqlParameter("?charSlot", charSlot));
            list.Add(new MySqlParameter("?name", name));
            list.Add(new MySqlParameter("?level", Classe.Classes[index].Level));
            list.Add(new MySqlParameter("?gender", gender));
            list.Add(new MySqlParameter("?sprite", sprite));
            list.Add(new MySqlParameter("?strenght", Classe.Classes[index].Strenght));
            list.Add(new MySqlParameter("?dexterity", Classe.Classes[index].Dexterity));
            list.Add(new MySqlParameter("?agility", Classe.Classes[index].Agility));
            list.Add(new MySqlParameter("?constitution", Classe.Classes[index].Constitution));
            list.Add(new MySqlParameter("?intelligence", Classe.Classes[index].Intelligence));
            list.Add(new MySqlParameter("?wisdom", Classe.Classes[index].Wisdom));
            list.Add(new MySqlParameter("?will", Classe.Classes[index].Will));
            list.Add(new MySqlParameter("?mind", Classe.Classes[index].Mind));
            list.Add(new MySqlParameter("?charisma", Classe.Classes[index].Charisma));
            list.Add(new MySqlParameter("?statpoints", Classe.Classes[index].Points));
          
            var cmd = new MySqlCommand(query.ToString(), Common_DB.Connection);
            cmd.Parameters.AddRange(list.ToArray());
            cmd.ExecuteNonQuery(); 
        }    

        /// <summary>
        /// Insere items no inventario
        /// </summary>
        /// <param name="name"></param>
        /// <param name="classeID"></param>
        public static void InsertInitialItems(string name, int classeID) {
            var varQuery = new StringBuilder();
            var index = Classe.FindClasseIndexByID(classeID);
            var charID = ID(name);

            for(var item = 0; item < Common.Settings.MAX_ITEM; item++) {
                //se não há nenhum item, próximo
                if (Classe.Classes[index].GetItem((ItemType)item).ID == 0) continue;

                varQuery.Append("INSERT INTO player_inventory (char_id, inventory_slot, ");
                varQuery.Append("item_id, item_unique_id, item_count, enchant, item_element, durability, slots, expire_time, ");
                varQuery.Append("is_soul_bound, is_equipped) ");
                varQuery.Append("VALUES (");
                varQuery.Append($"'{charID}', ");
                varQuery.Append($"'{item}', "); //inv slot
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).ID}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).UniqueID}', ");
                varQuery.Append("'1', "); //quantidade
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).Enchant}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).Element}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).Durability}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).Slots}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).ExpireTime}', ");
                varQuery.Append($"'{Classe.Classes[index].GetItem((ItemType)item).IsSoulBound}', ");
                varQuery.Append("'1')"); //equipado

                var cmd = new MySqlCommand(varQuery.ToString(), Common_DB.Connection);
                cmd.ExecuteNonQuery();

                varQuery.Clear();
            }
        }
    }
}
