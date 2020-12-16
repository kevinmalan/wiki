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

        Task<int> GetCompanyIdAsync(Guid uniqueId, CancellationToken cancellationToken);

        Task<int> GetCompanyRoleIdAsync(Common.Enums.CompanyRole role, CancellationToken cancellationToken);

        Task<UserRole> GetUserRoleAsync(SystemRole role, CancellationToken cancellationToken);

        Task<User> GetUserAndRoleAsync(string username, CancellationToken cancellationToken);

        Task<int> GetProjectScopeIdAsync(Common.Enums.ProjectScope scope);
    }
}