using DormBridge.Application.Abstractions;
using DormBridge.Application.Authenticator;
using DormBridge.Application.DTOs.User;
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
            var user = await _userRepository.GetUserByEmailAsync(command.Login);

            var token = _authenticator.CreateToken(user.UserGuid, user.Role);

            _httpContextAccessor.HttpContext?.Items.TryAdd("JWT", token);     
        }
    }
}
