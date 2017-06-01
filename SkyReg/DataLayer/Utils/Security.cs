using System;
using System.Security.Cryptography;
using System.Text;

namespace DataLayer.Utils
{
    public static class Security
    {
        public static readonly byte[] KeyIV = { 16, 19, 25, 213, 245, 146, 178, 99 };
        public static readonly byte[] KeySec = { 254, 1, 126, 89, 221, 13, 65, 150 };
        public static string DecryptString(this string stringIn)
        {
            string stringOut = string.Empty;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] IV = KeyIV;
            byte[] Key = KeySec;

            ICryptoTransform decryptor = des.CreateDecryptor(Key, IV);

            byte[] stringToBytes = Convert.FromBase64String(stringIn);
            byte[] decryptedstring = decryptor.TransformFinalBlock(stringToBytes, 0, stringToBytes.Length);
            stringOut = Encoding.UTF8.GetString(decryptedstring);

            return stringOut;
        }

        public static string EncryptString(this string stringIn)
        {
            string stringOut = string.Empty;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] IV = KeyIV;
            byte[] Key = KeySec;

            ICryptoTransform encryptor = des.CreateEncryptor(Key, IV);

            byte[] stringToBytes = ASCIIEncoding.ASCII.GetBytes(stringIn);
            byte[] encryptedstring = encryptor.TransformFinalBlock(stringToBytes, 0, stringToBytes.Length);
            stringOut = Convert.ToBase64String(encryptedstring);

            return stringOut;
        }
    }
}
