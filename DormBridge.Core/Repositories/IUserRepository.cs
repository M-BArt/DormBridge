﻿using DormBridge.Domain.Entities;
using DormBridge.Domain.ValueObjects.User;

namespace DormBridge.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(Email Email);
        Task<User?> GetUserByNameAsync(string Username);
        Task AddAsync(User user);
    }
}
