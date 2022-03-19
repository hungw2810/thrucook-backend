using Sodium;
using System;
using System.Linq;
using System.Text;

namespace Thucook.Commons.Utils
{
    public static class StringHelper
    {
        private static readonly Random random = new Random();
        private static readonly byte[] nonce = Encoding.UTF8.GetBytes("KW^mSR7F@??Tnbn2E2%ABnQv"); //24 byte nonce
        private static readonly byte[] key = Encoding.UTF8.GetBytes("L&u=^T2S3kv%CP7qq3Qd5yPx+v!^XqD&"); //32 byte key

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Encrypt(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
            var cipherText  = SecretBox.Create(data, nonce, key);
            return Convert.ToBase64String(cipherText);
        }

        public static string Decrypt(string cipherTextBase64)
        {
            var cipherText = Convert.FromBase64String(cipherTextBase64);
            var data = SecretBox.Open(cipherText, nonce, key);
            return Encoding.UTF8.GetString(data);
        }
    }
}