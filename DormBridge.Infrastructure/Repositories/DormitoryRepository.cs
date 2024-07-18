using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Entities;
using DormBridge.Domain.Repositories;
using DormBridge.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.Repositories
{
    internal class DormitoryRepository : IDormitoryRepository
    {
        private readonly DormBridgeDbContext _dbContext;

        public DormitoryRepository(DormBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dormitory?> GetById(int dormitoryId)
        {
            return await _dbContext.Dormitories.SingleOrDefaultAsync(d => d.Id == dormitoryId);
        }
    }
}
