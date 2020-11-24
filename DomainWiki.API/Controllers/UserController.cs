using DomainWiki.Common.Requests;
using DomainWiki.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DomainWiki.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            return Ok(await authService.RegisterAsync(request));
        }

        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            return Ok(await authService.AuthenticateAsync(request));
        }
    }
}