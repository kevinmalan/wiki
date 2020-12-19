using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Models;

namespace Wiki.Core.Services.Contracts
{
    public interface IQueryService
    {
        Task<int> GetUserIdAsync(Guid uniqueId, CancellationToken cancellationToken);

        Task<User> GetUserAsync(string userName, CancellationToken cancellationToken);

        Task<int> GetCompanyIdAsync(Guid uniqueId, CancellationToken cancellationToken);

        Task<int> GetUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken);

        Task<int> GetProjectScopeIdAsync(ProjectScopeName projectScopeName, CancellationToken cancellationToken);
    }
}