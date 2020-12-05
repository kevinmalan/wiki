using DomainWiki.Common.Responses;
using DomainWiki.Core.Models;
using System;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IUserService
    {
        public Task<UserResponse> GetUserAsync(string userName);

        public Task<string> GetUserPasswordAsync(Guid uniqueId);

        public Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole);
    }
}