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

            user.FullName = update.FullName;
            user.Phone = update.Phone;
            user.City = update.City;
            user.ZipCode = update.ZipCode;
            user.Address = update.Address;
            user.State = update.State;

            await _userManager.UpdateAsync(user);

            return user;
        }
    }
}