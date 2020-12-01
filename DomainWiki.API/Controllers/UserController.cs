using DomainWiki.Common.Requests;
using DomainWiki.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DomainWiki.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        private readonly ILogger logger;

        public UserController(IAuthService authService, IUserService userService, ILogger<UserController> logger)
        {
            this.authService = authService;
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet("{username}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            logger.LogInformation($"Username: {username} loading profile info.");
            var user = await userService.GetUserAsync(username);

            return OkApiResponse(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            return OkApiResponse(await authService.RegisterAsync(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            logger.LogInformation($"Username: {request.UserName} logging in.");
            return OkApiResponse(await authService.AuthenticateAsync(request));
        }
    }
}