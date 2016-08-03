using GameServer.Common;
using GameServer.Network;
using System.Threading;

namespace GameServer.Server{
    public class ServerLoop {
        public static int tick;
    
        public static void Loop() {
            Authentication.VerifyHexID();

            Authentication.VerifyPlayerHexID();

            GameServerNetwork.ReceiveData();

            if (Settings.Sleep > 0) { Thread.Sleep(Settings.Sleep); }          
        }
    }
}
    
   

