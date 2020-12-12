using Wiki.Common;
using Wiki.Common.Requests;
using Wiki.Common.Responses;
using Wiki.Core.HandlerRequests.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Wiki.API.Controllers.Auth
{
    public class SignInController : BaseController
    {
        private readonly IMediator _mediator;

        public SignInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Login)]
        [ProducesResponseType(typeof(ApiResponse<SignInResponse>), StatusCodes.Status200OK)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> SignInAsync([FromBody] SignInRequest request)
        {
            var response = await _mediator.Send(
                new SignInHandlerRequest
                {
                    UserName = request.UserName,
                    Password = request.Password
                }
           );

            return OkApiResponse(response);
        }
    }
}