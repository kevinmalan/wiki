using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.API.Attributes;
using Wiki.Common;
using Wiki.Common.Responses;
using Wiki.Core.Handler_Requests.Company;

namespace Wiki.API.Controllers.Company
{
    [Authorize]
    public class SignInCompanyController : BaseController
    {
        private readonly IMediator _mediator;

        public SignInCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Company.SignIn)]
        [NotSignedIntoCompany]
        [ProducesResponseType(typeof(ApiResponse<SignInResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignInCompanyAsync(
            [FromRoute] Guid uniqueCompanyId,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(
                new SignInCompanyHandlerRequest
                {
                    UniqueCompanyId = uniqueCompanyId,
                    UniqueUserId = GetUniqueUserId()
                },
                cancellationToken
              );

            return OkApiResponse(response);
        }
    }
}