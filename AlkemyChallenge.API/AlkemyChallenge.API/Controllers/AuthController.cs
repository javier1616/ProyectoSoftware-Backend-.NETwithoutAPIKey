using AlkemyChallenge.Application;
using AlkemyChallenge.Application.Utils;
using AlkemyChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.API.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;
        private readonly ISendGrid _sendGridUtil;

        public AuthController(IAuthService service,ISendGrid util)
        {
            _service = service;
            _sendGridUtil = util;
        }

        [HttpPost("register")]
        public IActionResult Register(Users user)
        {
            if (user.Username != null && user.Password != null && user.Mail != null)
            {
                var usr = _service.CreateUser(user);

                if (usr != null)
                {
                    _sendGridUtil.SendMail(usr.Mail,"Register OK","<h1>Se ha registrado correctamente</h1>");
                    return StatusCode(201, usr);
                }
                else
                {
                    return StatusCode(400);
                }

            }

            return StatusCode(400);
        }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {

            if (user.Username != null && user.Password != null)
            {
                var token = _service.GetToken(user);

                if (token != null)
                {
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
