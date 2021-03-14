using Wiki.Common.Enums;
using System;

namespace Wiki.Core.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateJwt(Guid userId);

        string GenerateJwt(Guid userId, Guid companyId, UserRoleName role);
    }
}