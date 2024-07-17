using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.Student;

namespace DormBridge.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task UpdateAsync(Student studnet);
        Task DeleteAsync(Student studnet);
        Task<Student?> GetById(Guid studentId);

        Task<Student?> GetStudentByStudentAlbumAsync(StudentAlbum StudentAlbum);
    }
}
