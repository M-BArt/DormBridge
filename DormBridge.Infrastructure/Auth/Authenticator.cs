using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DormBridge.Application.Authenticator;
using DormBridge.Application.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DormBridge.Infrastructure.Auth
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
            _issuer = options.Value.JwtIssuer;
            _audience = options.Value.JwtAudience;
            _expiry = options.Value.JwtExpiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.JwtKey)), SecurityAlgorithms.HmacSha256);
        }
        public JsonWebTokenDTO CreateToken(Guid userId, string role)
        {
            var dataNow = DateTime.Now;
            var expiries = dataNow.Add(_expiry);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(_issuer, _audience, claims, dataNow, expiries, _signingCredentials);
            var accessToken = _jwtHandler.WriteToken(jwt);

            return new() { AccessToken = accessToken };
        }
    }
}
