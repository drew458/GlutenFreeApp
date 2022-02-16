using System;
using System.Security.Cryptography;
using System.Text;

namespace GlutenFreeApp.Helpers
{
    public static class EncryptionService
    {
        public static string Encrypt(string email, string password)
        {
            var encryptionAlgorithm = SHA256.Create();

            byte[] input = Encoding.ASCII.GetBytes(email + password);

            byte[] result = encryptionAlgorithm.ComputeHash(input);

            string hashedString = BitConverter.ToString(result);
            hashedString = hashedString.Replace("-", "").ToLowerInvariant();

            return hashedString;
        }
    }
}
