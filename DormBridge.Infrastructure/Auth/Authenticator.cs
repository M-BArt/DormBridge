using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DormBridge.Application.Authenticator;
using DormBridge.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace DormBridge.Infrastructure.Auth
{
    internal class Authenticator : IAuthenticator
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiry;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtHandler = new JwtSecurityTokenHandler();
        private readonly HttpContextAccessor _httpContextAccessor;

        public Authenticator(IOptions<AuthenticatorOptions> options, HttpContextAccessor httpContextAccessor)
        {
            _issuer = options.Value.JwtIssuer;
            _audience = options.Value.JwtAudience;
            _expiry = options.Value.JwtExpiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.JwtKey)), SecurityAlgorithms.HmacSha256);
            _httpContextAccessor = httpContextAccessor;
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

        public JwtSecurityToken TakeTokenFromSession()
        {
            string token = string.Empty;

            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
            }
            else
            {
                token = _httpContextAccessor.HttpContext?.Session.GetString("JWToken") ?? string.Empty;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
