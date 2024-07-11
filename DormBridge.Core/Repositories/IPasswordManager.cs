using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.Repositories
{
    public interface IPasswordManager
    {
        bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt);

        (byte[], byte[]) CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
