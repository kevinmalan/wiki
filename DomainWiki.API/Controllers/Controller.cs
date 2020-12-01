using DomainWiki.API.Attributes;
using DomainWiki.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DomainWiki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    public class Controller : ControllerBase
    {
        protected IActionResult OkApiResponse(object payload)
        {
            return Ok(ApiResponse<object>.Format(payload));
        }

        protected IActionResult BadRequestApiResponse(string message)
        {
            return BadRequest(ApiResponse<object>.Format(null, message));
        }
    }
}