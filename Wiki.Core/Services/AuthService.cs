using Wiki.Common;
using Wiki.Common.Enums;
using Wiki.Core.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Wiki.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwt(Guid uniqueId, string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Jwt.SecretKey]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(Claims.UniqueUserId, uniqueId.ToString()),
                new Claim(Claims.UserName, userName),
            };

            var token = new JwtSecurityToken(
                    issuer: _configuration[Jwt.Issuer],
                    audience: _configuration[Jwt.Audiance],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_configuration[Jwt.ExpiresMinutes])),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}