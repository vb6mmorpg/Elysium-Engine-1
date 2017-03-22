using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginServer.Server {
    public class IpCountry {
        /// <summary>
        /// Endereço inicial.
        /// </summary>
        public string IpFrom { get; set; }

        /// <summary>
        /// Endereço final.
        /// </summary>
        public string IpTo { get; set; }

        /// <summary>
        /// Número do ip, mínimo.
        /// </summary>
        public long NumberMin { get; set; }

        /// <summary>
        /// Número do ip, máximo.
        /// </summary>
        public long NumberMax { get; set; }

        /// <summary>
        /// Código do país
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// País.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="code"></param>
        /// <param name="country"></param>
        public IpCountry(string ipfrom, string ipto, long number_min, long number_max, string code, string country) {
            IpFrom = ipfrom;
            IpTo = ipto;
            NumberMin = number_min;
            NumberMax = number_max;
            Code = code;
            Country = country; 
        }
    }
}
