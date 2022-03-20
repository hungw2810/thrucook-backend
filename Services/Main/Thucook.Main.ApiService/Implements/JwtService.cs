using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Thucook.EntityFramework;
using Thucook.Main.ApiService.Models;

namespace Thucook.Main.ApiService.Implements
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwt(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, userInfo.UserName)
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
              _config["JwtSettings:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

