using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Domain.Exceptions
{
    public sealed class InvalidEmailException : Exception
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: {email} is invalid.") {
            Email = email;
        }
    }
}
