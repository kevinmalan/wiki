using Wiki.Common;
using Wiki.Common.Requests.Company;
using Wiki.Common.Responses;
using Wiki.Core.HandlerRequests.Company;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace Wiki.API.Controllers
{
    [Authorize]
    public class CreateCompanyController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Company.Create)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCompanyAsync(
            [FromBody] CreateCompanyRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new CreateCompanyHandlerRequest
                {
                    Name = request.Name,
                    CreatorUniqueId = GetUserUniqueId()
                },
                cancellationToken
              );

            return OkEmptyApiResponse();
        }
    }
}