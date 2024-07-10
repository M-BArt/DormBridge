using System.Security.Cryptography;
using Azure;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Authenticator;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Exceptions.User;
using DormBridge.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _authenticator = authenticator;
        }

        public async Task HandleAsyncAction(SignIn command)
        {
            var user = await _userRepository.GetUserByEmailAsync(command.Login) ?? throw new InvalidPasswordOrLogin();

            if (!VerifyHashPassword(command.Password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidPasswordOrLogin();

            var token = _authenticator.CreateToken(user.UserGuid, user.Role);

            _httpContextAccessor.HttpContext?.Session.SetString("JWToken", token.ToString());

        }

        private static bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA256 hmac = new(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
