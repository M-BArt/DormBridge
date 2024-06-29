using DormBridge.Domain.Entities;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Domain.ValueObjects.User;
using DormBridge.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly DormBridgeDbContext _dbContext;

        public UserRepository(DormBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(Email email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByNameAsync(Username username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByStudentIdAsync(StudentId studentId)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.StudentId == studentId);
        }
    }
}
