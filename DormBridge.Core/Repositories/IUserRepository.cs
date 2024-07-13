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
        Task<User?> GetUserByStudentIdAsync(StudentAlbum StudentAlbum);

        Task AddAsync(User user);
        Task UpdateAsync(User user);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
