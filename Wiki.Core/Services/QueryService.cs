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

        public async Task<User> GetUserAsync(string userName, CancellationToken cancellationToken)
        {
            return await _dataContext.User
                .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        }

        public async Task<Guid> GetUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken)
        {
            return await _dataContext.UserRole
                .Where(r => r.Name == roleName)
                .Select(cr => cr.Id)
                .FirstAsync(cancellationToken);
        }

        public async Task<UserRoleName?> GetUserCompanyRoleAsync(Guid userId, Guid companyId, CancellationToken cancellationToken)
        {
            var companyRole = await _dataContext.UserRoleCompanyMap
                .Where(x => x.UserId == userId && x.CompanyId == companyId)
                .Select(x => new { x.UserRole.Name })
                .FirstOrDefaultAsync(cancellationToken);

            return companyRole?.Name;
        }

        public async Task<Guid> GetProjectScopeIdAsync(ProjectScopeName scope, CancellationToken cancellationToken)
        {
            return await _dataContext.ProjectScope
                .Where(ps => ps.Name == scope)
                .Select(ps => ps.Id)
                .FirstAsync(cancellationToken);
        }
    }
}