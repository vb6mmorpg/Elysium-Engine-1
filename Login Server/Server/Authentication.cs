using System.Collections.Generic;
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
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByID(int id) {
            var find_id = from pData in Player
                          where pData.ID.CompareTo(id) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static PlayerData FindByHexID(string hexID) {
            if (Player.Count == 0) { return null; }

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
            if (Player.Count == 0) { return null; }

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
            if (Player.Count == 0) { return null; }

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
            if (Player.Count == 0) { return null; }
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
            if (Player.Count == 0) { return false; }

            var find_account = from pData in Player
                               where pData.Account.CompareTo(account) == 0
                               select pData;

            return (find_account.FirstOrDefault() == null) ? false : true;
        }
    }
}
