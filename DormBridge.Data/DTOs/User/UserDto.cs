using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Application.DTOs.User
{
    public class UserDto
    {
        public Guid userGuid { get; set; }
        
        public string Username { get; set; }

        public string Email { get; set; }
    }
}
