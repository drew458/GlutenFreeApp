using System;
using System.Security.Cryptography;
using System.Text;

namespace GlutenFree.Login
{
    public static class EncryptionService
    {
        public static string Encrypt(string email, string password)
        {
            using var encryptionAlgorithm = SHA256.Create();

            byte[] input = Encoding.ASCII.GetBytes(email + password);

            byte[] result = encryptionAlgorithm.ComputeHash(input);

            string hashedString = BitConverter.ToString(result);
            hashedString = hashedString.Replace("-", "").ToLowerInvariant();

            return hashedString;
        }
    }
}
