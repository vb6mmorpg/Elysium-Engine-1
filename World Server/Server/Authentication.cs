using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using WorldServer.Network;
using WorldServer.Common;

/* O servidor de login gera um código hexadecimal a partir da conexão; esse código chamo de hexID.
   Esse hexa é enviado para o cliente no momento da conexão com o servidor de login.
   E também é enviado ao servidor (world) que o jogador quer conectar-se.
   O World recebendo o hexa pelo servidor de login, é adicionado na lista "HexID".

   Então, o cliente conecta ao servidor (world) e envia o hexadecimal que foi enviado pelo servidor de login.
   O método "ReceivedHexID" recebe o hex do cliente e altera o atual hexID pelo do cliente.

   O método "VerifyPlayerHexID" verifica se o hexID do jogador é igual com algum recebido pelo servidor de login.
   Se correto, chama o método "AcceptHexID" e copia todos os dados da lista "HexID" para o jogador.
   Então, carrega todos os dados do usuário.

   O hexID enviado pelo servidor de login é deletado depois de 30 segundos. Esse é o tempo necessário para a conexão com o cliente.
*/

namespace WorldServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// HexID recebido pelo login server.
        /// </summary>
        public static HashSet<HexaID> HexID { get; set; }

        /// <summary>
        /// Conexões e jogadores.
        /// </summary>
        public static HashSet<PlayerData> Player { get; set; }

        /// <summary>
        /// Adiciona os dados recebido do login server.
        /// </summary>
        /// <param name="data"></param>
        public static void AddHexID(NetIncomingMessage data) {
            var hexID = new HexaID();

            hexID.HexID = data.ReadString();
            hexID.Account = data.ReadString();
            hexID.AccountID = data.ReadInt32();
            hexID.LanguageID = data.ReadInt32();
            hexID.AccessLevel = data.ReadInt32();
            hexID.Cash = data.ReadInt32();
            hexID.Pin = data.ReadString();
            hexID.Time = Environment.TickCount;
            var service = data.ReadInt32();

            for(var n = 0; n < service; n++) hexID.Service.Add(data.ReadString());

            HexID.Add(hexID);

            LogConfig.WriteLog($"Data From Login Server ID: {hexID.AccountID} Account: {hexID.Account} {hexID.HexID}", Color.Black);
        }

        /// <summary>
        /// Recebe do cliente e altera o hexID.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void ReceivedHexID(NetConnection connection, string hexID)  {
            var pData = FindByConnection(connection);
            pData.HexID = hexID;

            LogConfig.WriteLog($"Data From Client: {hexID}", Color.Black);
        }

        /// <summary>
        /// Copia a estrutura para a Player e remove da lista de HexID.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hexIndex"></param>
        public static void AcceptHexID(NetConnection connection, HexaID hexID) {
            var pData = FindByConnection(connection);

            pData.HexID = hexID.HexID;
            pData.AccountID = hexID.AccountID;
            pData.Account = hexID.Account;
            pData.LanguageID = hexID.LanguageID;
            pData.AccessLevel = hexID.AccessLevel;
            pData.Cash = hexID.Cash;
            pData.Pin = hexID.Pin;
            pData.Service = hexID.Service;

            HexID.Remove(hexID);
        }

        /// <summary>
        /// Percorre todos os jogadores e verifica o estado atual do HexID.
        /// </summary>
        public static void VerifyPlayerHexID() {
            HexaID hexID;

            foreach (var pData in Player) {
                if (!string.IsNullOrEmpty(pData.Account)) { continue; }
                if (string.IsNullOrEmpty(pData.HexID)) { continue; }

                hexID = FindHexID(pData.HexID);

                // Se não encontrar o hexid, desconecta o usuário pelo cliente
                if (Equals(null, hexID)) { 
                    WorldServerPacket.Message(pData.Connection, (int)PacketList.Disconnect);
                    continue;
                }
                
                //Aceita o hexID e permite a conexão
                Authentication.AcceptHexID(pData.Connection, hexID);

                LogConfig.WriteLog($"Player Found ID: {pData.AccountID} Account: {pData.Account} {pData.HexID}", Color.Black);

                //inicia o processo de login
                PlayerLogin.Login(pData);
            }
        }

        /// <summary>
        /// Percorre todos os hexid e verifica o estado atual.
        /// </summary>
        public static void VerifyHexID() {
            //se algum dado estiver mais que 30 segundos no sistema, é removido da lista.
            foreach (var hexID in HexID) {
                if (Environment.TickCount > hexID.Time + 30000) {
                    LogConfig.WriteLog($"Removed HexID: {hexID.HexID} {hexID.Account}", Color.Coral);
                    HexID.Remove(hexID); 
                }
            }
        }

        /// <summary>
        /// Procura o HexID, retorna nulo caso falso.
        /// </summary>
        /// <param name="hexid"></param>
        /// <returns></returns>
        public static HexaID FindHexID(string hexID) {
            if (string.IsNullOrEmpty(hexID)) { return null; }

            var find_hexid = from hData in HexID
                             where hData.HexID.CompareTo(hexID) == 0
                             select hData;

            return find_hexid.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int accountID) {
            var find_id = from pData in Player
                          where pData.AccountID.CompareTo(accountID) == 0
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
