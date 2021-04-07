using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Handlers.Company;
using Xunit;

namespace Wiki.Tests.Company
{
    public class CreateCompanySignInTests : BaseTest
    {
        [Fact]
        public async Task CreateCompanySignIn_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var handler = new CreateCompanySignInHistoryHandler(db);
            var request = new CreateCompanySignInHistoryHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var signInHistory =
                db.CompanySignInHistory
                .FirstOrDefault(c => c.CompanyId == request.CompanyId && c.UserId == request.UserId);

            signInHistory.ShouldNotBeNull();
            signInHistory.CompanyId.ShouldBe(request.CompanyId);
            signInHistory.UserId.ShouldBe(request.UserId);
            signInHistory.CreatedOn.ShouldBeGreaterThan(new DateTimeOffset());
        }
    }
}