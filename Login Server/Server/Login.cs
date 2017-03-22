using System;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.MySQL;

namespace LoginServer.Server {
    public class Login {
        public static int CPS { get; set; }
        private static int count, tick;

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

                // Verifica cada ip bloqueado, se o tempo expirou remove da lista
                GeoIp.CheckIpBlockedTime();

                if (Environment.TickCount >= tick + 1000) {
                    CPS = count;
                    tick = Environment.TickCount;
                    count = 0;
                }

                count++;
            }
            catch {

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
