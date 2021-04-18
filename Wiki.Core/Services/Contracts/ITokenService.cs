using Wiki.Common.Enums;
using System;

namespace Wiki.Core.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateJwt(Guid uniqueUserId);

        string GenerateJwt(Guid uniqueUserId, Guid uniqueCompanyId, UserRoleName role);
    }
}