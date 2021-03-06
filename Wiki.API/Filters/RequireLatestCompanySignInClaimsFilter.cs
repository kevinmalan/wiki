using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wiki.API.Attributes;
using Wiki.Common;
using Wiki.Common.Exceptions;
using Wiki.Core.Services.Contracts;

namespace Wiki.API.Filters
{
    public class RequireLatestCompanySignInClaimsFilter : IAsyncActionFilter
    {
        private readonly IValidationService _validationService;
        private readonly IQueryService _queryService;
        private readonly ILogger<RequireLatestCompanySignInClaimsFilter> _logger;

        public RequireLatestCompanySignInClaimsFilter(
            IValidationService validationService,
            IQueryService queryService,
            ILogger<RequireLatestCompanySignInClaimsFilter> logger)
        {
            _validationService = validationService;
            _queryService = queryService;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var attributes = descriptor.MethodInfo.CustomAttributes;

            if (attributes.Any(a => a.AttributeType == typeof(CompanySignInNotRequiredAttribute)))
            {
                await next();
                return;
            }

            var uniqueUserId = new Guid(context.HttpContext.User.FindFirst(Claims.UniqueUserId).Value);
            var uniqueCompanyId = new Guid(context.HttpContext.User.FindFirst(Claims.UniqueCompanyId).Value);
            var userId = await _queryService.GetUserIdAsync(uniqueUserId);
            var companyId = await _queryService.GetCompanyIdAsync(uniqueCompanyId);

            var isValid = await _validationService.HasLatestCompanySignInClaimsAsync(userId, companyId);

            if (!isValid)
            {
                _logger.LogError($"Token Claims for user id: '{uniqueUserId}' and company id: '{uniqueCompanyId}' does not match the latest company signed into.");
                throw new UnAuthorizedException("An outdated bearer token has been passed.");
            }

            await next();
        }
    }
}