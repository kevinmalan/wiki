using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wiki.Common;
using Wiki.Core.Contexts;

namespace Wiki.API.Filters.ProjectScope
{
    public class HasProjectScopePrivilegeFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public HasProjectScopePrivilegeFilter(
            IHttpContextAccessor httpContextAccessor,
            DataContext dataContext,
             ILogger<HasProjectScopePrivilegeFilter> logger
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userUniqueId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(Claims.UniqueId).Value);
            var projectUniqueId = (Guid)context.ActionArguments.First(a => a.Key == "projectUniqueId").Value;
            var caller = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;

            bool parsed = Enum.TryParse(caller, out Common.Enums.Action action);

            if (!parsed) _logger.LogError($"Could not parse '{caller}' to '{nameof(Common.Enums.Action)}'");

            var projectUserCon = _dataContext
                .ProjectUserCon
                .Where(p =>
                   p.User.UniqueId == userUniqueId &&
                   p.Project.UniqueId == projectUniqueId);

            var hasPrivilege = await
                   (
                      from con in projectUserCon
                      join psp in _dataContext.ProjectScopePrivilege
                      on con.ProjectScopeId equals psp.ProjectScopeId
                      join p in _dataContext.Privilege
                      on psp.PrivilegeId equals p.Id
                      where p.Action == action
                      select con
                    ).AnyAsync();

            await next();
        }
    }
}