using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.Exceptions.User
{
    public sealed class AccountAlreadyHasStudentStatus : BusinessException
    {
        public AccountAlreadyHasStudentStatus() : base($"Account already has student status."){}
    }
}
