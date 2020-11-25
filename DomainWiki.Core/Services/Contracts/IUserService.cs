using DomainWiki.Common.Responses;
using DomainWiki.Core.Models;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string userName);

        Task<UserCreatedResponse> AddUserAsync(string userName, string password, UserRole userRole);
    }
}