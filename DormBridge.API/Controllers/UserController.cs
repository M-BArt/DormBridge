using System;
using System.ComponentModel.DataAnnotations;
using DormBridge.API.Filters;
using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Exceptions;
using DormBridge.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController<UserController>
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

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] SignUp command)
        {
            try
            {
                await _signUpHandler.HandleAsyncAction(command);
                return Ok("Create a new user");
            }
            catch (BusinessException ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }



        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] SignIn command)
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
            catch (BusinessException ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
        
        [HttpGet("/users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] GetUsers query)
        {
            try
            {
                return Ok(await _getUsersHandler.HandleAsyncAction(query));
            } 
            catch (BusinessException ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
