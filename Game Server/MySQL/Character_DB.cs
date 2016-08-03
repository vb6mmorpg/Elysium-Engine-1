using System;
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

            pData.PosX = Convert.ToInt16(reader["posx"]);
            pData.PosY = Convert.ToInt16(reader["posy"]);

            reader.Close();
        }

        /// <summary>
        /// Salva todos os dados do personagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="charID"></param>
        public static void Save(string hexID, int charID) {
            if (Common_DB.Connection == null) { return; }

        }
    }
}
