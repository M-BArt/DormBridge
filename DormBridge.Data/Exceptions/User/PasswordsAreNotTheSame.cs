using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Exceptions.User
{
    public sealed class PasswordsAreNotTheSame : Exception
    {
        public PasswordsAreNotTheSame() : base($"Passwords aren't the same")
        {

        }
    }
}
