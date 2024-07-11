using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Application.Exceptions;

namespace DormBridge.Domain.Exceptions
{
    internal class InvalidPasswordException : BusinessException
    {
        public InvalidPasswordException() : base($"Incorrect password. The password must contain at least one uppercase letter, one lowercase letter, one digit, and be at least 8 characters long.") { }
    }
}
