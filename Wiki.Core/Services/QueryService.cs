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

        public async Task<int> GetCompanyIdAsync(Guid uniqueId, CancellationToken cancellationToken)
        {
            return await _dataContext.Company
                  .Where(c => c.UniqueId == uniqueId)
                  .Select(c => c.Id)
                  .FirstAsync(cancellationToken);
        }

        public async Task<int> GetCompanyRoleIdAsync(Common.Enums.CompanyRole role, CancellationToken cancellationToken)
        {
            return await _dataContext.CompanyRole
                .Where(cr => cr.Role == role)
                .Select(cr => cr.Id)
                .FirstAsync(cancellationToken);
        }

        public async Task<UserRole> GetUserRoleAsync(SystemRole role, CancellationToken cancellationToken)
        {
            return await _dataContext.UserRole
                .FirstAsync(ur => ur.Role == role, cancellationToken);
        }

        public async Task<User> GetUserAndRoleAsync(string username, CancellationToken cancellationToken)
        {
            return await _dataContext.User
                .Include(u => u.UserRole)
                .SingleOrDefaultAsync(u => u.UserName == username, cancellationToken: cancellationToken);
        }

        public async Task<int> GetProjectScopeIdAsync(Common.Enums.ProjectScope scope)
        {
            return await _dataContext.ProjectScope
                .Where(ps => ps.Scope == scope)
                .Select(ps => ps.Id)
                .FirstAsync();
        }
    }
}