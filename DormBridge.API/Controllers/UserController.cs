using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Queries;
using Microsoft.AspNetCore.Mvc;


namespace DormBridge.API.Controllers
{
    /// <summary>
    /// Values API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public partial class UserController : BaseController<UserController>
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly ICommandHandler<ChangePassword> _changePasswordHandler;
        private readonly ICommandHandler<ActivateStudentAccount> _activateStudentAccountHandler;

        private readonly IQueryHandler<UserDto> _getProfileHanlder;
        private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersHandler;

        public UserController(ICommandHandler<SignUp> signUpHandler, ICommandHandler<SignIn> signInHandler, IQueryHandler<UserDto> getProfileHanlder, IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersHandler, ICommandHandler<ChangePassword> changePasswordHandler, ICommandHandler<ActivateStudentAccount> activateStudentAccountHandler)
        {    
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _getProfileHanlder = getProfileHanlder;
            _getUsersHandler = getUsersHandler;
            _changePasswordHandler = changePasswordHandler;
            _activateStudentAccountHandler = activateStudentAccountHandler;
        }
    }
}
