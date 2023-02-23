using Microsoft.AspNetCore.Identity;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Resources;
using System.Net;
using IT_Community.Server.Core.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using IT_Community.Server.Infrastructure.Utilities;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using AutoMapper;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;

namespace IT_Community.Server.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public async Task<UserFullDto> GetUserInfo(string username)
        {
            var user = await GetUserByUserName(username);
            return _mapper.Map<UserFullDto>(user);
        }

        public async Task ChangeUserName(ClaimsPrincipal claimsPrincipal, string name)
        {
            var user = await GetUser(claimsPrincipal);
            var result = await _userManager.SetUserNameAsync(user, name);
            HandleResult(result);
        }

        public async Task ChangeName(ClaimsPrincipal claimsPrincipal, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new HttpException("The name field is required.", HttpStatusCode.BadRequest);
            }

            var user = await GetUser(claimsPrincipal);
            user.Name = name;
            var result = await _userManager.UpdateAsync(user);
            HandleResult(result);
        }

        public async Task ChangePassword(ClaimsPrincipal claimsPrincipal, string currentPassword, string newPassword)
        {
            var user = await GetUser(claimsPrincipal);

            if (!await _userManager.CheckPasswordAsync(user, currentPassword))
            {
                throw new HttpException("Invalid password.", HttpStatusCode.BadRequest);
            }

            if (currentPassword == newPassword)
            {
                throw new HttpException("New password cannot be the same as current password", HttpStatusCode.BadRequest);
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            HandleResult(result);
        }

        public async Task ChangeEmail(ClaimsPrincipal claimsPrincipal, string currentPassword, string newEmail)
        {
            var user = await GetUser(claimsPrincipal);

            if (!await _userManager.CheckPasswordAsync(user, currentPassword))
            {
                throw new HttpException("Invalid password", HttpStatusCode.BadRequest);
            }

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
            HandleResult(result);
        }

        public async Task ChangeBio(ClaimsPrincipal claimsPrincipal, string bio)
        {
            if (string.IsNullOrEmpty(bio))
            {
                throw new HttpException("The bio field is required.", HttpStatusCode.BadRequest);
            }

            var user = await GetUser(claimsPrincipal);
            user.Bio = bio;
            var result = await _userManager.UpdateAsync(user);
            HandleResult(result);
        }

        public async Task ChangeProfilePhoto(ClaimsPrincipal claimsPrincipal, IFormFile photo)
        {
            var user = await GetUser(claimsPrincipal);

            if (photo == null)
            {
                throw new HttpException("The photo field is required.", HttpStatusCode.BadRequest);
            }

            if (!IsImage(photo))
            {
                throw new HttpException("The file must be an image.", HttpStatusCode.BadRequest);
            }

            if (photo.Length > 5 * 1024 * 1024)
            {
                throw new HttpException("The file size must be at most 5 MB.", HttpStatusCode.BadRequest);
            }

            if (user.ProfilePhoto != null)
            {
                DeleteImage(user.ProfilePhoto);
            }

            user.ProfilePhoto = await SaveImage(photo);
            var result = await _userManager.UpdateAsync(user);
            HandleResult(result);
        }

        public async Task<User> GetUser(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            return user;
        }

        public async Task<User> GetUserByUserName(string username)
        {
            var user = _userManager.FindByNameAsync(username).Result;

            if (user == null)
            {
                throw new HttpException("Invalid username", HttpStatusCode.BadRequest);
            }

            return user;
        }

        public async Task<string> GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var user = await GetUser(claimsPrincipal);
            return user.Id;
        }

        private void HandleResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }

        private bool IsImage(IFormFile file)
        {
            return file.ContentType.StartsWith("image/");
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.usersImagesPath, imageName);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var profileFolder = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.usersImagesPath);
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