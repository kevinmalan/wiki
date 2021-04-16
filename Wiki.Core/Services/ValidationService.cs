using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Services
{
    public class ValidationService : IValidationService
    {
        private readonly DataContext _dataContext;

        public ValidationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> HasLatestCompanySignInClaimsAsync(Guid uniqueUserId, Guid uniqueCompanyId)
        {
            var signInHistory = await _dataContext.CompanySignInHistory
                .Where(c => c.UserId == userId)
                .OrderBy(c => c.CreatedOn)
                .Select(c => new { c.CompanyId })
                .LastOrDefaultAsync();

            return signInHistory != null && signInHistory.CompanyId == companyId;
        }
    }
}