using System;
using DormBridge.API.Filters;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public class UserController : BaseController<UserController>
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;

        public UserController(ICommandHandler<SignUp> signUpHandler)
        {
            _signUpHandler = signUpHandler;
        }

        [HttpPost("/register")]
        //[RequestValidation]
        [SwaggerOperation("Registration of new user")]
        public async Task<IActionResult> Register([FromBody] SignUp command)
        {
            if (command == null)
            {
                return NotFound(); // Zwraca kod 404 (Not Found), jeśli cygaro nie zostało znalezione
            }
            try
            {
                command = command with { UserGuid = Guid.NewGuid() };
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
        [RequestValidation]
        [SwaggerOperation("User login")]
        public async Task<IActionResult> Login()
        {
            try
            {

                return Ok("User logged in");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
