using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wiki.Common;
using Wiki.Common.Exceptions;
using Wiki.Core.Contexts;

namespace Wiki.API.Filters
{
    public class AllowCreateProjectFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;

        public AllowCreateProjectFilter(
            IHttpContextAccessor httpContextAccessor,
            DataContext dataContext
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userUniqueId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(Claims.UniqueId).Value);
            var companyUniqueId = (Guid)context.ActionArguments.First(a => a.Key == "companyUniqueId").Value;

            var createProjectPrivilege = await
                (from cc in _dataContext.CompanyUserCon // User and Company Role in a Company (FK-FK-FK)
                 join c in _dataContext.Company // The Company (PK)
                 on cc.CompanyId equals c.Id
                 join u in _dataContext.User // The User (PK)
                 on cc.UserId equals u.Id
                 join cr in _dataContext.CompanyRole // Company Roles (PK)
                 on cc.CompanyRoleId equals cr.Id
                 join crp in _dataContext.CompanyRolePrivilege // Company Role Privileges (FK-FK)
                 on cr.Id equals crp.CompanyRoleId
                 join p in _dataContext.Privilege // Privileges (PK)
                 on crp.PrivilegeId equals p.Id
                 where u.UniqueId == userUniqueId // Particular User
                 && c.UniqueId == companyUniqueId // Particular Company
                 && p.Action == Common.Enums.Action.CreateProject // Particular Prvilege
                 select new { p.Id })
                .FirstOrDefaultAsync();

            if (createProjectPrivilege is null)
            {
                throw new UnAuthorizedException("The current user lacks the required priviledges to create a project for this company.");
            }

            await next(); // Executes Action
        }
    }
}