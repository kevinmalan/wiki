using DomainWiki.Common;
using DomainWiki.Common.Requests;
using DomainWiki.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers.Auth
{
    public class LoginController : BaseController
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Login)]
        [ProducesResponseType(typeof(ApiResponse<LoginResponse>), StatusCodes.Status200OK)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
        {
            return OkApiResponse(await _mediator.Send(request.ToInternal()));
        }
    }
}