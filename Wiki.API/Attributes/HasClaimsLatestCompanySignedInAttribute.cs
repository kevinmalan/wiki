using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Wiki.Common;
using Wiki.Common.Exceptions;
using Wiki.Core.Services.Contracts;

namespace Wiki.API.Attributes
{
    public class HasClaimsLatestCompanySignedInAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var services = context.HttpContext.RequestServices;
            var validationService = services.GetService(typeof(IValidationService)) as IValidationService;
            var logger = services.GetService(typeof(ILogger)) as ILogger<HasClaimsLatestCompanySignedInAttribute>;
            var uniqueUserId = new Guid(context.HttpContext.User.FindFirst(Claims.UniqueUserId).Value);
            var uniqueCompanyId = new Guid(context.HttpContext.User.FindFirst(Claims.UniqueCompanyId).Value);

            var isValid = await validationService.HasClaimsLatestCompanySignedInAsync(uniqueUserId, uniqueCompanyId);

            if (!isValid)
            {
                logger.LogError($"Token Claims for unique user id: '{uniqueUserId}' and unique company id: '{uniqueCompanyId}' does not match the latest company signed into.");
                throw new UnAuthorizedException(null);
            }
        }
    }
}