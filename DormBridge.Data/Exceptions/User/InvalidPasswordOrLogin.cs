using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Exceptions.User
{
    public sealed class InvalidPasswordOrLogin : Exception
    {
        public InvalidPasswordOrLogin() : base($"Invalid password or login"){ }
    }
}
