using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Wiki.Core.Contexts;
using Wiki.Core.HandlerRequests.Auth;
using Wiki.Core.Models;
using Wiki.Core.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Core.Services.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterHandlerRequest, SignInResponse>
    {
        private readonly ITokenService _authService;
        private readonly DataContext _dataContext;

        public RegisterHandler(
           ITokenService authService,
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
                throw new BadRequestException($"The username '{request.UserName}' is already taken.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var userCreated = await AddUserAsync(request.UserName, passwordHash, cancellationToken);

            return new SignInResponse
            {
                Jwt = _authService.GenerateJwt(userCreated.UserId)
            };
        }

        private async Task<UserCreatedResponse> AddUserAsync(
            string userName,
            string password,
            CancellationToken cancellationToken)
        {
            var user = new Models.User
            {
                UserName = userName,
                Password = password,
            };

            await _dataContext.User.AddAsync(user, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new UserCreatedResponse
            {
                UserId = user.Id
            };
        }
    }
}