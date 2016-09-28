using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace Elysium_Diamond.Common
{
    public class Settings
    {

        public static string CheckSumClient { get; set; }
        public static string LoginServerIP = "127.0.0.1";
        public static int LoginServerPort = 44405;

        public static string GameServerIP { get; set; }
        public static int GameServerPort { get; set; }

        public static string WorldServerIP { get; set; }
        public static int WorldServerPort { get; set; }

        public const string Version = "1.0.155";

        public static string HexID { get; set; }

        public static int pingStart, pingEnd, ping;
        public static bool pingSend = true;

        public static Language lang = Language.Portuguese;

        public static string GamePath = Environment.CurrentDirectory;
        public static bool Disconnected = false;
    }
}
