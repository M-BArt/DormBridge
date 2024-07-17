using DormBridge.Application.Abstractions;
using DormBridge.Application.Authenticator;
using DormBridge.Application.Exceptions.User;
using DormBridge.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IHttpContextAccessor httpContextAccessor, IPasswordManager passwordManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
        }

        public async Task HandleAsyncAction(SignIn command)
        {
            var user = await _userRepository.GetUserByEmailAsync(command.Login) ?? throw new InvalidPasswordOrLogin();

            if (!_passwordManager.VerifyHashPassword(command.Password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidPasswordOrLogin();

            var token = _authenticator.CreateToken(user.UserGuid, user.Role);

            _httpContextAccessor.HttpContext?.Session.SetString("JWToken", token.AccessToken);

        }
    }
}
