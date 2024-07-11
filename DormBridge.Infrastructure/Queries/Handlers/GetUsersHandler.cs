using Azure.Core;
using System.Threading;
using DormBridge.Application.Abstractions;
using DormBridge.Application.DTOs.User;
using DormBridge.Application.Queries;
using DormBridge.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace DormBridge.Infrastructure.Queries.Handlers
{
    internal class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly DormBridgeDbContext _dbContext;

        public GetUsersHandler(DormBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserDto>> HandleAsyncAction(GetUsers query)
        {
            var skipCountItems = (query.PageNumber - 1) * query.PageSize;
            var count = await _dbContext.Users.CountAsync();
            var totalPageNumber = (int)Math.Ceiling(count / (double)query.PageSize);
            var items = await _dbContext.Users
                .OrderBy(u => u.Username)
                .Skip(skipCountItems)
                .Take(query.PageSize)
                .Select(u => new UserDto
                {
                    UserGuid = u.UserGuid,
                    Username = u.Username,
                    Email = u.Email,
                    StudentId = u.StudentId,
                    Role = u.Role,
                }).ToListAsync();          
            return items;
        }
    }
}
