using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserFullDto> GetUserInfo(string username);
        Task<string> GetUserId(ClaimsPrincipal user);
        Task ChangePassword(ClaimsPrincipal claimsPrincipal, string currentPassword, string newPassword);
        Task ChangeEmail(ClaimsPrincipal claimsPrincipal, string currentPassword, string newEmail);
        Task ChangeProfilePhoto(ClaimsPrincipal claimsPrincipal, IFormFile photo);
        Task ChangeUserName(ClaimsPrincipal claimsPrincipal, string name);
        Task ChangeName(ClaimsPrincipal claimsPrincipal, string name);
        Task ChangeBio(ClaimsPrincipal claimsPrincipal, string bio);
    }
}