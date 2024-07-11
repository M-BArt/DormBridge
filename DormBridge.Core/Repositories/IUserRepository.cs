using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(Guid userId);
        Task<User?> GetUserByEmailAsync(Email Email);
        Task<User?> GetUserByNameAsync(Username Username);
        Task<User?> GetUserByStudentIdAsync(StudentId studentId);

        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
