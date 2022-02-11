using System.Security.Cryptography;
using System.Text;

namespace GlutenFree.Login
{
    public static class EncryptionService
    {
        public static string Encrypt(string user, string password)
        {
            using var encryptionAlgorithm = SHA512.Create();

            byte[] input = Encoding.ASCII.GetBytes(user + password);

            byte[] result = encryptionAlgorithm.ComputeHash(input);

            string hashedString = BitConverter.ToString(result);
            hashedString = hashedString.Replace("-", "").ToLowerInvariant();

            return hashedString;
        }
    }
}
