using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IAuthService
    {
        Task Register(UserRegisterDto userRegisterDto);
        Task<string> Login(UserLoginDto userLoginDto);
        Task Logout();
    }
}
