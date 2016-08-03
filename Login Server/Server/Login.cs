using System;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.MySQL;

namespace LoginServer.Server {
    public class Login {
        /// <summary>
        /// Loop do servidor.
        /// </summary>
        public static void Loop() {
            try {
                // Recebe os dados do login server
                LoginServerNetwork.ReceivedData();

                // Verifica e tenta uma nova conexão com o world server
                WorldServerNetwork.WorldServerConnect();

                // Recebe os dados do world server
                WorldServerNetwork.WorldServerReceiveData();
            }
            catch (Exception e) {
                throw new Exception("Ocorreu um erro", e);
            }        
        }

        /// <summary>
        /// Fecha todas as conexões.
        /// </summary>
        public static void Close() {
            //Não permite nenhuma conexão (evitar possíveis erros)
            Settings.CantConnectNow = true;
            Settings.Server = null;

            //Fecha a db
            Common_DB.Disconnect();

            //Fecha os servidores world.
            WorldServerNetwork.Shutdown();

            //Fecha o servidor de login.
            LoginServerNetwork.Shutdown();

            //Fecha o arquivo de logs
            LogConfig.CloseFileLog();
        }
    }
}
