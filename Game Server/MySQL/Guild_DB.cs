using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using GameServer.GameGuild;
using GameServer.Common;

namespace GameServer.MySQL {
    public class Guild_DB {
        /// <summary>
        /// Obtém o ID de guild de personagem.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pID"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static int PlayerGuildID(int pID, string pName) {
            var varQuery = "SELECT guild_id FROM characters WHERE id='" + pID + "' and name='" + pName + "'";
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
        /// Obtém os dados de level.
        /// </summary>
        public static void GuildData() {
            var varQuery = "SELECT req_exp, req_contribution, req_money, max_members FROM guilds_exp";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            var index = 0;

            while (reader.Read()) {
                Guild.AddData();
                Guild.SetDataExp(index, Convert.ToInt64(reader["req_exp"]));
                Guild.SetDataContribution(index, Convert.ToInt64(reader["req_contribution"]));
                Guild.SetDataMoney(index, Convert.ToInt64(reader["req_money"]));
                Guild.SetDataMaxMember(index, (int)reader["max_members"]);

                index++;
            }

            reader.Close();
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
                gData.Level = (int)reader["level"];
                gData.Exp = Convert.ToInt64(reader["exp"]);
                gData.Contribution = Convert.ToInt64(reader["contribution_points"]);
                gData.Ranking = (int)reader["rank_pos"];
                gData.Announcement = (string)reader["announcement"];

                Guild.Guilds.Add(gData);

                gData = null;
            }

            reader.Close();
        }

        /// <summary>
        /// Obtém o histórico de guild.
        /// </summary>
        public static void HistoryInfo() {
            var hData = new GuildHistory();

            foreach (Guild gData in Guild.Guilds) {
                var varQuery = "SELECT date, player_name, description FROM guilds_history WHERE guild_id='" + gData.ID + "'";
                var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    hData.Date = (string)reader["date"];
                    hData.PlayerName = (string)reader["player_name"];
                    hData.Description = (string)reader["description"];

                    gData.History.Add(hData);

                    hData.Date = string.Empty;
                    hData.PlayerName = string.Empty;
                    hData.Description = string.Empty;
                }

                reader.Close();
            }
        }

        /// <summary>
        /// Obtém membros de guild.
        /// </summary>
        public static void MemberInfo() {
            GuildMember mData;

            foreach (Guild gData in Guild.Guilds) {
                var varQuery = "SELECT player_id, player_name, permission, selfintro, contribution_points, access FROM guilds_member WHERE guild_id='" + gData.ID + "'";

                MySqlCommand cmd = new MySqlCommand(varQuery, Common_DB.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    mData = new GuildMember();
                    mData.ID = (int)reader["player_id"];
                    mData.Name = (string)reader["player_name"];
                    mData.Permission = (string)reader["permission"];
                    mData.SelfIntro = (string)reader["selfintro"];
                    mData.Contribution = (int)reader["contribution_points"];
                    mData.Access = Convert.ToByte(reader["access"]);

                    gData.Member.Add(mData);

                    mData = null;
                }

                reader.Close();
            }
        }

        /// <summary>
        /// Insere um novo guild no banco de dados.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="gName"></param>
        public static void InsertGuild(int pID, string pName, string gName) {
            var varQuery = "INSERT INTO guilds (owner_id, owner_name, guild_name) VALUES (";
            varQuery += "'" + pID + "', ";
            varQuery += "'" + pName + "', ";
            varQuery += "'" + gName + "')";

            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }

        public static void InsertHistory(int gID, string pName, string description) {
            var varQuery = "INSERT INTO guilds_history (guild_id, date, player_name, description) VALUES (";
            varQuery += "'" + gID + "', ";
            varQuery += "'" + DateTime.Now + "', ";
            varQuery += "'" + pName + "', ";
            varQuery += "'" + description + "')";

            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }
        public static void InsertMember(int gID, int pID, string pName, string permission) {
            var varQuery = "INSERT INTO guilds_member (guild_id, player_id, player_name, permission) VALUES (";
            varQuery += "'" + gID + "', ";
            varQuery += "'" + pID + "', ";
            varQuery += "'" + pName + "', ";
            varQuery += "'" + permission + "')";

            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
