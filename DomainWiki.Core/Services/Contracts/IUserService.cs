using DomainWiki.Common.Responses;
using DomainWiki.Core.Models;
using System;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(string userName);

        Task<string> GetUserPasswordAsync(Guid uniqueId);

        Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole);
    }
}