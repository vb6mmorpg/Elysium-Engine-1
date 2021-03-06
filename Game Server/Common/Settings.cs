﻿namespace GameServer.Common {
    public class Settings {
        /// <summary>
        /// 
        /// </summary>
        public static string ID { get; set; }

        /// <summary>
        /// Server IP
        /// </summary>
        public static string IP { get; set; }

        /// <summary>
        /// Server Port
        /// </summary>
        public static int Port { get; set; }

        /// <summary>
        /// Connect Server Ip
        /// </summary>
        public static string LoginServerIP { get; set; }

        /// <summary>
        /// Connect Server Port
        /// </summary>
        public static int LoginServerPort { get; set; }


        public static string[] WorldServerID { get; set; }
        /// <summary>
        /// Connect Server Ip
        /// </summary>
        public static string WorldServerIP { get; set; }

        /// <summary>
        /// Connect Server Port
        /// </summary>
        public static int WorldServerPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int MaxConnection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int ConnectionTimeOut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static byte OnlinePlayer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool Logs { get; set; }

        public static int Sleep { get; set; }
    }
}
