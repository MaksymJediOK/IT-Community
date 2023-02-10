using System.Security.Claims;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IUserService
    {
        Task ChangePassword(string userId, string currentPassword, string newPassword);
        Task<string> GetUserId(ClaimsPrincipal user);
    }
}