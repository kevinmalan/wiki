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

        public async Task<int> GetUserIdAsync(Guid uniqueUserId)
        {
            var user = await _dataContext.User
                .Where(u => u.UniqueId == uniqueUserId)
                .Select(u => new { u.Id })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new NotFoundException($"No user found with uniqueid '{uniqueUserId}'");
            }

            return user.Id;
        }

        public async Task<int> GetCompanyIdAsync(Guid uniqueCompanyId)
        {
            var user = await _dataContext.Company
                .Where(c => c.UniqueId == uniqueCompanyId)
                .Select(c => new { c.Id })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new NotFoundException($"No company found with uniqueid '{uniqueCompanyId}'");
            }

            return user.Id;
        }

        public async Task<int> GetUniqueUserRoleIdAsync(UserRoleName roleName, CancellationToken cancellationToken)
        {
            return await _dataContext.UserRole
                .Where(r => r.Name == roleName)
                .Select(cr => cr.Id)
                .FirstAsync(cancellationToken);
        }

        public async Task<UserRoleName?> GetUserCompanyRoleAsync(int userId, int companyId, CancellationToken cancellationToken)
        {
            var userCompanyRoleMap = await _dataContext.UserRoleCompanyMap
                .Where(x => x.UserId == userId && x.CompanyId == companyId)
                .Select(x => new { x.UserRoleId })
                .FirstOrDefaultAsync(cancellationToken);

            var userRoleName = await _dataContext.UserRole
                .Where(x => x.Id == userCompanyRoleMap.UserRoleId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();

            return userRoleName;
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