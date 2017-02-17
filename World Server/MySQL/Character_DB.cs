using System;
using System.Text;
using MySql.Data.MySqlClient;
using WorldServer.ClasseData;
using WorldServer.Server;

namespace WorldServer.MySQL {
    public class Character_DB {
        /// <summary>
        /// Pega o ID do personagem.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ID(string name) {
            var varQuery = $"SELECT id FROM players WHERE name='{name}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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
            var varQuery = $"SELECT id FROM players WHERE name='{name}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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
            var varQuery = $"SELECT name FROM players WHERE account_id='{accountID}' and char_slot='{charSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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
        /// <param name="chatSlot"></param>
        /// <returns></returns>
        public static int GetLevel(int accountID, int chatSlot) {
            var varQuery = $"SELECT level FROM players WHERE account_id='{accountID}' and char_slot='{chatSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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
            var varQuery = $"DELETE FROM players WHERE account_id='{accountID}' and char_slot='{charSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);

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
            var varQuery = $"SELECT class_id, char_slot, name, sprite, level FROM players WHERE account_id='{pData.AccountID}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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
            var varQuery = $"SELECT id, guild_id, name, world_id, region_id FROM players WHERE account_id='{pData.AccountID}' and char_slot='{charSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
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

            query.Append("INSERT INTO players (account_id, class_id, char_slot, name, level, gender, sprite, hp, mp, sp,");
            query.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, statpoints)");
            query.Append("VALUES ("); 
            query.Append($"'{pData.AccountID}', ");
            query.Append($"'{classeID}', ");
            query.Append($"'{charSlot}', ");
            query.Append($"'{name}', ");
            query.Append($"'{Classe.Classes[index].GetStat(StatType.Level)}', ");
            query.Append($"'{gender}', ");           
            query.Append($"'{sprite}', ");
            query.Append($"'{Classe.Classes[index].GetStat(StatType.MaxHP)}', ");
            query.Append($"'{Classe.Classes[index].GetStat(StatType.MaxMP)}', ");
            query.Append($"'{Classe.Classes[index].GetStat(StatType.MaxSP)}', ");
            query.Append($"'{Classe.Classes[index].Strenght}', ");
            query.Append($"'{Classe.Classes[index].Dexterity}', ");
            query.Append($"'{Classe.Classes[index].Agility}', ");
            query.Append($"'{Classe.Classes[index].Constitution}', ");
            query.Append($"'{Classe.Classes[index].Intelligence}', ");
            query.Append($"'{Classe.Classes[index].Wisdom}', ");
            query.Append($"'{Classe.Classes[index].Will}', ");
            query.Append($"'{Classe.Classes[index].Mind}', ");
            query.Append($"'{Classe.Classes[index].Charisma}', ");
            query.Append($"'{Classe.Classes[index].Points}')");

            var cmd = new MySqlCommand(query.ToString(), Common_DB.Connection);
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

            for(var item = 0; item < Common.Constant.MAX_ITEM; item++) {
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
