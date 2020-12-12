using Wiki.API.Attributes;
using Wiki.Common;
using Wiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Wiki.API.Controllers
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