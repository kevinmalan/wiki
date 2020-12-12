using DomainWiki.API.Attributes;
using DomainWiki.Common;
using DomainWiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace DomainWiki.API.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    public class BaseController : ControllerBase
    {
        protected IActionResult OkEmptyApiResponse()
        {
            return Ok(new EmptyApiResponse());
        }

        protected IActionResult OkApiResponse<T>(T payload = null) where T : class
        {
            return Ok(ApiResponse<T>.Format(payload));
        }

        protected IActionResult BadRequestApiResponse(string message)
        {
            return BadRequest(ApiResponse<object>.Format(null, message));
        }

        protected Guid GetUserUniqueId()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;

            return Guid.Parse(claims.FindFirst(Claims.UniqueId).Value);
        }
    }
}