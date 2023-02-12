using System.Security.Claims;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IUserService
    {
        Task<string> GetUserId(ClaimsPrincipal user);
        Task ChangePassword(string userId, string currentPassword, string newPassword);
        Task ChangeEmail(string userId, string currentPassword, string newEmail);
    }
}