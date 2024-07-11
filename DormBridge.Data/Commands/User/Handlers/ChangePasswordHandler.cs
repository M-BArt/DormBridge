using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DormBridge.Application.Abstractions;
using DormBridge.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IUserRepository _userRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IPasswordManager _passwordManager;

        private string token;
        public ChangePasswordHandler(IUserRepository userRepository, IHttpContextAccessor contextAccessor, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _httpContextAccessor = contextAccessor;
            _passwordManager = passwordManager;
        }

        public async Task HandleAsyncAction(ChangePassword command)
        {
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
            JwtSecurityToken decryptedToken = tokenHandler.ReadJwtToken(token);

            var userId = decryptedToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userRepository.GetUserById(Guid.Parse(userId);

            if (!_passwordManager.VerifyHashPassword(command.currentPassword, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Invalid current password");

            _passwordManager.CreateHashPassword(command.newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.ChangePassword(passwordHash, passwordSalt);

            await _userRepository.UpdateAsync(user);
        }
    }
}

