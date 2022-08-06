using AlkemyChallenge.Domain.Commands;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlkemyChallenge.Application
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersQueries _usersQueries;
        private readonly IGenericsRepository _repository;

        public AuthService(IConfiguration configuration,IUsersQueries userQueries, IGenericsRepository repository)
        {
            _configuration = configuration;
            _usersQueries = userQueries;
            _repository = repository;
        }

        public Users CreateUser(Users user)
        {

            _repository.Add<Users>(user);

            return user;

        }

        public JwtSecurityToken GetToken(Users user)
        {

            var usr = _usersQueries.GetUser(user);

            if (usr != null)
            {
                /*
                var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                            new Claim("UsersId", usr.UsersId.ToString()),
                            new Claim("Username", usr.Username),
                            new Claim("Password", usr.Password)
                };

                //create claims details based on the user information

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                      claims,
                    // expires: DateTime.UtcNow.AddMinutes(10),
                     expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signIn);*/

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim("Username", user.Username),
                new Claim("Password", user.Password),
            };

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(10),
                    signingCredentials: credentials);

                //return new JwtSecurityTokenHandler().WriteToken(token);


                return token;

            }

            return null;
        }
    }
}
