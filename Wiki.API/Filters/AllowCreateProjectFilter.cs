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

            var connection = await
                (from cc in _dataContext.CompanyUserCon
                 join c in _dataContext.Company
                 on cc.CompanyId equals c.Id
                 join u in _dataContext.User
                 on cc.UserId equals u.Id
                 join cr in _dataContext.CompanyRole
                 on cc.CompanyRoleId equals cr.Id
                 where u.UniqueId == userUniqueId
                 && c.UniqueId == companyUniqueId
                 select new { cr.AllowCreateProject })
                .FirstOrDefaultAsync();

            if (connection is null || !connection.AllowCreateProject)
            {
                throw new UnAuthorizedException("The current user lacks the required priviledges to create a project for this company.");
            }

            await next(); // Executes Action
        }
    }
}