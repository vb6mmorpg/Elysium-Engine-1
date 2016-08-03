using System;
using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;
using LoginServer.Common;

namespace LoginServer.MySQL {
    public static class Common_DB {
        public static MySqlConnection SQLConnection { get; set; }
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
        public static bool Connect(out string message) {
            var varCon = "Server=" + Server + ";";
            varCon += "Port=" + Port + ";";
            varCon += "Database=" + Database + ";";
            varCon += "User ID=" + Username + ";";
            varCon += "Password=" + Password + ";";

            try {
                SQLConnection = new MySqlConnection();
                SQLConnection.ConnectionString = varCon.ToString();
                SQLConnection.Open();
            }
            catch (MySqlException ex) {
                message = ex.Message;
                return false;
            }

            message = string.Empty;
            return true;
        }
        
        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        /// <returns></returns>
        public static bool Disconnect() {
            if (SQLConnection == null) { return false; }

            if (SQLConnection.State != ConnectionState.Closed) {
                SQLConnection.Close();
                SQLConnection.Dispose();
            }

            // sleep para checar novamente a conexão
            Thread.Sleep(750);

            // verifica novamente, se foi fechada
            if (SQLConnection.State == ConnectionState.Closed) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
