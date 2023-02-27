using IT_Community.Server.Infrastructure.Dtos.AuthDTOs;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        Task Register(UserRegisterDto userRegisterDto);
        Task<LoginAnswerDto> Login(UserLoginDto userLoginDto);
        Task Logout();
    }
}
