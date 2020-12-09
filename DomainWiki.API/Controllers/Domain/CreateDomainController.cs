using DomainWiki.Common;
using DomainWiki.Common.Requests.Domain;
using DomainWiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers
{
    [Authorize]
    public class CreateDomainController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateDomainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Domain.Create)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(DomainCreateRequest request)
        {
            await _mediator.Send(request.ToInternal(GetUserUniqueId()));

            return OkApiResponse();
        }
    }
}