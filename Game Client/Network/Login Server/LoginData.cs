using Elysium_Diamond.Common;
using Elysium_Diamond.EngineWindow;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public static class LoginData {
        /// <summary>
        /// Recebe o hexid a partir do servidor de login.
        /// </summary>
        /// <param name="hexid"></param>
        public static void HexID(string hexid) {
            Configuration.HexID = hexid;
        }

        /// <summary>
        /// Recebe a lista de canais.
        /// </summary>
        /// <param name="msg"></param>
        public static void ServerList(NetIncomingMessage msg) {
            for (int index = 0; index < Configuration.MAX_CHANNEL; index++) {
                WindowServer.Server[index].Name = msg.ReadString();
                WindowServer.Server[index].IP = msg.ReadString();
                WindowServer.Server[index].Port = msg.ReadInt32();
                WindowServer.Server[index].Region = msg.ReadString();
                WindowServer.Server[index].Status = msg.ReadString();
            }
        }
    }
}
