using DormBridge.Application.Commands.User;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class UserController
    {
        // POST: /user/change-password
        /// <summary>
        /// Action to change password  [Authorize]
        /// </summary>

        [HttpPost("/user/change-password")]
        [Authorize]
        [SwaggerOperation(Summary = "Action to change password. [Authorize]")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _changePasswordHandler.HandleAsyncAction(command);

                return Ok("Password updated");
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
