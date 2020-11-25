using DomainWiki.Common.Enums;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Models;
using DomainWiki.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly DomainWikiDbContext domainWikiDbContext;

        public RoleService(DomainWikiDbContext domainWikiDbContext)
        {
            this.domainWikiDbContext = domainWikiDbContext;
        }

        public async Task<UserRole> GetRoleAsync(Role role)
        {
            return await domainWikiDbContext
                    .UserRole
                    .SingleAsync(r => r.Role == role.ToString());
        }
    }
}