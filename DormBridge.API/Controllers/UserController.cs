using System;
using DormBridge.API.Filters;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public class UserController : BaseController<UserController>
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ICommandHandler<SignUp> signUpHandler, ICommandHandler<SignIn> signInHandler, IHttpContextAccessor httpContextAccessor)
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("/register")]
        //[RequestValidation]
        [SwaggerOperation("Registration of new user")]
        public async Task<IActionResult> Register([FromBody] SignUp command)
        {
            try
            {
                await _signUpHandler.HandleAsyncAction(command);
                return Ok("Create a new user");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }



        [HttpPost("/login")]
        //[RequestValidation]
        [SwaggerOperation("User login")]
        public async Task<IActionResult?> Login([FromBody] SignIn command)
        {
            try
            {
                await _signInHandler.HandleAsyncAction(command);
                

                if (_httpContextAccessor.HttpContext.Items.TryGetValue("JWT", out var jwt))
                {
                    return Ok(jwt as JsonWebTokenDTO);
                }
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
