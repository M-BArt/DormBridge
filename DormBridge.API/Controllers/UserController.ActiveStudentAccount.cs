using DormBridge.Application.Commands.User;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class UserController
    {
        /// <summary>
        /// Action to activate student account
        /// </summary>

        [HttpPost("user/activate-student-account")]
        [Authorize(Roles = "user")]
        [SwaggerOperation(Summary = "Action to activate student account")]
        public async Task<IActionResult> ActiveStudentAccount(ActivateStudentAccount command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _activateStudentAccountHandler.HandleAsyncAction(command);

                return Ok("Student account activated");
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
