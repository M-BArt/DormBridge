using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class StudentController
    {
        /// <summary>
        /// Action to delete student account
        /// </summary>

        [HttpPost("student/{studentId}")]
        [SwaggerOperation(Summary = "Action to delete student account")]
        public async Task<IActionResult> DeleteStudent()
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
