using Wiki.Common.Enums;
using System;

namespace Wiki.Core.Services.Contracts
{
    public interface IAuthService
    {
        string GenerateJwt(Guid uniqueId, string userName, SystemRole role);
    }
}