using DormBridge.Application.DTOs.User;
using DormBridge.Application.Exceptions;
using DormBridge.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class UserController
    {
        // GET: /users
        /// <summary>
        /// Action to get a list of users.  [Authorize - Personel]
        /// </summary>

        [HttpGet("/users")]
        [Authorize(Roles = "personnel")]
        [SwaggerOperation(Summary =  "Action to get a list of users. [Authorize - Personel]")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] GetUsers query)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                
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
