using DomainWiki.Common.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request)
        {
            return OkApiResponse(await _mediator.Send(request.ToInternal()));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
        {
            return OkApiResponse(await _mediator.Send(request.ToInternal()));
        }
    }
}