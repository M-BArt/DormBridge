using DormBridge.Domain.Entities;
using DormBridge.Domain.Repositories;
using DormBridge.Domain.ValueObjects.Student;
using DormBridge.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.Repositories
{
    internal sealed class StudentRepository : IStudentRepository
    {
        private readonly DormBridgeDbContext _dbContext;

        public StudentRepository(DormBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UpdateAsync(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Student?> GetStudentByStudentAlbumAsync(StudentAlbum studentAlbum)
        {
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.StudentAlbum == studentAlbum);
        }
    }
}
