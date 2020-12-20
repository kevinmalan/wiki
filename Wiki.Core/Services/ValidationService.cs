using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<bool> HasClaimsLatestCompanySignedInAsync(Guid uniqueUserId, Guid uniqueCompanyId)
        {
            var signInHistory = await _dataContext.CompanySignInHistory
                .Where(c => c.UserUniqueId == uniqueUserId)
                .OrderBy(c => c.CreatedOn)
                .Select(c => new { c.CompanyUniqueId })
                .LastOrDefaultAsync();

            return signInHistory != null && signInHistory.CompanyUniqueId == uniqueCompanyId;
        }
    }
}