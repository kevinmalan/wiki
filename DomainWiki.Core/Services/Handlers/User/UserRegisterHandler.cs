using DomainWiki.Common.Enums;
using DomainWiki.Common.Exceptions;
using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Models;
using DomainWiki.Core.Requests;
using DomainWiki.Core.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Handlers
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterRequestInternal, LoginResponse>
    {
        private readonly IAuthService authService;
        private readonly DataContext dataContext;

        public UserRegisterHandler(
                    IAuthService authService,
                    DataContext dataContext)
        {
            this.authService = authService;
            this.dataContext = dataContext;
        }

        public async Task<LoginResponse> Handle(UserRegisterRequestInternal request, CancellationToken cancellationToken)
        {
            var userExists = await dataContext.User
                .AnyAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);

            if (userExists)
            {
                throw new BadRequest($"The username '{request.UserName}' is already taken.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var userRole = await dataContext.UserRole
                .SingleAsync(r => r.Role == Role.Member, cancellationToken: cancellationToken);
            var userCreated = await AddUserAsync(request.UserName, passwordHash, userRole);

            return new LoginResponse
            {
                Jwt = authService.GenerateJwt(userCreated.UniqueId, userCreated.UserName, userCreated.Role)
            };
        }

        private async Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole)
        {
            var uniqueId = Guid.NewGuid();

            await dataContext.User.AddAsync(new Models.User
            {
                UniqueId = uniqueId,
                UserName = userName,
                Password = password,
                UserRole = userRole
            });

            await dataContext.SaveChangesAsync();

            return new UserCreatedResponse
            {
                UserName = userName,
                Role = userRole.Role,
                UniqueId = uniqueId
            };
        }
    }
}