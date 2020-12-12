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
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateJwt(Guid uniqueId, string userName, Role role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Jwt.SecretKey]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(Claims.UniqueId, uniqueId.ToString()),
                new Claim(Claims.UserName, userName),
                new Claim(Claims.Role, role.ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: configuration[Jwt.Issuer],
                    audience: configuration[Jwt.Audiance],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(configuration[Jwt.ExpiresMinutes])),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}