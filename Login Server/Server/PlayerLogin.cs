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
                LoginServerPacket.Message(hexID, (int)PacketList.LoginServer_Client_Maintenance);
                return;
            }

            //Verifica a versão do jogo
            var version = data.ReadString();
            //Quando 0, versão não especificada
            const string NO_VERSION = "0";
            if (Settings.Version.CompareTo(NO_VERSION) != 0 && Settings.Version.CompareTo(version) != 0) {
                    LoginServerPacket.Message(hexID, (int)PacketList.InvalidVersion);
                    return;
            }

            var pData = FindByHexID(hexID);
            pData.Username = data.ReadString().ToLower();     //lê o nome de usuário em uma variavel temporaria
            pData.Password = data.ReadString();               //lê a senha de usuário

            //Verifica se o usuário está na lista de banidos, caso verdadeiro, envia mensagem de erro
            if (Accounts_DB.BannedAccount(Accounts_DB.GetID(pData.Username))) {
                LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AccountBanned);
                return;
            }

            //Verifica se o nome existe no banco de dados, caso falso, envia a mensagem de erro
            if (!Accounts_DB.ExistAccount(pData.Username)) {
                LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_InvalidNamePass);
                return;
            }

            //Verifica se o usuário está ativo
            if (!Accounts_DB.IsActive(pData.Username)) { 
                LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AccountDisabled);
                return;
            }

            //Envia mensagem para outros servidores para saber se há algum usuario com o mesmo nome online
            if (WorldServerNetwork.IsWorldServerConnected())
                WorldServerPacket.IsPlayerConnected(pData.Username);
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
            if (pData.WorldResultCount == WorldServerNetwork.TotalOnline) {
                var result = false;

                //se achar o usuario conectado em algum lugar, muda result para true
                for (var n = 0; n < Settings.MAX_SERVER; n++) {
                    if (pData.WorldResult[index]) { result = true; }            
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
            if (!result) {
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
                LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_InvalidNamePass);
                return;
            }

            //muda o nome de usuario para o campo oficial de usuario
            pData.Account = pData.Username;
            pData.Username = string.Empty;

            LogConfig.WriteLog("User Login: " + pData.Account + " " + pData.IP); 
            LogConfig.WriteLog("User Login: " + pData.Account + " " + pData.IP, System.Drawing.Color.Black); 

            //obtem o id de usuario
            pData.ID = Accounts_DB.GetID(pData.Account);

            //carrega as informações da conta
            Accounts_DB.AccountData(pData);
            Accounts_DB.AccountService(pData);

            //verifica os serviços
            pData.Service.VerifyServices(pData.ID);

            Accounts_DB.UpdateDateLasteLogin(pData.Account);
            Accounts_DB.UpdateCurrentIP(pData.Account, pData.IP);
            Accounts_DB.UpdateLoggedIn(pData.Account, 1);  //1 = true

            //envia a lista de servidores e muda a tela no cliente
            LoginServerPacket.ServerList(pData.HexID);
            LoginServerPacket.GameState(pData.HexID, 2); //tela 2
        }

        /// <summary>
        /// Limpa os dados de usuário para voltar a tela de login
        /// </summary>
        /// <param name="index"></param>
        public static void BackToLogin(string hexID) {
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
            // se realizar mais que 2 tentativas de login, desconecta o usuário que já está logado e permite que o novo se conecte
            if (pData.LoginAttempt > 2) {

                //Desconecta o usuario em todos os servidores
                WorldServerPacket.PlayerDisconnect(pData.Username);
                //Desconecta o usuario no servidor de login (se houver)
                LoginServerPacket.Message(Authentication.FindByAccount(pData.Username).HexID, (int)PacketList.Disconnect);

                //limpa os dados do usuario conectado da lista para o novo login
                var playerData = Authentication.FindByAccount(pData.Username);
                playerData.Clear();

                // envia msg na terceira tentativa e limpa o contador
                if (pData.LoginAttempt == 3) {
                    pData.LoginAttempt = 0;
                    LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AlreadyLoggedIn);
                }
            }
            else {
                // Envia mensagem que o usuário já está conectado
                LoginServerPacket.Message(pData.HexID, (int)PacketList.LoginServer_Client_AlreadyLoggedIn);
            }
        }
    }
}
