﻿using IT_Community.Server.Infrastructure.Dtos.AuthDTOs;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        Task Register(UserRegisterDto userRegisterDto);
        Task<LoginAnswerDto> Login(UserLoginDto userLoginDto);
        Task Logout();
    }
}