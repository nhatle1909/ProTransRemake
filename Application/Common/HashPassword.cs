using System.Security.Cryptography;

namespace Application.Common
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // 128 bits
        private const int KeySize = 32; // 256 bits
        private const int Iterations = 10000; // Recommended minimum for PBKDF2

        public static (string Hash, string Salt) HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                string saltBase64 = Convert.ToBase64String(salt);

                byte[] key = Rfc2898DeriveBytes.Pbkdf2(
                    password: password,
                    salt: salt,
                    iterations: Iterations,
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    outputLength: KeySize);
                string hashBase64 = Convert.ToBase64String(key);

                return (hashBase64, saltBase64);
            }
        }

        public static bool VerifyPassword(string password, string hashBase64, string saltBase64)
        {
            try
            {
                byte[] salt = Convert.FromBase64String(saltBase64);
                byte[] key = Rfc2898DeriveBytes.Pbkdf2(
                    password: password,
                    salt: salt,
                    iterations: Iterations,
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    outputLength: KeySize);
                byte[] hashToCompare = Convert.FromBase64String(hashBase64);

                return CryptographicOperations.FixedTimeEquals(key, hashToCompare);
            }
            catch (FormatException)
            {
                // Handle cases where the hash or salt might be in an invalid format
                return false;
            }
        }
    }
}
