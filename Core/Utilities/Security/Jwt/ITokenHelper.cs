﻿using Core.Entities.concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
        List<OperationClaim> DecodeToken(string token);
    }
}
