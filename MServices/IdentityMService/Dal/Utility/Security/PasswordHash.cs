using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Utility.Security
{
    public static class PasswordHash
    {
        private const int SecurityFactor = 4;
        private const int SaltSize = 16 * SecurityFactor;
        private const int HashSize = 32 * SecurityFactor;
        private const int Iterations = 4;
        private const int MemorySizeKb = 1 << (16 * SecurityFactor);
        private const int DegreeOfParallelism = 4;

        public static (string HashBase64, string SaltBase64) CreatePasswordHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            var argon = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                MemorySize = MemorySizeKb,
                Iterations = Iterations
            };

            var hash = argon.GetBytes(HashSize);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public static bool VerifyPassword(string password, string storedHashBase64, string storedSaltBase64)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(storedHashBase64))
                throw new ArgumentNullException(nameof(storedHashBase64));
            if (string.IsNullOrWhiteSpace(storedSaltBase64))
                throw new ArgumentNullException(nameof(storedSaltBase64));

            var storedHash = Convert.FromBase64String(storedHashBase64);
            var salt = Convert.FromBase64String(storedSaltBase64);

            var argon = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                MemorySize = MemorySizeKb,
                Iterations = Iterations
            };

            var computedHash = argon.GetBytes(storedHash.Length);

            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }
    }
}