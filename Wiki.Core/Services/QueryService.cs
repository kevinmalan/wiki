using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Contexts;
using Wiki.Core.Models;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Services
{
    public class QueryService : IQueryService
    {
        private readonly DataContext _dataContext;

        public QueryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> GetUserIdAsync(Guid uniqueId, CancellationToken cancellationToken)
        {
            return await _dataContext.User
                  .Where(u => u.UniqueId == uniqueId)
                  .Select(u => u.Id)
                  .FirstAsync(cancellationToken);
        }

        public async Task<User> GetUserAsync(string userName, CancellationToken cancellationToken)
        {
            return await _dataContext.User
                .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        }

        public async Task<int> GetCompanyIdAsync(Guid uniqueId, CancellationToken cancellationToken)
        {
            return await _dataContext.Company
                  .Where(c => c.UniqueId == uniqueId)
                  .Select(c => c.Id)
                  .FirstAsync(cancellationToken);
        }

        public async Task<int> GetUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken)
        {
            return await _dataContext.UserRole
                .Where(r => r.Name == roleName)
                .Select(cr => cr.Id)
                .FirstAsync(cancellationToken);
        }

        public async Task<int> GetProjectScopeIdAsync(ProjectScopeName scope, CancellationToken cancellationToken)
        {
            return await _dataContext.ProjectScope
                .Where(ps => ps.Name == scope)
                .Select(ps => ps.Id)
                .FirstAsync(cancellationToken);
        }
    }
}