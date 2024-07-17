using DormBridge.Application.Abstractions;
using DormBridge.Application.Commands.Student;
using DormBridge.Application.Commands.User;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Queries;
using DormBridge.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DormBridge.API.Controllers
{
    /// <summary>
    /// Values API Controller
    /// </summary>
    [ApiController]
    public partial class StudentController : BaseController<StudentController>
    {
        private readonly IStudentRepository _studentRepository;
        
        private readonly ICommandHandler<DeleteStudent> _deleteStudentHandler;

        public StudentController(ICommandHandler<DeleteStudent> deleteStudentHandler)
        {
            _deleteStudentHandler = deleteStudentHandler;
        }
    }
}
