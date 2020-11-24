using DomainWiki.Common.Requests;
using DomainWiki.Common.Responses;
using DomainWiki.Core.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static DomainWiki.Common.Constants;

namespace DomainWiki.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }

        public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
        {
            var user = await userService.GetUserAsync(request.UserName);
            if (user is not null)
            {
                throw new Exception($"The username '{request.UserName}' is already taken.");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var userCreated = await userService.AddUserAsync(request.UserName, passwordHash, "Member");

            return new LoginResponse
            {
                Jwt = GenerateJwt(userCreated.UniqueId, userCreated.UserName, userCreated.Role)
            };
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginRequest request)
        {
            var user = await userService.GetUserAsync(request.UserName);
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            if (user is null || passwordHash != user.Password)
            {
                throw new Exception($"No username and / or password match that criteria.");
            }

            return new LoginResponse
            {
                Jwt = GenerateJwt(user.UniqueId, user.UserName, user.Role)
            };
        }

        private string GenerateJwt(Guid uniqueId, string userName, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Jwt.SecretKey]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(Claims.UniqueId, uniqueId.ToString()),
                new Claim(Claims.UserName, userName),
                new Claim(Claims.Role, role)
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