using DormBridge.Application.Commands.Room;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class RoomController
    {

        /// <summary>
        /// Action to create new room
        /// </summary>

        [HttpPost("room/create-room")]
        [SwaggerOperation(Summary = "Action to create new room")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoom command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _createRoomHandler.HandleAsyncAction(command);

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
