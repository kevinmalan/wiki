using Wiki.Common;
using Wiki.Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wiki.Common.Exceptions;

namespace Wiki.API.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : BaseController
    {
        private readonly ILogger _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Routes.Health.Get)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            _logger.LogInformation($"Wiki.API is running...");

            return OkEmptyApiResponse();
        }
    }
}