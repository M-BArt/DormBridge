using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Exceptions;
using DormBridge.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


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
        private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(
            ICommandHandler<SignUp> signUpHandler, 
            ICommandHandler<SignIn> signInHandler,
            IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersHandler,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _getUsersHandler = getUsersHandler;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
