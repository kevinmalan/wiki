using Wiki.Common;
using Wiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wiki.Common.Requests.Project;
using Wiki.Core.Handler_Requests.Project;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using Wiki.API.Attributes;

namespace Wiki.API.Controllers.Project
{
    // HasClaimsLatestCompanySignedIn
    [HasClaimsLatestCompanySignedIn]
    //[Authorize(Policy = Policies.Admin)]
    public class CreateProjectController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Project.Create)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProjectAsync(
            [FromRoute] Guid companyUniqueId,
            [FromBody] CreateProjectRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new CreateProjectHandlerRequest
                {
                    Name = request.Name,
                    CompanyUniqeId = companyUniqueId,
                    CreatorUniqueId = GetUserUniqueId()
                },
                cancellationToken
              );

            return OkEmptyApiResponse();
        }
    }
}