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
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwt(Guid uniqueUserId)
        {
            var token = GetToken(new[]
            {
                new Claim(Claims.UniqueUserId, uniqueUserId.ToString()),
            });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJwt(Guid uniqueUserId, Guid uniqueCompanyId, UserRoleName role)
        {
            var token = GetToken(new[]
            {
                new Claim(Claims.UniqueUserId, uniqueUserId.ToString()),
                new Claim(Claims.UniqueCompanyId, uniqueCompanyId.ToString()),
                new Claim(Claims.Role, role.ToString())
            });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SecurityToken GetToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Jwt.SecretKey]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                    issuer: _configuration[Jwt.Issuer],
                    audience: _configuration[Jwt.Audiance],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_configuration[Jwt.ExpiresMinutes])),
                    signingCredentials: credentials
                );
        }
    }
}