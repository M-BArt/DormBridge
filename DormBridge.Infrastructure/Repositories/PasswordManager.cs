using System.Security.Cryptography;
using DormBridge.Domain.Repositories;

namespace DormBridge.Infrastructure.Repositories
{
    internal sealed class PasswordManager : IPasswordManager
    {
        public (byte[], byte[]) CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA256 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordHash, passwordSalt);
        }

        public bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA256 hmac = new(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
