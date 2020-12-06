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
        private readonly ILogger<UserController> logger;
        private readonly IMediator mediator;

        public UserController(
             ILogger<UserController> logger,
             IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet("{username}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            logger.LogInformation($"Username: {username} loading profile info.");
            return OkApiResponse(await mediator.Send(ToUserDetailsInternal(username)));
        }
    }
}