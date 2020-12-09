using DomainWiki.Common.Requests.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DomainWiki.Common.Constants;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers
{
    [Authorize]
    public class CreateDomainController : Controller
    {
        private readonly IMediator _mediator;

        public CreateDomainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Domain.Create)]
        public async Task<IActionResult> Create(DomainCreateRequest request)
        {
            await _mediator.Send(request.ToInternal(GetUserUniqueId()));

            return OkApiResponse();
        }
    }
}