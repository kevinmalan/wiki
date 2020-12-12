using DomainWiki.Common;
using DomainWiki.Common.Requests.Domain;
using DomainWiki.Common.Responses;
using DomainWiki.Core.HandlerRequests.Company;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DomainWiki.API.Controllers
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
        [ProducesResponseType(typeof(EmptyApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCompanyAsync(CreateCompanyRequest request)
        {
            await _mediator.Send(
                new CreateCompanyHandlerRequest
                {
                    Name = request.Name,
                    CreatorUniqueId = GetUserUniqueId()
                }
              );

            return OkEmptyApiResponse();
        }
    }
}