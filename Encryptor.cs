using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors
{
    internal static class Encryptor
    {
        internal static string GenerateRandomKey()
        {
            byte[] keyArray = new byte[32];
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(keyArray); 
            return BitConverter.ToString(keyArray, 0).Replace("-", "");
        }

        internal static string GenerateHMAC(string computerMove)
        {
            string generatedKey = GenerateRandomKey();

            var encoding = new ASCIIEncoding();
            var computerMoveBytes = encoding.GetBytes(computerMove);
            var generatedKeyBytes = encoding.GetBytes(generatedKey);

            Byte[] hashBytes;

            using (var hash = new HMACSHA256(generatedKeyBytes))
                hashBytes = hash.ComputeHash(computerMoveBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}