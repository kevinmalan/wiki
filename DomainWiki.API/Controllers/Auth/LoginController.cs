using DomainWiki.Common.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using static DomainWiki.Common.Constants;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers.Auth
{
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Login)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
        {
            return OkApiResponse(await _mediator.Send(request.ToInternal()));
        }
    }
}