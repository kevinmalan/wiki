using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers.User
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(
             ILogger<UserController> logger,
             IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{username}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            _logger.LogInformation($"Username: {username} loading profile info.");

            return OkApiResponse(await _mediator.Send(ToUserDetailsInternal(username)));
        }
    }
}