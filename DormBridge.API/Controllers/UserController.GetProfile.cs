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
        // GET: /user
        /// <summary>
        /// Action to get a users  [Authorize]
        /// </summary>

        [HttpGet("/user")]
        [Authorize]
        [SwaggerOperation(Summary = "Action to get a user. [Authorize]")]
        public async Task<ActionResult<UserDto>> GetProfile(NullQuery<UserDto> query)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                return Ok(await _getProfileHanlder.HandleAsyncAction(query));
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
