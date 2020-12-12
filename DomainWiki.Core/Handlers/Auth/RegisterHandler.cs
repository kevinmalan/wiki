using DomainWiki.Common.Enums;
using DomainWiki.Common.Exceptions;
using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.HandlerRequests.Auth;
using DomainWiki.Core.Models;
using DomainWiki.Core.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterHandlerRequest, SignInResponse>
    {
        private readonly IAuthService _authService;
        private readonly DataContext _dataContext;

        public RegisterHandler(
                    IAuthService authService,
                    DataContext dataContext)
        {
            _authService = authService;
            _dataContext = dataContext;
        }

        public async Task<SignInResponse> Handle(RegisterHandlerRequest request, CancellationToken cancellationToken)
        {
            var userExists = await _dataContext.User
                .AnyAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);

            if (userExists)
            {
                throw new BadRequest($"The username '{request.UserName}' is already taken.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var userRole = await _dataContext.UserRole
                .SingleAsync(r => r.Role == Role.Member, cancellationToken: cancellationToken);
            var userCreated = await AddUserAsync(request.UserName, passwordHash, userRole);

            return new SignInResponse
            {
                Jwt = _authService.GenerateJwt(userCreated.UniqueId, userCreated.UserName, userCreated.Role)
            };
        }

        private async Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole)
        {
            var uniqueId = Guid.NewGuid();

            await _dataContext.User.AddAsync(new Models.User
            {
                UniqueId = uniqueId,
                UserName = userName,
                Password = password,
                UserRole = userRole
            });

            await _dataContext.SaveChangesAsync();

            return new UserCreatedResponse
            {
                UserName = userName,
                Role = userRole.Role,
                UniqueId = uniqueId
            };
        }
    }
}