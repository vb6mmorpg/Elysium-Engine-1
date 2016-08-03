using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Account_Editor.MySQL
{
    public class Account_DB
    {
        /// <summary>
        /// Estrutura da Conta
        /// </summary>
        public static int ID; // Não modificavel
        public static string Account;
        public static string Password;
        public static string Email;
        public static string Pin;
        public static int Cash;
        public static int Language;
        public static int Logged; // Não modificavel
        public static int Access;
        public static int Active;
        public static string FirstName;
        public static string LastName;
        public static string Location;
        public static string Date_Register; // Não modificavel
        public static string Date_Login; // Não modificavel
        public static string Creator_Ip; // Não modificavel
        public static string Last_Ip; // Não modificavel
        public static string Current_Ip; // Não modificavel

        /// <summary>
        /// Carregar dados do DB
        /// <param name="pName">Nome da Conta</param>
        /// </summary>
        public static bool Load(string pName)
        {
            // Checar se está conectado com o MySQL
            if (Program.EditForm.LS_Database.mysql_connection == null) return false;

            // Procurar dados apartir do pName - Nome da Conta
            string varQuery = "SELECT * FROM account WHERE account='" + pName + "'";
            MySqlCommand cmd = new MySqlCommand(varQuery, Program.EditForm.LS_Database.mysql_connection);
            MySqlDataReader reader = cmd.ExecuteReader(); // Abrir Conexão

            // Checar se a conta realmente existe
            if (reader.Read() == false)
            {
                reader.Close();
                return false;
            }

            // Salvar dados do MySQL em Variáveis
            ID = (int)reader["id"];
            Account = (string)reader["account"];
            Password = (string)reader["password"];
            Email = (string)reader["email"];
            Pin = (string)reader["pin"];
            Cash = (int)reader["cash"];
            Language = (int)reader["language_id"];
            Logged = (int)reader["logged_in"];
            Access = (int)reader["access_level"];
            Active = (int)reader["active"];
            FirstName = (string)reader["first_name"];
            LastName = (string)reader["last_name"];
            Location = (string)reader["location"];
            Date_Register = (string)reader["date_created"];
            Date_Login = (string)reader["date_last_login"];
            Creator_Ip = (string)reader["creator_ip"];
            Last_Ip = (string)reader["last_ip"];
            Current_Ip = (string)reader["current_ip"];

            // Fechar Conexão
            reader.Close();
            return true;
        }

        /// <summary>
        /// Carregar dados do DB
        /// <param name="pID">Id da conta</param>
        /// </summary>
        public static bool Save(int pID)
        {
            // Checar se está conectado com o MySQL
            if (Program.EditForm.LS_Database.mysql_connection == null) return false;

            try
            {
                // Definir quais dados serão salvos e seus novos valores.
                StringBuilder varQuery = new StringBuilder();
                varQuery.Append("UPDATE account SET " +
                    "account='" + Account + "', " +
                    "password='" + Password + "', " +
                    "email='" + Email + "', " +
                    "pin='" + Pin + "', " +
                    "cash='" + Cash + "', " +
                    "language_id='" + Language + "', " +
                    "access_level='" + Access + "', " +
                    "active='" + Active + "', " +
                    "first_name='" + FirstName + "', " +
                    "last_name='" + LastName + "', " +
                    "location='" + Location + "' " +
                    "WHERE id='" + pID + "'"); // Id em que os dados serão salvos

                // Executar comando para salvar
                MySqlCommand cmd = new MySqlCommand(varQuery.ToString(), Program.EditForm.LS_Database.mysql_connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }
    }
}
