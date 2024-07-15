using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Application.DTOs;

namespace DormBridge.Application.Authenticator
{
    public interface IAuthenticator
    {
        JsonWebTokenDTO CreateToken(Guid userId, string role);

        JwtSecurityToken TakeTokenFromSession();
    }
}
