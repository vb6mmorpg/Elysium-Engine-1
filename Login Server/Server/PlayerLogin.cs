using Lidgren.Network;
using LoginServer.MySQL;
using LoginServer.Network;
using LoginServer.Common;

namespace LoginServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// Verifica se a versão do cliente e nome de usuário estão corretos.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        public static void Login(string hexID, NetIncomingMessage data) {
            //Se o bloqueio de login estiver ativo, envia mensagem de erro para o cliente
            if (Settings.CantConnectNow) {
                LoginPacket.Message(hexID, (int)PacketList.LoginServer_Client_Maintenance);
                return;
            }

            //Verifica a versão do jogo; se invalido, envia mensagem de erro
            var version = data.ReadString();
            if (Settings.Version.CompareTo(version) != 0) {
                LoginPacket.Message(hexID, (int)PacketList.InvalidVersion);
                return;
            }

            //verifica o checksum do cliente; se invalido, envia mensagem de erro
            var checksum = data.ReadString();
            if (CheckSum.Enabled)
                if (!CheckSum.Compare(version, checksum)) {
                    LoginPacket.Message(hexID, (int)PacketList.CantConnectNow);
                    return;
                }

            var pData = FindByHexID(hexID);
            pData.Username = data.ReadString().ToLower();     //lê o nome de usuário em uma variavel temporaria para distinguir do 'account
            pData.Password = data.ReadString();               //lê a senha de usuário

            //Verifica se o usuário está na lista de banidos, caso verdadeiro, envia mensagem de erro
            if (Accounts_DB.IsBanned(Accounts_DB.GetID(pData.Username))) {
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AccountBanned);
                return;
            }

            //Verifica se o nome existe no banco de dados, caso falso, envia a mensagem de erro
            if (!Accounts_DB.ExistAccount(pData.Username)) {
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_InvalidNamePass);
                return;
            }

            //Verifica se o usuário está ativo, caso falso, envia mensagem de erro
            if (!Accounts_DB.IsActive(pData.Username)) { 
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AccountDisabled);
                return;
            }

            //Envia mensagem para outros servidores para saber se há algum usuario com o mesmo nome online
            if (WorldNetwork.IsWorldServerConnected())
                WorldPacket.IsPlayerConnected(pData.Username);
            else //se não há nenhum servidor conectado, continua para o próximo método
                Login(false, pData.Username);
        }

        /// <summary>
        /// Verifica a resposta de outros servidores.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="username"></param>
        public static void Login(int index, bool value, string username) {
            /* pega a informação de cada servidor e guarda em WorldResult[serverIndex].
               quando o worldresultcount for igual a mesma quantidade de servidores online, o processo chegou ao fim.
               então, é verificado se há alguma var 'true' que veio de cada servidor.
               se aparecer algum 'true', há alguma conta conectada em outro servidor. 
               chama o próximo método com o resultado para terminar o processo de login
            */

            //busca o atual usuário
            var pData = FindByUsername(username);

            //pega a informação do world server
            pData.WorldResult[index] = value;

            //incrementa o número de resposta de cada world
            pData.WorldResultCount++;

            //se a quantidade de respostas for o mesmo que servidores connectados
            if (pData.WorldResultCount == WorldNetwork.TotalOnline) {
                var result = false;

                //se achar o usuario conectado em algum lugar, muda result para true
                for (var n = 0; n < Settings.MAX_SERVER; n++) {
                    if (pData.WorldResult[n]) { result = true; }
                }

                //zera a contagem
                pData.WorldResultCount = 0;

                //chama o restante do login
                Login(result, username);
            }
        }

        /// <summary>
        /// Verifica a senha de usuário e garante acesso ao sistema.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="username"></param>
        public static void Login(bool result, string username) {
            var pData = FindByUsername(username);

            //se nao achar em outro lugar, verifica no proprio login server
            if (!result) { //(se falso), check login server
                //Verifica se o usuário já está conectado, caso verdadeiro, envia mensagem de erro
                if (Authentication.IsConnected(pData.Username)) {
                    pData.LoginAttempt++;
                    TryingToAccess(pData);
                    return;
                }
            }
            else {
                pData.LoginAttempt++;
                TryingToAccess(pData);
                return;
            }

            //Verifica se os campos estão corretos, caso falso, envia mensagem de erro
            if (!Accounts_DB.ExistPassword(pData.Username, pData.Password)) {
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_InvalidNamePass);
                return;
            }

            //muda o nome de usuario para o campo oficial de usuario e limpar o campo temporario
            pData.Account = pData.Username;
            pData.Username = string.Empty;

            FileLog.WriteLog($"User Login: {pData.Account} {pData.IP}", System.Drawing.Color.Black); 

            //carrega as informações da conta
            Accounts_DB.LoadAccountData(pData);
            Accounts_DB.LoadAccountService(pData);

            //verifica os serviços
            pData.Service.VerifyServices(pData.ID);

            Accounts_DB.UpdateDateLasteLogin(pData.Account);
            Accounts_DB.UpdateCurrentIP(pData.Account, pData.IP); 
            Accounts_DB.UpdateLoggedIn(pData.Account, 1);  //1 = true

            //envia a lista de servidores e muda a tela no cliente
            LoginPacket.ServerList(pData.HexID);
            LoginPacket.GameState(pData.HexID, 2); //tela 2, lista de servidor
        }

        /// <summary>
        /// Limpa os dados de usuário para voltar a tela de login
        /// </summary>
        /// <param name="index"></param>
        public static void BackToLoginScreen(string hexID) {
            var pData = Authentication.FindByHexID(hexID);

            Accounts_DB.UpdateLastIP(pData.Account, pData.IP);
            Accounts_DB.UpdateLoggedIn(pData.Account, 0); //0 = false

            pData.Clear();
        }

        /// <summary>
        /// Verifica o número de tentativas e envia mensagens de erro.
        /// </summary>
        /// <param name="pData"></param>
        public static void TryingToAccess(PlayerData pData) {       
            // se realizar 3 tentativas de login, desconecta o usuário que já está logado e permite que o novo se conecte
            if (pData.LoginAttempt >= Settings.MAX_ATTEMPT) {

                //Desconecta o usuario em todos os servidores
                WorldPacket.PlayerDisconnect(pData);

                // ##################### MUDAR PARA WORLD SERVER #####################
                //Desconecta o usuario no servidor de login (se houver) pelo cliente
                var hexid = Authentication.FindByAccount(pData.Username)?.HexID;

                if (!string.IsNullOrEmpty(hexid)) {
                    LoginPacket.Message(hexid, (int)PacketList.Disconnect); 
                }
                //######################################################################

                //se conectado ao login server, limpa os dados do usuario conectado da lista para o novo login
                if (Authentication.IsConnected(pData.Username)) {
                    Authentication.FindByAccount(pData.Username)?.Clear();
                }                

                //reseta o contador
                pData.LoginAttempt = 0;

                // envia msg 
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AlreadyLoggedIn);
            }
            else {
                // Envia mensagem que o usuário já está conectado
                LoginPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AlreadyLoggedIn);
            }
        }
    }
}
