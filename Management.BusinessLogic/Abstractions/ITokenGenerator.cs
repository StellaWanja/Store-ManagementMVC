using Microsoft.IdentityModel.Tokens;
using Management.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Management.BusinessLogic
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}