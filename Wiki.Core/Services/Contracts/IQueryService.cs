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

        Task<Guid> GetUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken);

        Task<UserRoleName?> GetUserCompanyRoleAsync(Guid userId, Guid companyId, CancellationToken cancellationToken);

        Task<Guid> GetProjectScopeIdAsync(ProjectScopeName projectScopeName, CancellationToken cancellationToken);
    }
}