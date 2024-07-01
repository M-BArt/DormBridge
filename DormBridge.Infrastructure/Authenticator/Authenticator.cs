using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DormBridge.Application.DTOs.User;
using DormBridge.Infrastructure.Authenticator;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DormBridge.Application.Authenticatior
{
    internal class Authenticator : IAuthenticator
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiry;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtHandler = new JwtSecurityTokenHandler();

        public Authenticator(IOptions<AuthenticatorOptions> options)
        {
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigninKey)), SecurityAlgorithms.HmacSha256);
        }
        public JsonWebTokenDTO CreateToken(Guid userId, string role)
        {
            var dataNow = DateTime.Now;
            var expiries = dataNow.Add(_expiry);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(_issuer, _audience, claims, dataNow, expiries, _signingCredentials);
            var accessToken = _jwtHandler.WriteToken(jwt);

            return new() { AccessToken = accessToken };
        }
    }
}
