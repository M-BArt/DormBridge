using DormBridge.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DormBridge.API.Controllers
{
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("/register")]
        [RequestValidation]
        public async Task<IActionResult> Register() { 

            try
            {
                await _userService.Register();
                return Ok("Create a new user");
            } catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }



        [HttpPost("/login")]
        [RequestValidation]
        public async Task<IActionResult> Login()
        {
            try
            {
                await _userService.Login();
                return Ok("User logged in");
            } catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
