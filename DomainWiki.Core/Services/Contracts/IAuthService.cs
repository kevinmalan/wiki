using DomainWiki.Common.Requests;
using DomainWiki.Common.Responses;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponse> RegisterAsync(RegisterRequest request);

        Task<LoginResponse> AuthenticateAsync(LoginRequest request);
    }
}