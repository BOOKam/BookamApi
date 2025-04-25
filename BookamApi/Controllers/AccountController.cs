using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
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
        private readonly SignInManager<User> _signinManager;
        private readonly IEmailService _email;
        public AccountController(
            UserManager<User> userManager, 
            ITokenService tokenService, 
            SignInManager<User> signInManager, 
            IEmailService email
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _email = email;
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
                        // await SendConfirmationEmail(user.Email, user);
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
                return StatusCode(500, new { message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> login ([FromBody] LoginDto login)
        {
            try {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
#pragma warning disable CS8604 // Possible null reference argument.
                var user = await _userManager.FindByNameAsync(login.Username);
#pragma warning restore CS8604 // Possible null reference argument.
                if (user == null)
                {
                    return BadRequest("Invalid username or password");
                }
#pragma warning disable CS8604 // Possible null reference argument.
                var result = await _signinManager.CheckPasswordSignInAsync(user, login.Password, false);
#pragma warning restore CS8604 // Possible null reference argument.
                if (!result.Succeeded)
                {
                    return BadRequest("Invalid username or password");
                }
                return Ok(
                    new NewUserDto
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            } catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message, stackTrace = e.StackTrace });
            }
        }
        

        private async Task SendConfirmationEmail(string email, User user)
        {
            // Generate the email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Build the confirmation callback URL
            var confirmationLink = Url.Action("ConfirmEmail", "Account",
                new { UserId = user.Id, Token = token }, protocol: HttpContext.Request.Scheme);

            // Encode the link to prevent XSS and other injection attacks
            var safeLink = HtmlEncoder.Default.Encode(confirmationLink);

            // Craft a more polished email subject
            var subject = "Welcome to Dot Net Tutorials! Please Confirm Your Email";

            // Create a professional HTML body
            // Customize inline styles, text, and branding as needed
            var messageBody = $@"
                <div style=""font-family:Arial,Helvetica,sans-serif;font-size:16px;line-height:1.6;color:#333;"">
                    <p>Hi {user.UserName},</p>

                    <p>Thank you for creating an account at <strong>Dot Net Tutorials</strong>.
                    To start enjoying all of our features, please confirm your email address by clicking the button below:</p>

                    <p>
                        <a href=""{safeLink}"" 
                        style=""background-color:#007bff;color:#fff;padding:10px 20px;text-decoration:none;
                          font-weight:bold;border-radius:5px;display:inline-block;"">
                    Confirm Email
                        </a>
                    </p>

                    <p>If the button doesn’t work for you, copy and paste the following URL into your browser:
                        <br />
                        <a href=""{safeLink}"" style=""color:#007bff;text-decoration:none;"">{safeLink}</a>
                    </p>

                    <p>If you did not sign up for this account, please ignore this email.</p>

                    <p>Thanks,<br />
                    The Dot Net Tutorials Team</p>
                </div>
            ";

            //Send the Confirmation Email to the User Email Id
            await _email.SendEmailAsync(email, subject, messageBody, true);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Token))
            {
                // Provide a descriptive error message for the view
                return BadRequest("The link is invalid or has expired. Please request a new one if needed.");
                
            }

            //Find the User by Id
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                // Provide a descriptive error for a missing user scenario
                return BadRequest("We could not find a user associated with the given link.");
            }

            // Attempt to confirm the email
            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
            {
                return Ok("Thank you for confirming your email address. Your account is now verified!");
            }
            // If confirmation fails
            return StatusCode(500, "We were unable to confirm your email address. Please try again or request a new link.");
        } 

        [HttpGet("test-email")]
        public async Task<IActionResult> TestEmail()
        {
            try {
                await _email.SendEmailAsync("ochichiemerie@gmail.com", "Test Email", "This is a test email", false);
                return Ok("Email sent successfully");
            } catch (Exception ex) {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }
    }
}