using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Extensions;
using BookamApi.Data;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookamApi.Dtos.User;

namespace BookamApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<User?> deleteUser(string? username)
        {

#pragma warning disable CS8604 // Possible null reference argument.
            var user = await _userManager.FindByNameAsync(username);
#pragma warning restore CS8604 // Possible null reference argument.
            if (user == null) return null;

            await _userManager.DeleteAsync(user);
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User?> UpdateAsync(string? username, UpdateUserProfile update)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var user = await _userManager.FindByNameAsync(username);
#pragma warning restore CS8604 // Possible null reference argument.
            if (user == null) return null;

            if (!string.IsNullOrWhiteSpace(update.FullName))
                user.FullName = update.FullName;
    
            if (!string.IsNullOrWhiteSpace(update.Phone))
                user.Phone = update.Phone;
                
            if (!string.IsNullOrWhiteSpace(update.City))
                user.City = update.City;
                
            if (update.ZipCode != default)
                user.ZipCode = update.ZipCode;
                
            if (!string.IsNullOrWhiteSpace(update.Address))
                user.Address = update.Address;
                
            if (!string.IsNullOrWhiteSpace(update.State))
                user.State = update.State;

            await _userManager.UpdateAsync(user);

            return user;
        }
    }
}