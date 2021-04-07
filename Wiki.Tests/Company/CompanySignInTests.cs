using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Handlers.Company;
using Xunit;
using Shouldly;

namespace Wiki.Tests.Company
{
    public class CompanySignInTests : BaseTest
    {
        [Fact]
        public async Task CreateCompanySignIn()
        {
            var db = Db();

            var request = new CreateCompanySignInHistoryHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var handler = new CreateCompanySignInHistoryHandler(db);
            await handler.Handle(request, new CancellationToken());

            var signInHistory =
                db.CompanySignInHistory
                .Where(c => c.CompanyId == request.CompanyId && c.UserId == request.UserId)
                .FirstOrDefault();

            signInHistory.ShouldNotBeNull();
            signInHistory.CompanyId.ShouldBe(request.CompanyId);
            signInHistory.UserId.ShouldBe(request.UserId);
            signInHistory.CreatedOn.ShouldBeGreaterThan(new DateTimeOffset());
        }
    }
}