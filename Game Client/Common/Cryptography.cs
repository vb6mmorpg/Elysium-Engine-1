using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

public class Cryptography
{
    private static TripleDESCryptoServiceProvider pTripleDES = new TripleDESCryptoServiceProvider();
    private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    private const string sKey = "GameEngine";

    private static byte[] MD5H(string value)
    {
        byte[] Arr = ASCIIEncoding.ASCII.GetBytes(value);
        return md5.ComputeHash(Arr);
    }

    public static string Encrypt(string value)
    {
        try
        {
            pTripleDES.Key = MD5H(sKey);
            pTripleDES.Mode = CipherMode.ECB;

            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(value);
            return Convert.ToBase64String(pTripleDES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string Decrypt(string value)
    {
        try
        {
            pTripleDES.Key = MD5H(sKey);
            pTripleDES.Mode = CipherMode.ECB;

            byte[] buffer = Convert.FromBase64String(value);
            return ASCIIEncoding.ASCII.GetString(pTripleDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string GetSHA1(string hash)
    {
        SHA1CryptoServiceProvider cpObj = new SHA1CryptoServiceProvider();
        byte[] vaHash = Encoding.ASCII.GetBytes(hash);
        string tempVar = string.Empty;

        vaHash = cpObj.ComputeHash(vaHash);

        foreach (byte nH in vaHash) { tempVar += nH.ToString("x2"); }

        return tempVar.ToLower();
    }
}

