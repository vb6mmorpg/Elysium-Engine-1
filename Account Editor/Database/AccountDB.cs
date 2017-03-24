using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace AccountEditor.Database {
    public class AccountDB {
        /// <summary>
        /// Verifica se a conta de usuário existe.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <returns></returns>
        public static bool ExistAccount(string username) {
            var query = "SELECT id FROM account WHERE account=?username";
            var cmd = new MySqlCommand(query, MySQL.LoginDB.Connection);
            cmd.Parameters.AddWithValue("?username", username);
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();
            reader.Close();

            return tempvar;
        }

        /// <summary>
        /// Insere um novo usuário.
        /// </summary>
        /// <param name="pData"></param>
        public static int InsertAccount(Account pData) {
            var query = "INSERT INTO account (account, password, email, pin, cash, language_id, access_level, active, first_name, ";
            query += "last_name, location, date_created, creator_ip) ";
            query += "VALUES (?account, ?password, ?email, ?pin, ?cash, ?language_id, ?access_level, ?active, ?first_name, ";
            query += "?last_name, ?location, ?date_created, ?creator_ip)";

            var cmd = new MySqlCommand(query, MySQL.LoginDB.Connection);
            cmd.Parameters.AddWithValue("?account", pData.Username);
            cmd.Parameters.AddWithValue("?password", Hash.Compute(pData.Password));
            cmd.Parameters.AddWithValue("?email", pData.Email);
            cmd.Parameters.AddWithValue("?pin", pData.Pin);
            cmd.Parameters.AddWithValue("?cash", pData.Cash);
            cmd.Parameters.AddWithValue("?language_id", pData.Language);
            cmd.Parameters.AddWithValue("?access_level", pData.Access);
            cmd.Parameters.AddWithValue("?active", pData.Activated);
            cmd.Parameters.AddWithValue("?first_name", pData.FirstName);
            cmd.Parameters.AddWithValue("?last_name", pData.LastName);
            cmd.Parameters.AddWithValue("?location", pData.Country);
            cmd.Parameters.AddWithValue("?date_created", DateTime.Now);
            cmd.Parameters.AddWithValue("?creator_ip", "127.0.0.1");

            var result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Carrega os dados do usuário.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Account LoadAccountData(string username) {
            var query = "SELECT * FROM account WHERE account=?username";
            var cmd = new MySqlCommand(query, MySQL.LoginDB.Connection);
            cmd.Parameters.AddWithValue("?username", username);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return null;
            }

            var pData = new Account();
            pData.ID = (int)reader["id"];
            pData.Username = (string)reader["account"];
            pData.Password = (string)reader["password"];
            pData.Email = (string)reader["email"];
            pData.Pin = (string)reader["pin"];
            pData.Cash = (int)reader["cash"];
            pData.Language = Convert.ToByte(reader["language_id"]);
            pData.LoggedIn = Convert.ToByte(reader["logged_in"]);
            pData.Access = Convert.ToInt16(reader["access_level"]);
            pData.Activated = Convert.ToByte(reader["active"]);
            pData.FirstName = (string)reader["first_name"];
            pData.LastName = (string)reader["last_name"];
            pData.Country = (string)reader["location"];
            pData.DateCreated = Convert.ToDateTime(reader["date_created"]);
            pData.DateLastLogin = Convert.ToDateTime(reader["date_last_login"]);
            pData.CreatorIp = (string)reader["creator_ip"];
            pData.IpLast = (string)reader["last_ip"];
            pData.CurrentIp = (string)reader["current_ip"];

            reader.Close();

            return pData;
        }

        /// <summary>
        /// Salva as informãções do usuário.
        /// </summary>
        /// <param name="pData"></param>
        public static int SaveAccountData(Account pData) {
            var query = "UPDATE account SET account=?account, password=?password, email=?email, pin=?pin, cash=?cash, ";
            query += "language_id=?language, access_level=?access, active=?active, first_name=?firstname, last_name=?lastname, ";
            query += "location=?location WHERE id=?id";

            var cmd = new MySqlCommand(query, MySQL.LoginDB.Connection);
            cmd.Parameters.AddWithValue("?account", pData.Username);
            cmd.Parameters.AddWithValue("?password", Hash.Compute(pData.Password));
            cmd.Parameters.AddWithValue("?email", pData.Email);
            cmd.Parameters.AddWithValue("?pin", pData.Pin);
            cmd.Parameters.AddWithValue("?cash", pData.Cash);
            cmd.Parameters.AddWithValue("?language", pData.Language);
            cmd.Parameters.AddWithValue("?access", pData.Access);
            cmd.Parameters.AddWithValue("?active", pData.Activated);
            cmd.Parameters.AddWithValue("?firstname", pData.FirstName);
            cmd.Parameters.AddWithValue("?lastname", pData.LastName);
            cmd.Parameters.AddWithValue("?location", pData.Country);
            cmd.Parameters.AddWithValue("?id", pData.ID);

            var result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <param name="username"></param>
        public static int DeleteAccountData(int id) {
            var varQuery = "DELETE FROM account WHERE id=?id";
            var cmd = new MySqlCommand(varQuery, MySQL.LoginDB.Connection);
            cmd.Parameters.AddWithValue("?id", id);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
