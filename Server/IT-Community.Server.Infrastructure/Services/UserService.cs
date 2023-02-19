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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using IT_Community.Server.Infrastructure.Utilities;

namespace IT_Community.Server.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserService(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task ChangeUserName(ClaimsPrincipal claimsPrincipal, string name)
        {
            var user = await _userManager.FindByIdAsync(await GetUserId(claimsPrincipal));

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var result = await _userManager.SetUserNameAsync(user, name);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task ChangePassword(ClaimsPrincipal claimsPrincipal, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(await GetUserId(claimsPrincipal));

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            if (!await _userManager.CheckPasswordAsync(user, currentPassword))
            {
                throw new HttpException("Invalid password.", HttpStatusCode.BadRequest);
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

        public async Task ChangeEmail(ClaimsPrincipal claimsPrincipal, string currentPassword, string newEmail)
        {
            var user = await _userManager.FindByIdAsync(await GetUserId(claimsPrincipal));

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            if (!await _userManager.CheckPasswordAsync(user, currentPassword))
            {
                throw new HttpException("Invalid password", HttpStatusCode.BadRequest);
            }

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var result = await _userManager.ChangeEmailAsync(user, newEmail, token);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }

        public async Task ChangeProfilePhoto(ClaimsPrincipal claimsPrincipal, IFormFile photo)
        {
            var user = await _userManager.FindByIdAsync(await GetUserId(claimsPrincipal));

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            if (photo == null)
            {
                throw new HttpException("The photo field is required.", HttpStatusCode.BadRequest);
            }

            if (user.ProfilePhoto == null)
            {
                user.ProfilePhoto = await SaveImage(photo);
            }
            else
            {
                DeleteImage(user.ProfilePhoto);
                user.ProfilePhoto = await SaveImage(photo);
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, "Profile", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var profileFolder = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, "Profile");
            var imagePath = Path.Combine(profileFolder, imageName);
            bool isExists = Directory.Exists(profileFolder);

            if (!isExists)
            {
                Directory.CreateDirectory(profileFolder);
            }

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }
    }
}