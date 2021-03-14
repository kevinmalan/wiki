using Wiki.Common;
using Wiki.Common.Requests;
using Wiki.Common.Responses;
using Wiki.Core.HandlerRequests.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using Wiki.API.Attributes;

namespace Wiki.API.Controllers.Auth
{
    public class RegisterController : BaseController
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Register)]
        [CompanySignInNotRequired]
        [ProducesResponseType(typeof(ApiResponse<SignInResponse>), StatusCodes.Status200OK)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(
                 new RegisterHandlerRequest
                 {
                     UserName = request.UserName,
                     Password = request.Password
                 },
                 cancellationToken
            );

            return OkApiResponse(response);
        }
    }
}