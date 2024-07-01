using DormBridge.Application.Abstractions;
using DormBridge.Application.Authenticatior;
using DormBridge.Domain.Repositories;

namespace DormBridge.Application.Commands.User.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
        }

        public async Task HandleAsyncAction(SignIn command)
        {
            
            
            
            //string token = _authenticator.CreateToken();
        }
    }
}
