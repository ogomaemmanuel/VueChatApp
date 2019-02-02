using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VueChatApp.Features.AccessControl.Entities;
using VueChatApp.Features.AccessControl.Models;

namespace VueChatApp.Features.AccessControl.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private UserManager<SystemUser> _userManager;
        private SignInManager<SystemUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private IConfiguration _config;
        public AccountsController(UserManager<SystemUser> userManager,
          
           SignInManager<SystemUser> signInManager,
           RoleManager<AppRole> roleManager,
           IConfiguration config
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        // POST api/accounts
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName
                };
                
                IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                { 
                    var userViewModel = this.MapUserToViewModel(user);
                    return new OkObjectResult(userViewModel);
                }
            }

            return new BadRequestResult();

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("InvalidLogin", "User does not exist");
                    return new BadRequestObjectResult(ModelState);
                }
                if (!await _userManager.CheckPasswordAsync(user, loginViewModel.Password))
                {
                    ModelState.AddModelError("InvalidLogin", "Username and  password do not match");
                    return new BadRequestObjectResult(ModelState);
                }
                var token =  BuildToken(user);
                return new OkObjectResult(token);
            }
            return new BadRequestObjectResult(ModelState);

        }

        [HttpGet("confirm-email", Name = "ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {

            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return new OkObjectResult(result.Succeeded ? "Email Confirmation successful" : "Error");
        }


        [HttpGet("reset-password")]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return  View(model);
        }

        private  object BuildToken(SystemUser user)
        {

            var claims = new List<Claim> {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var epiryTime = DateTime.Now.AddHours(1);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: epiryTime,
              signingCredentials: creds);
            var authToken = new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = 60 * 60,
                UserDetails = new SystemUserViewModel
                {
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,


                }
            }; 
            return  authToken;
        }
        private SystemUserViewModel MapUserToViewModel(SystemUser user)
        {
            return new SystemUserViewModel
            {
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };
        }
    
}
}