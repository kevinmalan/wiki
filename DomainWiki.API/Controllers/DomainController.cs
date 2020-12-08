using DomainWiki.Common.Requests.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers
{
    [Authorize]
    public class DomainController : Controller
    {
        private readonly IMediator _mediator;

        public DomainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DomainCreateRequest request)
        {
            await _mediator.Send(request.ToInternal(GetUserUniqueId()));

            return OkApiResponse();
        }
    }
}