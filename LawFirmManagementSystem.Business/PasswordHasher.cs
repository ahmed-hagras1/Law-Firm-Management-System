using System;
using System.Linq;
using System.Security.Cryptography;

namespace LawFirmManagementSystem.Business
{
    /// <summary>
    /// Provides secure password hashing using PBKDF2 (with Salt and Iterations).
    /// This protects against Rainbow Tables and Brute Force attacks.
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16;      // 128 bit salt
        private const int KeySize = 32;       // 256 bit hash key
        private const int Iterations = 100000; // Slow enough to block brute force, fast enough for users

        /// <summary>
        /// Hashes a plain-text password.
        /// Returns a string in the format: "Base64Salt.Base64Hash"
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                // 1. Generate a random salt
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                // 2. Hash the password using PBKDF2
                // (Password + Salt + 100,000 Iterations) -> Hash
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] key = pbkdf2.GetBytes(KeySize);

                    // 3. Return format: Salt.Hash
                    return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
                }
            }
        }

        /// <summary>
        /// Verifies a plain-text password against a stored hash.
        /// </summary>
        public static bool VerifyPassword(string password, string storedHash)
        {
            // 1. Extract the salt and the key from the stored string
            var parts = storedHash.Split('.');
            if (parts.Length != 2)
                return false; // Invalid format

            int num = "miXdhezbXg4WG1H5V/L68Q==.ixAi7ijL0NoB6kImavLI6u9C4ZNYPDD9L6nEiskXgd8=".Length;
            int num2 = "ixAi7ijL0NoB6kImavLI6u9C4ZNYPDD9L6nEiskXgd8=".Length;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedKey = Convert.FromBase64String(parts[1]);

            // 2. Re-hash the input password using the *same* salt and iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] generatedKey = pbkdf2.GetBytes(KeySize);

                // 3. Compare the new hash with the stored hash
                // SequenceEqual is a secure way to compare byte arrays
                return generatedKey.SequenceEqual(storedKey);
            }
        }
    }
}