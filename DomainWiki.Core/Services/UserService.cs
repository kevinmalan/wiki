using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Models;
using DomainWiki.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dbContext;

        public UserService(Contexts.DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserResponse> GetUserAsync(string userName)
        {
            var user = await dbContext.User
                            .Include(u => u.UserRole)
                            .SingleOrDefaultAsync(u => u.UserName == userName);

            return new UserResponse
            {
                UniqueId = user.UniqueId,
                UserName = user.UserName,
                Role = user.UserRole.Role
            };
        }

        public async Task<string> GetUserPasswordAsync(Guid uniqueId)
        {
            return await dbContext.User.Where(u => u.UniqueId == uniqueId).Select(u => u.Password).FirstAsync();
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