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
        private readonly DomainWikiDbContext dbContext;

        public UserService(DomainWikiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await dbContext.User.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<UserCreatedResponse> AddUserAsync(string userName, string password, string role)
        {
            var uniqueId = Guid.NewGuid();

            await dbContext.User.AddAsync(new User
            {
                UniqueId = uniqueId,
                UserName = userName,
                Password = password,
                Role = role
            });

            await dbContext.SaveChangesAsync();

            return new UserCreatedResponse
            {
                UserName = userName,
                Role = role,
                UniqueId = uniqueId
            };
        }
    }
}