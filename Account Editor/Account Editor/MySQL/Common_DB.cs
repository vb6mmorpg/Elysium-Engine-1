using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Account_Editor.MySQL
{
    public class Common_DB
    {
        public MySqlConnection mysql_connection = null;
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        /// <summary>
        /// Realiza a conexão com o banco de dados.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool Connect(out string error)
        {
            StringBuilder varCon = new StringBuilder();
            varCon.Append("Server=" + Server + ";");
            varCon.Append("Port=" + Port + ";");
            varCon.Append("Database=" + Database + ";");
            varCon.Append("User ID=" + Username + ";");
            varCon.Append("Password=" + Password + ";");

            try
            {
                mysql_connection = new MySqlConnection();
                mysql_connection.ConnectionString = varCon.ToString();
                mysql_connection.Open();
            }

            catch (MySqlException ex)
            {
                error = ex.Message;
                return false;
            }

            finally
            {
                varCon = null;
            }

            error = string.Empty;
            return true;
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            if (mysql_connection == null) { return false; }

            if (mysql_connection.State != ConnectionState.Closed)
            {
                mysql_connection.Close();
                mysql_connection.Dispose();
            }

            Thread.Sleep(750);

            if (mysql_connection.State == ConnectionState.Closed)
                return true;
            else
                return false;
        }
    }
}
