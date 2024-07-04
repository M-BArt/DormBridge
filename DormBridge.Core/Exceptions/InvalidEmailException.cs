using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Application.Exceptions;

namespace DormBridge.Domain.Exceptions
{
    public sealed class InvalidEmailException : BusinessException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: [{email}] is invalid. Use the correct email format.") {
            Email = email;
        }
    }
}
