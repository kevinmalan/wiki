using DomainWiki.Common;
using DomainWiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers.User
{
    public class GetUserDetailController : BaseController
    {
        private readonly ILogger<GetUserDetailController> _logger;
        private readonly IMediator _mediator;

        public GetUserDetailController(
             ILogger<GetUserDetailController> logger,
             IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Routes.User.ByUsername)]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(ApiResponse<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            _logger.LogInformation($"Username: {username} loading profile info.");

            return OkApiResponse(await _mediator.Send(ToUserDetailsInternal(username)));
        }
    }
}