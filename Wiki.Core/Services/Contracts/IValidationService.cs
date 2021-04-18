using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Core.Services.Contracts
{
    public interface IValidationService
    {
        Task<bool> HasLatestCompanySignInClaimsAsync(int userId, int companyId);
    }
}