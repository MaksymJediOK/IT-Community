using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Resources;
using System.Net;
using IT_Community.Server.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace IT_Community.Server.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserId(ClaimsPrincipal user)
        {
            string userId = "";
            var identity = user.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }

            if (userId.IsNullOrEmpty())
            {
                throw new HttpException("User id null", HttpStatusCode.BadRequest);
            }

            return userId;
        }

        public async Task ChangePassword(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null || !await _userManager.CheckPasswordAsync(user, currentPassword))
            {
                throw new HttpException(ErrorMessages.InvalidCredentials, HttpStatusCode.BadRequest);
            }

            if (currentPassword == newPassword)
            {
                throw new HttpException("New password cannot be the same as current password", HttpStatusCode.BadRequest);
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }
    }
}