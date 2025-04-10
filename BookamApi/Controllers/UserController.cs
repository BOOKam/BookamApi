using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Extensions;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepo;
        public UserController(UserManager<User> userManager, IUserRepository userRepo)
        {
            _userManager = userManager;
            _userRepo = userRepo;
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> deleteUser()
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("User does not exist");
            await _userManager.DeleteAsync(user);

            return Ok();
        }
        
    }
}