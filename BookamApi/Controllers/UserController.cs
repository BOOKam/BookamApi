using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.User;
using BookamApi.Extensions;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using BookamApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepo;
        public UserController(UserManager<User> userManager, IUserRepository userRepo)
        {
            _userManager = userManager;
            _userRepo = userRepo;
        }
    //    [Authorize(Roles = "Admin,User")]
        [HttpDelete("delete/{username?}")]
        public async Task<IActionResult> DeleteUser(string? username)
        {
            var currentUsername = User.GetUsername();
            // If not admin or username is null, delete self
            if (!User.IsInRole("Admin") || string.IsNullOrEmpty(username))
                username = currentUsername;

            var user = await _userRepo.deleteUser(username);
            if (user == null) return Error("User not found", null, "404");
            
            return Success(user.userProfile(), $"User {username} deleted");
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                if (users == null || !users.Any())
                    return Error("No users found", null, "404");

                return Success(users.Select(u => u.userProfile()), "Operation Successful");
            }
            catch (Exception ex)
            {
                return Error( "An error occurred while fetching users", ex, "500");
            }
        }

        // [Authorize(Roles = "Admin, User")]
        [HttpPatch("profile/{username?}")]
        public async Task<IActionResult> updateProfile(string? username, [FromBody] UpdateUserProfile update )
        {
            var currentUsername = User.GetUsername();
            // If not admin or username is null, delete self
            if (!User.IsInRole("Admin") || string.IsNullOrEmpty(username))
                username = currentUsername;

            var user = await _userRepo.UpdateAsync(username, update);
            if (user == null) return Error("User not found", null, "404");
            
            return Success(user.userProfile(), "User updated");
        }
    }
}