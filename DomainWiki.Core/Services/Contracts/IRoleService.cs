using DomainWiki.Common.Enums;
using DomainWiki.Core.Models;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IRoleService
    {
        Task<UserRole> GetRoleAsync(Role role);
    }
}