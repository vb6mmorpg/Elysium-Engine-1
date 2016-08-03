﻿using System;
using MySql.Data.MySqlClient;
using LoginServer.Server;
using System.Globalization;
using System.Threading;

namespace LoginServer.MySQL {
    public static class Accounts_DB {
        /// <summary>
        /// Obtém o ID de usuário.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int GetID(string username) {
            var varQuery = "SELECT id FROM account WHERE account='" + username +"'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);          
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
        /// Obtém informações básicas da conta de usuário.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static void AccountData(PlayerData pData) {
            var varQuery = "SELECT pin, cash, language_id, access_level FROM account WHERE id='" + pData.ID +"'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            pData.Pin = (string)reader["pin"];
            pData.Cash = (int)reader["cash"];
            pData.LanguageID = Convert.ToInt32(reader["language_id"]);
            pData.AccessLevel = (int)reader["access_level"];

            reader.Close();
        }

        /// <summary>
        /// Obtem as informações do serviço.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="id"></param>
        public static void AccountService(PlayerData pData) {
            var varQuery = "SELECT id, service_id, end_time, expire FROM account_service WHERE account_id='" + pData.ID + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();
            
            //inicia a var
            var expire = 0;
            const int EXPIRED = 1;

            while (reader.Read()) {
                expire = (int)reader["expire"];

                // 1 = expirado
                // 0 = ainda ativo
                //Se o tempo já expirou, move para o próximo
                if (expire == EXPIRED) { continue; }

                pData.Service.Add((int)reader["service_id"], (string)reader["end_time"]);
            }

            reader.Close();
        }

        /// <summary>
        /// Altera as informações do serviço.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public static void UpdateService(int accountID, int id, int value) {
            var varQuery = "UPDATE account_service SET expire ='" + value + "' WHERE account_id='" + accountID + "' and service_id='" + id +"'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verifica se o nome está na lista de banidos.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool BannedAccount(int id) {
            var varQuery = "SELECT id, expire, end_time FROM account_ban WHERE account_id='" + id + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            const int EXPIRED = 1;
            var expire = (int)reader["expire"];

            // 1 = expirado
            // 0 = ainda ativo
            //Se o tempo já expirou, retorna falso
            if (expire == EXPIRED) {
                reader.Close();
                return false; 
            }

            //Verifica se o tempo já expirou
            string[] date = reader["end_time"].ToString().Split('/');
            var end_time = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));

            // 1 = expirado, tempo diferente
            //Se expirou, atualiza o valor    
            if (DateTime.Today.Date.CompareTo(end_time.Date) == EXPIRED) {
                var ban_id = (int)reader["id"];
                reader.Close();
                UpdateBan(ban_id, EXPIRED);
                return false;
            }
            
            reader.Close();
            return true;
        }

        /// <summary>
        /// Atualiza o status do ban (usado para removação).
        /// </summary>
        /// <param name="banID"></param>
        /// <param name="value"></param>
        public static void UpdateBan(int banID, int value) {
            var varQuery = "UPDATE account_ban SET expire=@value WHERE id='" + banID + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verifica se o ip já está na lista de banidos.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool BannedIP(string address) {
            var varQuery = "SELECT id, end_time FROM banned_ip WHERE address='" + address + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();
            
            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            const int EXPIRED = 1;
            //pega a data na db
            string[] date = reader["end_time"].ToString().Split('/');
            var end_time = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));

            //Se expirou, atualiza
            //1 = expirado
            if (DateTime.Today.Date.CompareTo(end_time.Date) == EXPIRED) {
                var ban_id = (int)reader["id"];
                reader.Close();
                RemoveBannedIP(ban_id);
                return false;
            }

            reader.Close();
            return true;
        }

        /// <summary>
        /// Atualiza o status do ban (normalmente usado para remoção).
        /// </summary>
        /// <param name="id"></param>
        public static void RemoveBannedIP(int id) {
            var varQuery = "DELETE from banned_ip WHERE id='" + id + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verifica se a conta de usuário existe.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <returns></returns>
        public static bool ExistAccount(string username) {
            var varQuery = "SELECT id FROM account WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);          
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();
            reader.Close();

            return tempvar;
        }

        /// <summary>
        /// Verifica a senha da conta.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="password">senha de usuário</param>
        /// <returns></returns>
        public static bool ExistPassword(string username, string password) {
            var varQuery = "SELECT password FROM account WHERE account ='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            //  if (string.CompareOrdinal(tempVar, Cryptography.Encrypt(password)) == 0)
            // 0 string igual
            if (string.CompareOrdinal(reader["password"].ToString(), password) == 0) {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;
        }

        /// <summary>
        /// Verifica o pin da conta.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="password">pin de usuário</param>
        /// <returns></returns>
        public static bool ExistPin(string username, string password) {
            var varQuery = "SELECT pin FROM account WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            //  if (string.CompareOrdinal(tempVar, Cryptography.Encrypt(password)) == 0)
            // 0 = string igual
            if (string.CompareOrdinal(reader["pin"].ToString(), password) == 0) {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;
        }

        /// <summary>
        /// Atualiza o pin da conta.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="password">pin de usuário</param>
        public static void UpdatePin(string username, string password) {
            var varQuery = "UPDATE account SET pin='" + password + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza o valor caso o jogador esteja conectado.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="value">verdadeiro (1) ou falso (0)</param>
        public static void UpdateLoggedIn(string username, int value) {
            var varQuery = "UPDATE account SET logged_in='" + value + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Altera o ID de idioma.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="langID">ID de idioma</param>
        public static void UpdateLanguageID(string username, int langID) {
            var varQuery = "UPDATE account SET language_id='" + langID + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza com a data do último acesso. 
        /// </summary>
        /// <param name="username"></param>
        public static void UpdateDateLasteLogin(string username) {
            var varQuery = "UPDATE account SET date_last_login='" + DateTime.Now + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza com o ip do último acesso.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        public static void UpdateLastIP(string username, string ip) {
            var varQuery = "UPDATE account SET last_ip='" + ip + "', current_ip=' ' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza com o ip do atual acesso.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        public static void UpdateCurrentIP(string username, string ip) {
            var varQuery = "UPDATE account SET current_ip='" + ip + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verifica se a conta está ativa.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <returns></returns>
        public static bool IsActive(string username) {
            var varQuery = "SELECT active FROM account WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();
            reader.Close();

            return tempvar;
        }

        /// <summary>
        /// Atualiza a quantidade de cash.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="value">valor</param>
        public static void UpdateCash(string username, int value) {
            var varQuery = "UPDATE account SET cash='" + value + "' WHERE account='" + username + "'";
            var cmd = new MySqlCommand(varQuery, Common_DB.SQLConnection);
            cmd.ExecuteNonQuery();
        }
    }
}