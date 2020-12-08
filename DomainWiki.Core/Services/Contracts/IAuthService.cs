using DomainWiki.Common.Enums;
using System;

namespace DomainWiki.Core.Services.Contracts
{
    public interface IAuthService
    {
        string GenerateJwt(Guid uniqueId, string userName, Role role);
    }
}