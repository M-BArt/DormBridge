﻿using DormBridge.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DormBridge.API.Controllers
{
    public partial class StudentController
    {
        /// <summary>
        /// Action to add new student
        /// </summary>

        [HttpPost("student/change-profile")]
        [SwaggerOperation(Summary = "Action to add new student")]
        public async Task<IActionResult> AddStudent()
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
