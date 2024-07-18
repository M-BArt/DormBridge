using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Entities;
using DormBridge.Domain.Repositories;
using DormBridge.Infrastructure.DAL;

namespace DormBridge.Infrastructure.Repositories
{
    internal class RoomRepository : IRoomRepository
    {
        private readonly DormBridgeDbContext _dbDontext;
        public RoomRepository(DormBridgeDbContext dbDontext)
        {
            _dbDontext = dbDontext;
        }

        public async Task AddRoom(Room room)
        {
            await _dbDontext.AddAsync(room);
            await _dbDontext.SaveChangesAsync();
        }
    }
}
