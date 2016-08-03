using System;
using MySql.Data.MySqlClient;
using WorldServer.Common;
using WorldServer.GameGuild;

namespace WorldServer.MySQL {
    public class Guild_DB {
        /// <summary>
        /// Obtém o ID de guild de personagem.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pID"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static int PlayerGuildID(int pID, string pName) {
            var varQuery = "SELECT guild_id FROM players WHERE id='" + pID + "' and name='" + pName + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var id = (int)reader["guild_id"];

            reader.Close();

            return id;
        }

        /// <summary>
        /// Atualiza o ID de guild de personagem.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="gID"></param>
        public static void UpdatePlayerGuildID(int pID, int gID) {           
            var varQuery = "UPDATE characters SET guild_id='" + gID + "' WHERE id='" + pID + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }
        
        /// <summary>
        /// Verifica se o nome de guild está no banco de dados.
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public static bool ExistGuild(string gName) {
            var varQuery = "SELECT id FROM guilds WHERE guild_name='" + gName + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            reader.Close();
            return true;
        }

        /// <summary>
        /// Obtém o ID de guild.
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public static int GuildID(string gName) {
            var varQuery = "SELECT id FROM guilds WHERE guild_name='" + gName + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var id = (int)reader["id"];

            reader.Close();

            return id;
        }

        /// <summary>
        /// Obtém todos os dados de guild.
        /// </summary>
        public static void GuildInfo() {           
            var varQuery = "SELECT * FROM guilds";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            Guild gData;

            while (reader.Read()) {
                gData = new Guild(true);
                gData.ID = (int)reader["id"];
                gData.OwnerID = (int)reader["owner_id"];
                gData.OwnerName = (string)reader["owner_name"];
                gData.Name = (string)reader["guild_name"];
                gData.Announcement = (string)reader["announcement"];

                Guild.Guilds.Add(gData);

                gData = null;
            }

            reader.Close(); 
        }

          /// <summary>
        /// Obtém membros de guild.
        /// </summary>
        public static void MemberInfo() {
            GuildMember mData;

            foreach (var gData in Guild.Guilds) {
                var varQuery = "SELECT player_id, player_name, permission, selfintro, contribution_points, access FROM guilds_member WHERE guild_id='" + gData.ID + "'";
                var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    mData = new GuildMember();
                    mData.ID = (int)reader["player_id"];
                    mData.Name = (string)reader["player_name"];
                    mData.SelfIntro = (string)reader["selfintro"];

                    gData.Member.Add(mData);

                    mData = null;
                }

                reader.Close();
              }
        }
    }
}

