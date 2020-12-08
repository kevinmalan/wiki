using DomainWiki.API.Attributes;
using DomainWiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using static DomainWiki.Common.Constants;

namespace DomainWiki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    public class Controller : ControllerBase
    {
        protected IActionResult OkApiResponse(object payload = null)
        {
            return Ok(ApiResponse<object>.Format(payload));
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