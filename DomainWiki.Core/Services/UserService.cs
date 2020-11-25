using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Models;
using DomainWiki.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services
{
    public class UserService : IUserService
    {
        private readonly Contexts.DataContext dbContext;

        public UserService(Contexts.DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await dbContext.User
                            .Include(u => u.UserRole)
                            .SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole)
        {
            var uniqueId = Guid.NewGuid();

            await dbContext.User.AddAsync(new User
            {
                UniqueId = uniqueId,
                UserName = userName,
                Password = password,
                UserRole = userRole
            });

            await dbContext.SaveChangesAsync();

            return new UserCreatedResponse
            {
                UserName = userName,
                Role = userRole.Role,
                UniqueId = uniqueId
            };
        }
    }
}