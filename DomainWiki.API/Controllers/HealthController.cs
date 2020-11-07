using Microsoft.AspNetCore.Mvc;

namespace DomainWiki.API.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"DomainWiki.API is running...");
        }
    }
}