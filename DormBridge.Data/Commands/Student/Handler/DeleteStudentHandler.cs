using DormBridge.Application.Abstractions;
using DormBridge.Domain.Repositories;

namespace DormBridge.Application.Commands.Student.Handler
{
    public class DeleteStudentHandler : ICommandHandler<DeleteStudent>
    {
        private readonly IStudentRepository _studentRepository;       

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task HandleAsyncAction(DeleteStudent command)
        {
            
            var student = await _studentRepository.GetById(command.studentId) ?? throw new Exception("Student not exist");
            
            await _studentRepository.DeleteAsync(student);
        }
    }
}
 