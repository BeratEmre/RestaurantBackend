﻿using Core.Entities.concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsHaveAuthority(string token);
    }
}
