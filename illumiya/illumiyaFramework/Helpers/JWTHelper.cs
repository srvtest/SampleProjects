using illumiyaFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace illumiyaFramework.Helpers
{
    public class JWTHelper
    {
        private Setting _settings;
        private IHttpContextAccessor _httpContextAccessor;

        public JWTHelper(IOptions<Setting> options, IHttpContextAccessor httpContextAccessor)
        {
            _settings = options.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public string SignInJWT(int id, string name, string email, string role , string ownerToken)
        {
            //generate token
            IdentityModelEventSource.ShowPII = true;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("Id", id.ToString()),
                    new Claim("Name", name),
                    new Claim("Email", email),
                    new Claim("Role", role),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public string GetClaim(string type)
        {
            return _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}
