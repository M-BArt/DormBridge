using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentByStudentIdAsync(StudentId studentId);
    }
}
