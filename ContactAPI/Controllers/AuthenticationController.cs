using ContactAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using ContactAPI.Contracts;

namespace ContactAPI.Controllers
{
    public class AuthenticationController : Controller
    {
        private IConfiguration _config;
        private readonly ILoggerManager _logger;

        public AuthenticationController(IConfiguration config, ILoggerManager logger)
        {
            _config = config;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login is null)
            {
                _logger.LogError("Invalid login data.");
                return BadRequest("Invalid user request!!!");
            }

            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                _logger.LogDebug("tokenString : " + tokenString);
                response = Ok(new { token = tokenString });
            }

            return response;
        }


        private Login AuthenticateUser(Login login)
        {
            Login user = null;

            //Validate the User Credentials
            if (login.UserName == "admin")
            {
                user = new Login { UserName = "admin", Password = "admin" };
            }
            return user;
        }

        private string GenerateJSONWebToken(Login login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
