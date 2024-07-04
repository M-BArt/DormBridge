using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class UserController
    {
        // POST: /login
        /// <summary>
        /// Action to log a user in.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        ///     Personnel
        ///     {
        ///        "login": "Personel@gmail.com",
        ///        "password": "Personel"
        ///     }
        ///      
        ///     User:
        ///     {
        ///        "login": "UserApiTest@gmail.com",
        ///        "password": "UserApiTest"
        ///     }
        /// </remarks>
        
        [HttpPost("/login")]
        [SwaggerOperation("Action to log a user in.")]
        public async Task<IActionResult> Login([FromBody] SignIn command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _signInHandler.HandleAsyncAction(command);

                return Ok("Successfully logged in");
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
