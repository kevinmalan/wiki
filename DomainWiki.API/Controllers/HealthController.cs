using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DomainWiki.API.Controllers
{
    public class HealthController : Controller
    {
        private readonly ILogger logger;

        public HealthController(ILogger<HealthController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation($"DomainWiki.API is running...");
            return Ok($"DomainWiki.API is running...");
        }
    }
}