﻿using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;

namespace LoginServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// Lista de usuários.
        /// </summary>
        public static HashSet<PlayerData> Player { get; set; }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int accountID) {
            var find_id = from pData in Player
                          where pData.ID.CompareTo(accountID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static PlayerData FindByHexID(string hexID) {
            var find_hexID = from pData in Player
                             where pData.HexID.CompareTo(hexID) == 0
                             select pData;

            return find_hexID.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de usuário.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static PlayerData FindByAccount(string account) {
             var find_account = from pData in Player
                               where pData.Account.CompareTo(account) == 0
                               select pData;

            return find_account.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo usuário no campo 'temporário'.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static PlayerData FindByUsername(string username) {
            var find_account = from pData in Player
                               where pData.Username.CompareTo(username) == 0
                               select pData;

            return find_account.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pela conexão.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static PlayerData FindByConnection(NetConnection connection) {
            if (Equals(null, connection)) { return null; }

            var find_connection = from pData in Player
                                  where pData.Connection.Equals(connection)
                                  select pData;

            return find_connection.FirstOrDefault();
        }

        /// <summary>
        /// Verifica se o usuário já está conectado.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool IsConnected(string account) {
            var find_account = from pData in Player
                               where pData.Account.CompareTo(account) == 0
                               select pData;

            return (find_account.FirstOrDefault() == null) ? false : true;
        }

        /// <summary>
        /// Limpa os dados e libera a memoria.
        /// </summary>
        public static void Clear() {
            Player.Clear();
            Player = null;
        }
    }
}
