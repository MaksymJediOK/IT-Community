using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Resources;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace IT_Community.Server.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task Register(UserRegisterDto userRegisterDto)
        {
            var user = new User()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.UserName
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
            var userInDb = await _userManager.FindByEmailAsync(userRegisterDto.Email);

            var role = _roleManager.Roles.FirstOrDefault(x => x.NormalizedName == "COMMON");
            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("Common"));
            }
            await _userManager.AddToRoleAsync(userInDb, "Common");
        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
            {
                throw new HttpException(ErrorMessages.InvalidCredentials, HttpStatusCode.BadRequest);
            }

            await _signInManager.SignInAsync(user, userLoginDto.RememberMe);

            return await GenerateTokenAsync(user);

        }

        private async Task<string> GenerateTokenAsync(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            string role;
            if(roles.Count > 0)
            {
                role = roles[0];
            }
            else
            {
                role = "null";
            }    
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration.GetSection("Jwt:Lifetime").Value)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
