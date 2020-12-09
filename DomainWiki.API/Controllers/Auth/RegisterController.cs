using DomainWiki.Common.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using static DomainWiki.Common.Constants;
using static DomainWiki.Core.Maps.RequestMaps;

namespace DomainWiki.API.Controllers.Auth
{
    public class RegisterController : Controller
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Register)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request)
        {
            return OkApiResponse(await _mediator.Send(request.ToInternal()));
        }
    }
}