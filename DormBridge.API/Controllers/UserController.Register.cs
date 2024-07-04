using DormBridge.Application.Commands.User;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class UserController
    {
        // POST: /register
        /// <summary>
        /// Action to register a user.
        /// </summary>

        [HttpPost("/register")]
        [SwaggerOperation("Action to register a user.")]
        public async Task<IActionResult> Register([FromBody] SignUp command)
        {       
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _signUpHandler.HandleAsyncAction(command);
                
                return Ok("Successful user registration");
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
