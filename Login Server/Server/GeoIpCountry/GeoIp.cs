using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LoginServer.Server {
    public static class GeoIp {
        /// <summary>
        /// Tempo de vida, 5 minutos.
        /// </summary>
        private const int TIME = 300000;

        /// <summary>
        /// Ativa ou desativa a verificação do geoip.
        /// </summary>
        public static bool Enabled = false;

        /// <summary>
        /// Lista de endereços.
        /// </summary>
        private static HashSet<IpCountry> geoip = new HashSet<IpCountry>();

        /// <summary>
        /// LIsta de ip temporariamente bloqueados.
        /// </summary>
        private static HashSet<IpBlock> ip_block = new HashSet<IpBlock>();

        /// <summary>
        /// Lista de países bloqueados.
        /// </summary>
        private static List<string> country_block = new List<string>();

        /// <summary>
        /// Adiciona um país à lista de bloqueio.
        /// </summary>
        /// <param name="code"></param>
        public static void AddCountry(string code) {
            country_block.Add(code);
        }

        /// <summary>
        /// Realiza a comparação e retorna true quando um país está bloqueado.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsCountryIpBlocked(string ipAddress) {
            var country = FindCountryByIp(ipAddress);

            return (IsCountryBlocked(country.Code)) ? true : false;
        }

        /// <summary>
        /// Verifica se o código do país está na lista de bloqueio.
        /// </summary>
        /// <param name="country_code"></param>
        /// <returns></returns>
        private static bool IsCountryBlocked(string country_code) {
            var count = country_block.Count;

            for(var index = 0; index < count; index++) {
                if (country_block[index].CompareTo(country_code) == 0) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Realiza uma pesquisa pelo ip 
        /// </summary>
        /// <param name="ipNumber"></param>
        /// <returns></returns>
        public static IpCountry FindCountryByIp(string ipAddress) {
            var ipNumber = GetIPNumber(ipAddress);

            var find = from country in geoip
                       where (country.NumberMin <= ipNumber && country.NumberMax >= ipNumber)
                       select country;

            return find.FirstOrDefault();
        }

        /// <summary>
        /// Faz a soma dos valores e retorna o número do ip.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        private static long GetIPNumber(string ipAddress) {
            if (ipAddress == "::1") {
                ipAddress = "127.0.0.1";
            }

            string[] ips = ipAddress.Split('.');

            long w = long.Parse(ips[0]) * 16777216;
            long x = long.Parse(ips[1]) * 65536;
            long y = long.Parse(ips[2]) * 256;
            long z = long.Parse(ips[3]);

            long ipnumber = w + x + y + z;
            return ipnumber;
        }

        /// <summary>
        /// Abre o arquivo e obtem todos os dados.
        /// </summary>
        public static void ReadFile() {
            using (var fs = File.OpenRead(".\\GeoIPCountryWhois.csv"))
            using (var reader = new StreamReader(fs)) {
                while (!reader.EndOfStream) {
                    var values = reader.ReadLine().Split(',');

                    geoip.Add(new IpCountry(
                        values[0].Replace('"', ' ').Trim(),
                        values[1].Replace('"', ' ').Trim(),
                        Convert.ToInt64(values[2].Replace('"', ' ').Trim()),
                        Convert.ToInt64(values[3].Replace('"', ' ').Trim()),
                        values[4].Replace('"', ' ').Trim(),
                        values[5].Replace('"', ' ').Trim()));
                }
            }
        }

        #region Ip Block

        /// <summary>
        /// Adiciona um ip à lista de bloqueio.
        /// </summary>
        /// <param name="ipAddress"></param>
        public static void AddIpAddress(string ipAddress) {
            ip_block.Add(new IpBlock(ipAddress, Environment.TickCount));
        }

        /// <summary>
        /// Verifica se um ip está na lista de bloqueio.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsIpBlocked(string ipAddress) {
            var find = from ip in ip_block
                       where ip.IpAddress.CompareTo(ipAddress) == 0
                       select ip;

            return (string.IsNullOrEmpty(find.FirstOrDefault().IpAddress)) ? false : true;
        }

        /// <summary>
        /// Verifica se o tempo já expirou e remove da lista.
        /// </summary>
        public static void CheckIpBlockedTime() {
            foreach(var item in ip_block) {
                if (Environment.TickCount >= item.Time + TIME) { ip_block.Remove(item); }
            }
        }

        #endregion
    }
}
