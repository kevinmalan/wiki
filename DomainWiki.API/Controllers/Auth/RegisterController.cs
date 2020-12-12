﻿using DomainWiki.Common;
using DomainWiki.Common.Requests;
using DomainWiki.Common.Responses;
using DomainWiki.Core.HandlerRequests.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DomainWiki.API.Controllers.Auth
{
    public class RegisterController : BaseController
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth.Register)]
        [ProducesResponseType(typeof(ApiResponse<SignInResponse>), StatusCodes.Status200OK)]
        [SwaggerOperation(Tags = new[] { Swagger.Auth })]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var response = await _mediator.Send(
                 new RegisterHandlerRequest
                 {
                     UserName = request.UserName,
                     Password = request.Password
                 }
            );

            return OkApiResponse(response);
        }
    }
}