using System;
using System.Text;
using MySql.Data.MySqlClient;
using GameServer.Server;

namespace GameServer.MySQL {
    public class Character_DB {

        public static string CharacterName(int accountID, int slot) {
            var varQuery = $"SELECT name FROM players WHERE account_id='{accountID}' and char_slot='{slot}'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == false) {
                reader.Close();
                return string.Empty;
            }

            var result = (string)reader["name"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Carrega todos os dados do personagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="slot"></param>
        public static void Load(string hexID, int slot) {
            if (Common_DB.Connection == null) { return; }

            var pData = Authentication.FindByHexID(hexID);

            var varQuery = "SELECT * FROM players WHERE account_id='" + pData.AccountID + "' and char_slot='" + slot + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == false) {
                reader.Close();
                return;
            }

            pData.CharSlot = slot;
            pData.ClasseID = (int)reader["class_id"]; 
            pData.CharacterID = (int)reader["id"];    
            pData.GuildID = (int)reader["guild_id"];
            pData.CharacterName = (string)reader["name"];
            pData.Gender = Convert.ToByte(reader["gender"]);
            pData.Sprite = Convert.ToInt16(reader["sprite"]);
            pData.HP = (int)reader["hp"];
            pData.MP = (int)reader["mp"];
            pData.SP = (int)reader["sp"];
            pData.Level = (int)reader["level"];
            pData.Exp = (long)reader["exp"];
            pData.BaseStrenght = (int)reader["strenght"];
            pData.BaseDexterity = (int)reader["dexterity"];
            pData.BaseAgility = (int)reader["agility"];
            pData.BaseConstitution = (int)reader["constitution"];
            pData.BaseIntelligence = (int)reader["intelligence"];
            pData.BaseWisdom = (int)reader["wisdom"];
            pData.BaseWill = (int)reader["will"];
            pData.BaseMind = (int)reader["mind"];
            pData.BaseCharisma = (int)reader["charisma"];
            pData.Points = (int)reader["statpoints"];
            pData.WorldID = Convert.ToInt16(reader["world_id"]);
            pData.RegionID = Convert.ToInt16(reader["region_id"]);
            pData.Direction = Convert.ToByte(reader["direction"]);
            pData.PosX = Convert.ToInt16(reader["posx"]);
            pData.PosY = Convert.ToInt16(reader["posy"]);

            reader.Close();
        }

        /// <summary>
        /// Salva todos os dados do personagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="charID"></param>
        public static void Save(PlayerData pData) {
            if (Common_DB.Connection == null) { return; }

            StringBuilder varQuery = new StringBuilder();
            varQuery.Append("UPDATE players SET ");
            varQuery.Append($"hp='{pData.HP}', ");
            varQuery.Append($"mp='{pData.MP}', ");
            varQuery.Append($"sp='{pData.SP}', ");
            varQuery.Append($"level='{pData.Level}', ");
            varQuery.Append($"exp='{pData.Exp}', ");
            varQuery.Append($"strenght='{pData.BaseStrenght}', ");
            varQuery.Append($"dexterity='{pData.BaseDexterity}', ");
            varQuery.Append($"agility='{pData.BaseAgility}', ");
            varQuery.Append($"constitution='{pData.BaseConstitution}', ");
            varQuery.Append($"intelligence='{pData.BaseIntelligence}', ");
            varQuery.Append($"wisdom='{pData.BaseWisdom}', ");
            varQuery.Append($"will='{pData.BaseWill}', ");
            varQuery.Append($"mind='{pData.BaseMind}', ");
            varQuery.Append($"charisma='{pData.BaseCharisma}', ");
            varQuery.Append($"statpoints='{pData.Points}', ");
            varQuery.Append($"world_id='{pData.WorldID}', ");
            varQuery.Append($"region_id='{pData.RegionID}', ");
            varQuery.Append($"direction='{pData.Direction}', ");
            varQuery.Append($"posx='{pData.PosX}', ");
            varQuery.Append($"posy='{pData.PosY}' ");
            varQuery.Append($"WHERE id='{pData.CharacterID}' AND account_id='{pData.AccountID}'");

            var cmd = new MySqlCommand(varQuery.ToString(), Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
