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

namespace Wiki.API.Controllers.Project
{
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
        public async Task<IActionResult> CreateCompanyAsync([FromRoute] Guid companyUniqueId, [FromBody] CreateProjectRequest request)
        {
            // TODO:
            // Add a row on CompanyRole: AllowCreateProject (boolean)
            // Then Add validation attribute here
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