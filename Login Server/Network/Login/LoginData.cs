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
        public static void HandleData(string hexID, NetIncomingMessage data) {
            var msgType = data.ReadInt32();

            if (msgType < 0)  return; 

            switch (msgType) {
                case (int)PacketList.Client_LoginServer_Login: Authentication.Login(hexID, data); break;
                case (int)PacketList.Client_LoginServer_BackToLogin: Authentication.BackToLogin(hexID); break;
                case (int)PacketList.Client_LoginServer_WorldServerConnect: WorldPacket.Login(hexID, data.ReadInt32()); break;
            }
        }
    }
}
