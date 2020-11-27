using DomainWiki.Common.Requests;
using DomainWiki.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DomainWiki.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;

        public UserController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpGet("{username}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            return Ok(await userService.GetUserAsync(username));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            return Ok(await authService.RegisterAsync(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            return Ok(await authService.AuthenticateAsync(request));
        }
    }
}