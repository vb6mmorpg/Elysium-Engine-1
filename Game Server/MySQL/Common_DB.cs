using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;

namespace GameServer.MySQL {
    public class Common_DB {
        public static MySqlConnection Connection = null;
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }

        /// <summary>
        /// Realiza a conexão com o banco de dados.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool Connect(out string error) {
            var varQuery = "Server=" + Server + ";";
            varQuery += "Port=" + Port + ";";
            varQuery += "Database=" + Database + ";";
            varQuery += "User ID=" + Username + ";";
            varQuery += "Password=" + Password + ";";

            try {
                Connection = new MySqlConnection();
                Connection.ConnectionString = varQuery;
                Connection.Open();
            }

            catch (MySqlException ex) {
                error = ex.Message;
                return false;
            }

            error = string.Empty;
            return true;
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        /// <returns></returns>
        public static bool Disconnect() {
            if (Connection == null) { return false; }

            if (Connection.State != ConnectionState.Closed) {
                Connection.Close();
                Connection.Dispose();
            }

            Thread.Sleep(750);

            if (Connection.State == ConnectionState.Closed) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
