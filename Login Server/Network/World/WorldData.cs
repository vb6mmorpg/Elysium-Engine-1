using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;

namespace LoginServer.Network {
    public class WorldData {
        /// <summary>
        /// Chama o método de cada mensagem.
        /// </summary>
        /// <param name="index">Número do Servidor</param>
        /// <param name="data"></param>
        public static void HandleData(int index, NetIncomingMessage data) {
            // cabeçalho da msg
            var msg = data.ReadInt32();

            // verifica se está dentro da sequência
            if (msg < 0) { return; }

            // chama o método
            switch (msg) {
                case (int)PacketList.None: break;
                case (int)PacketList.LoginServer_WorldServer_IsPlayerConnected: Authentication.Login(index, data.ReadBoolean(), data.ReadString()); break;
            }
        }
    }
}
