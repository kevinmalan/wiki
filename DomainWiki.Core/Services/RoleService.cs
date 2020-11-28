using DomainWiki.Common.Enums;
using DomainWiki.Core.Models;
using DomainWiki.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly Contexts.DataContext domainWikiDbContext;

        public RoleService(Contexts.DataContext domainWikiDbContext)
        {
            this.domainWikiDbContext = domainWikiDbContext;
        }

        public async Task<UserRole> GetRoleAsync(Role role)
        {
            return await domainWikiDbContext
                    .UserRole
                    .SingleAsync(r => r.Role == role);
        }
    }
}