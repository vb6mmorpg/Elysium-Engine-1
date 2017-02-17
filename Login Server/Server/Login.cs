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
                LoginNetwork.ReceivedData();

                // Verifica e tenta uma nova conexão com o world server
                WorldNetwork.WorldServerConnect();

                // Recebe os dados do world server
                WorldNetwork.WorldServerReceiveData();
            }
            catch (Exception e) {
                throw new Exception($"Ocorreu um erro: {e.Message}", e);
            }
        }

        /// <summary>
        /// Fecha todas as conexões.
        /// </summary>
        public static void Close() {
            //Não permite nenhuma conexão (evitar possíveis erros)
            Settings.CantConnectNow = true;
            Settings.Server = null;

            //Limpa as configurações
            Configuration.Clear();
            Authentication.Clear();
            LoginNetwork.Shutdown();
            WorldNetwork.Shutdown();
            CheckSum.Clear();

            //Fecha o arquivo de logs
            FileLog.CloseFileLog();
            Common_DB.Close();       
        }
    }
}
