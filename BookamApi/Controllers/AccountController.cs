using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Account;
using BookamApi.Interfaces;
using BookamApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult>  registerUser ([FromBody] RegisterDto register)
        {
            try {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new User
                {
                    /**
                    * i might need to add other user properities here
                    */

                    UserName = register.Username,
                    Email =  register.Email
                };
#pragma warning disable CS8604 // Possible null reference argument.
                var createuser = await _userManager.CreateAsync(user, register.Password);
#pragma warning restore CS8604 // Possible null reference argument.
                if (createuser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    /**
                    * i might need to add email verification here
                    */

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }
                        );
                    } else {
                        return StatusCode(500, roleResult.Errors);
                    }
                } else {
                    return StatusCode(500, createuser.Errors);
                }

            } catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }
        
    }
}