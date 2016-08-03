using System;
using System.Security.Cryptography;
using System.Text;

namespace GameServer.Common {
    public class Cryptography {
        static TripleDESCryptoServiceProvider pTripleDES = new TripleDESCryptoServiceProvider();
        static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        private static byte[] MD5H(string value) {
            byte[] Arr = ASCIIEncoding.ASCII.GetBytes(value);
            return md5.ComputeHash(Arr);
        }

        public static string Encrypt(string value) {
            try {
                pTripleDES.Key = MD5H(Settings.Key);
                pTripleDES.Mode = CipherMode.ECB;

                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(value);
                return Convert.ToBase64String(pTripleDES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch {
                return string.Empty;
            }
        }

        public static string Decrypt(string value) {
            try {
                pTripleDES.Key = MD5H(Settings.Key);
                pTripleDES.Mode = CipherMode.ECB;

                byte[] buffer = Convert.FromBase64String(value);
                return ASCIIEncoding.ASCII.GetString(pTripleDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch {
                return string.Empty;
            }
        }

        public static string GetSHA1(string hash) {
            SHA1CryptoServiceProvider cpObj = new SHA1CryptoServiceProvider();
            byte[] vaHash = Encoding.ASCII.GetBytes(hash);
            string tempVar = string.Empty;

            vaHash = cpObj.ComputeHash(vaHash);

            foreach (byte nH in vaHash) { tempVar += nH.ToString("x2"); }

            return tempVar.ToLower();
        }
    }
}
