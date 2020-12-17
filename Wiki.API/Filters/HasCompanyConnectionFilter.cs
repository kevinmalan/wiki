using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wiki.Common;
using Wiki.Common.Exceptions;
using Wiki.Core.Contexts;

namespace Wiki.API.Filters
{
    public class HasCompanyConnectionFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public HasCompanyConnectionFilter(
            IHttpContextAccessor httpContextAccessor,
            DataContext dataContext,
             ILogger<HasCompanyConnectionFilter> logger
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

            var userId = await _dataContext.User
                .Where(u => u.UniqueId == userUniqueId)
                .Select(u => u.Id)
                .FirstAsync();

            var project = await _dataContext.Project
                .Where(p => p.UniqueId == projectUniqueId)
                .Select(p => new { p.CompanyId })
                .FirstOrDefaultAsync();

            if (project is null)
            {
                _logger.LogError($" No Project found for unique id '{projectUniqueId}'.");
                throw new NotFoundException($"No project found matching the specified route id.");
            }

            var hasCompanyConnection = await _dataContext.CompanyUserCon
                .AnyAsync(c => c.UserId == userId && c.CompanyId == project.CompanyId);

            if (!hasCompanyConnection)
            {
                _logger.LogError($"No company user connection found for company id '{project.CompanyId}' and user id '{userId}'");
                throw new UnAuthorizedException($"The current user has no connection to the project company.'");
            }

            await next();
        }
    }
}