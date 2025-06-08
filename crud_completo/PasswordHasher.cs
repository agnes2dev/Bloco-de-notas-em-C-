using System;
using System.Security.Cryptography;
using System.Text;

namespace crud_completo
{
    public static class PasswordHasher
    {
        public static (string Hash, string Salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                string hash = Convert.ToBase64String(hashBytes);
                return (hash, salt);
            }
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + storedSalt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                string hashToVerify = Convert.ToBase64String(hashBytes);
                return hashToVerify == storedHash;
            }
        }
    }
}