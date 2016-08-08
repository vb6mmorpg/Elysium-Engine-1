using System;
using System.Text;
using MySql.Data.MySqlClient;
using GameServer.Server;

namespace GameServer.MySQL {
    public class Character_DB {
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

            var classID = (int)reader["class_id"];

            pData.CharSlot = slot;
            pData.ClasseID = classID;
            pData.CharacterID = (int)reader["id"];    
            pData.GuildID = (int)reader["guild_id"];
            pData.CharacterName = (string)reader["name"];
            pData.Gender = Convert.ToByte(reader["gender"]);
            pData.Sprite = (int)reader["sprite"];
            pData.HP = (int)reader["hp"];
            pData.MP = (int)reader["mp"];
            pData.SP = (int)reader["sp"];
            pData.Level = (int)reader["level"];
            pData.Exp = (long)reader["exp"];

            pData.Strenght = (int)reader["strenght"];
            pData.Dexterity = (int)reader["dexterity"];
            pData.Agility = (int)reader["agility"];
            pData.Constitution = (int)reader["constitution"];
            pData.Intelligence = (int)reader["intelligence"];
            pData.Wisdom = (int)reader["wisdom"];
            pData.Will = (int)reader["will"];
            pData.Mind = (int)reader["mind"];
            pData.Charisma = (int)reader["charisma"];

            pData.StatPoint = (int)reader["statpoints"];

            pData.WorldID = (int)reader["world_id"];
            pData.RegionID = (int)reader["region_id"];

            pData.Direction = Convert.ToInt32(reader["direction"]);
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

           //var pData = Authentication.FindByHexID(hexID);

            StringBuilder varQuery = new StringBuilder();
            varQuery.Append("UPDATE players SET ");
            varQuery.Append($"hp='{pData.HP}', ");
            varQuery.Append($"mp='{pData.MP}', ");
            varQuery.Append($"sp='{pData.SP}', ");
            varQuery.Append($"level='{pData.Level}', ");
            varQuery.Append($"exp='{pData.Exp}', ");
            varQuery.Append($"strenght='{pData.Strenght}', ");
            varQuery.Append($"dexterity='{pData.Dexterity}', ");
            varQuery.Append($"agility='{pData.Agility}', ");
            varQuery.Append($"constitution='{pData.Constitution}', ");
            varQuery.Append($"intelligence='{pData.Intelligence}', ");
            varQuery.Append($"wisdom='{pData.Wisdom}', ");
            varQuery.Append($"will='{pData.Will}', ");
            varQuery.Append($"mind='{pData.Mind}', ");
            varQuery.Append($"charisma='{pData.Charisma}', ");
            varQuery.Append($"statpoints='{pData.StatPoint}', ");
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
