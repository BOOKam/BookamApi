using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.User;
using BookamApi.Models;

namespace BookamApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> deleteUser(string? username);
        Task<List<User>> GetAllUsersAsync();

        Task<User?> UpdateAsync(string? username, UpdateUserProfile update);
    }
}