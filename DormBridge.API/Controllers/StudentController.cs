using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DormBridge.API.Controllers
{
    /// <summary>
    /// Values API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public partial class StudentController : BaseController<StudentController>
    {
        public StudentController()
        {

        }
    }
}
