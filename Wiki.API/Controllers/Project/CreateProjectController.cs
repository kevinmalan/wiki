using Wiki.Common;
using Wiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wiki.Common.Requests.Project;
using Wiki.Core.Handler_Requests.Project;
using System;
using Wiki.API.Filters;
using Microsoft.AspNetCore.Authorization;

namespace Wiki.API.Controllers.Project
{
    [Authorize]
    public class CreateProjectController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Project.Create)]
        [ServiceFilter(typeof(AllowCreateProjectFilter))]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProjectAsync([FromRoute] Guid companyUniqueId, [FromBody] CreateProjectRequest request)
        {
            await _mediator.Send(
                new CreateProjectHandlerRequest
                {
                    Name = request.Name,
                    CompanyUniqeId = companyUniqueId,
                    CreatorUniqueId = GetUserUniqueId()
                }
              );

            return OkEmptyApiResponse();
        }
    }
}