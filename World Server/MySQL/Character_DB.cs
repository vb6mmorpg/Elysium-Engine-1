using System.Text;
using MySql.Data.MySqlClient;
using WorldServer.Classe;
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

            var tempvar = (int)reader["id"];
            reader.Close();

            return tempvar;
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

            var tempvar = reader.Read();
            reader.Close();

            return tempvar;
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
                return -1;
            }

            var level = (int)reader["level"];

            reader.Close();

            return level;
        }

        /// <summary>
        /// Deleta o personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        public static void Delete(int accountID, int charSlot) {
            var varQuery = $"DELETE FROM players WHERE account_id='{accountID}' and char_slot='{charSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Carrega dados temporarios dos personagens.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="charSlot"></param>
        public static void PreLoad(PlayerData pData, int charSlot) {
            var varQuery = $"SELECT name, sprite, level, class_id FROM players WHERE account_id='{pData.AccountID}' and char_slot='{charSlot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            pData.Character[charSlot].Name = (string)reader["name"];
            pData.Character[charSlot].Level = (int)reader["level"];
            pData.Character[charSlot].Class = (int)reader["class_id"];
            pData.Character[charSlot].Sprite = (int)reader["sprite"];

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
            var varQuery = new StringBuilder();
            var pData = Authentication.FindByHexID(hexID);

            varQuery.Append("INSERT INTO players (account_id, class_id, char_slot, name, level, gender, sprite, hp, mp, sp,");
            varQuery.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, charisma, statpoints)");
            varQuery.Append("VALUES ("); 
            varQuery.Append($"'{pData.AccountID}', ");
            varQuery.Append($"'{classeID}', ");
            varQuery.Append($"'{charSlot}', ");
            varQuery.Append($"'{name}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Level, classeID)}', ");
            varQuery.Append($"'{gender}', ");           
            varQuery.Append($"'{sprite}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.MaxHP, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.MaxMP, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.MaxSP, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Strenght, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Dexterity, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Agility, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Constitution, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Intelligence, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Wisdom, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Will, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Mind, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Charisma, classeID)}', ");
            varQuery.Append($"'{Classes.GetStat(Stats.Point, classeID)}')");

            var cmd = new MySqlCommand(varQuery.ToString(), Common_DB.Connection);
            cmd.ExecuteNonQuery(); 
        }    

        /// <summary>
        /// Insere items no inventario
        /// </summary>
        /// <param name="name"></param>
        /// <param name="classeID"></param>
        public static void InsertInitialItems(string name, int classeID) {
            var varQuery = new StringBuilder();
            var index = Classes.FindIndexByClasseID(classeID);
            var charID = ID(name);

            for(var inv = 0; inv < 15; inv++) {
                //se não há nenhum item, próximo
                if (Classes.ClassesItem[index].Equipped[inv].ID == 0) { continue; }

                varQuery.Append("INSERT INTO player_inventory (char_id, inventory_slot, ");
                varQuery.Append("item_id, item_unique_id, item_count, enchant, item_element, durability, slots, expire_time, ");
                varQuery.Append("is_soul_bound, is_equipped) ");
                varQuery.Append("VALUES (");
                varQuery.Append($"'{charID}', ");
                varQuery.Append($"'{inv}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].ID}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].UniqueID}', ");
                varQuery.Append("'1', "); //quantidade
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].Enchant}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].Element}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].Durability}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].Slots}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].ExpireTime}', ");
                varQuery.Append($"'{Classes.ClassesItem[index].Equipped[inv].IsSoulBound}', ");
                varQuery.Append("'1')"); //equipado

                var cmd = new MySqlCommand(varQuery.ToString(), Common_DB.Connection);
                cmd.ExecuteNonQuery();

                varQuery.Clear();
            }
        }
    }
}
