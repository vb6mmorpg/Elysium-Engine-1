using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginServer.Server {
    public struct IpBlock {
        /// <summary>
        /// Ip 
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Tempo de vida
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="time"></param>
        public IpBlock(string ipAddress, int time) {
            IpAddress = ipAddress;
            Time = time;
        }
    }
}
