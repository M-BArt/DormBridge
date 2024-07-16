using DormBridge.Application.Commands.User.Handlers;
using DormBridge.Application.Commands.User;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class RoomController
    {
        /// <summary>
        /// Action to update room details
        /// </summary>

        [HttpPost("room/create-room")]
        [SwaggerOperation(Summary = "Action to update room details")]
        public async Task<IActionResult> UpdateRoom()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                //await _activateStudentAccountHandler.HandleAsyncAction(command);

                return Ok();
            }
            catch (BusinessException ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
