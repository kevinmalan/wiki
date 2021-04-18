using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Models;

namespace Wiki.Core.Services.Contracts
{
    public interface IQueryService
    {
        Task<User> GetUserAsync(string userName, CancellationToken cancellationToken);

        Task<int> GetUserIdAsync(Guid uniqueUserId);

        Task<int> GetCompanyIdAsync(Guid uniqueCompanyId);

        Task<int> GetUniqueUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken);

        Task<UserRoleName?> GetUserCompanyRoleAsync(int userId, int companyId, CancellationToken cancellationToken);

        Task<int> GetProjectScopeIdAsync(ProjectScopeName projectScopeName, CancellationToken cancellationToken);
    }
}