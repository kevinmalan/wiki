using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;

namespace Wiki.Core.Services.Contracts
{
    public interface IQueryService
    {
        Task<int> GetUserIdAsync(Guid uniqueId, CancellationToken cancellationToken);

        Task<int> GetCompanyIdAsync(Guid uniqueId, CancellationToken cancellationToken);

        Task<int> GetCompanyRoleIdAsync(CompanyRole role, CancellationToken cancellationToken);
    }
}