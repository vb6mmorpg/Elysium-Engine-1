using LoginServer.MySQL;
using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;

namespace LoginServer.Network {
    public class LoginData {
        /// <summary>
        /// Manipulação de todas as mensagens
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        public static void HandleData(string hexID, NetIncomingMessage msg) {
            //se algum pacote estiver com menos que 4 bytes, retorna
            if (msg.LengthBytes < 4) { return; }

            var msgType = msg.ReadInt32();

            if (msgType < 0)  return;

            switch (msgType) {
                case (int)PacketList.Client_LoginServer_Login: Authentication.Login(hexID, msg); break;
                case (int)PacketList.Client_LoginServer_BackToLogin: Authentication.BackToLoginScreen(hexID); break;
                case (int)PacketList.Client_LoginServer_WorldServerConnect: WorldPacket.Login(hexID, msg.ReadInt32()); break;
            }
        }
    }
}
