using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
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

        private async Task<int> GetUserIdAsync(Guid uniqueUserId)
        {
            var user = await _dataContext.User
                .Where(u => u.UniqueId == uniqueUserId)
                .Select(u => new { u.Id })
                .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new NotFoundException($"No user found with uniqueid '{uniqueUserId}'");
            }

            return user.Id;
        }

        public async Task<Guid> GetUniqueUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken)
        {
            return await _dataContext.UserRole
                .Where(r => r.Name == roleName)
                .Select(cr => cr.UniqueId)
                .FirstAsync(cancellationToken);
        }

        public async Task<UserRoleName?> GetUserCompanyRoleAsync(Guid uniqueUserId, Guid uniqueCompanyId, CancellationToken cancellationToken)
        {
            var userCompanyRoleMap = await _dataContext.UserRoleCompanyMap
                .Where(x => x.UniqueUserId == uniqueUserId && x.UniqueCompanyId == uniqueCompanyId)
                .Select(x => new { x.UniqueUserRoleId })
                .FirstOrDefaultAsync(cancellationToken);

            var userRoleName = await _dataContext.UserRole
                .Where(x => x.UniqueId == userCompanyRoleMap.UniqueUserRoleId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();

            return userRoleName;
        }

        public async Task<Guid> GetProjectScopeIdAsync(ProjectScopeName scope, CancellationToken cancellationToken)
        {
            return await _dataContext.ProjectScope
                .Where(ps => ps.Name == scope)
                .Select(ps => ps.UniqueId)
                .FirstAsync(cancellationToken);
        }
    }
}