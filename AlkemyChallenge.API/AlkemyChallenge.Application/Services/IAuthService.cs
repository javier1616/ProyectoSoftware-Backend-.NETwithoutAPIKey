using AlkemyChallenge.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace AlkemyChallenge.Application
{
    public interface IAuthService
    {
        public Users CreateUser(Users user);

        public JwtSecurityToken GetToken(Users user);
    }
}
