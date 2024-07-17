using DormBridge.Application.Commands.Student;
using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class StudentController
    {
        /// <summary>
        /// Action to delete student account
        /// </summary>

        [HttpDelete("student/{studentId}")]
        [Authorize(Roles = "personnel")]
        [SwaggerOperation(Summary = "Action to delete student account")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid StudentId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _deleteStudentHandler.HandleAsyncAction(new DeleteStudent(StudentId));

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
