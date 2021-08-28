using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private Account Account => new Account
        {
            Id = 1,
            UserName = "main4248",
            PasswordHash = "A093EF57181952F03A5C334FEAD5CC3A224306E0", //Y08IF5VZ
            Roles = new Role[] { Role.Admin }
        };

        //private readonly IUserRepository _userRepository;
        private readonly IOptions<AuthOptions.AuthOptions> _authOptions;

        public AuthController(
            //IUserRepository userRepository,
            IOptions<AuthOptions.AuthOptions> authOptions
            )
        {
            //_userRepository = userRepository;
            _authOptions = authOptions;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthentivateUser(request.UserName, request.Password);
            if (user != null)
            {
                //Create token
                var token = GenerateJWT(user);

                return Ok(new
                {
                    access_token = token
                });
            }
            return Unauthorized();
        }

        private Account AuthentivateUser(string login, string password)
        {
            var passwordHash = GetHash(password);
            var user = Account;
            if (user != null && user.UserName == login && user.PasswordHash == passwordHash)
            {
                Account account = new Account
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = user.Roles
                };
                return account;
            }
            return null;
        }

        private string GenerateJWT(Account account)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, account.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
            };
            foreach (var role in account.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

    }
}
