using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.HandlerRequests.Company;
using Wiki.Core.Handlers.Company;
using Xunit;

namespace Wiki.Tests.Company
{
    public class CreateCompanyTest : BaseCompanyTest
    {
        [Fact]
        public async Task CreateCompany()
        {
            var db = Db();

            var handler = new CreateCompanyHandler(db, mediatorMock.Object, tokenMock.Object);
            var request = new CreateCompanyHandlerRequest
            {
                Name = "Test Company",
                UserId = Guid.NewGuid()
            };

            var result = await handler.Handle(request, new CancellationToken());

            var company = db.Company.FirstOrDefault();
            company.ShouldNotBeNull();
            company.Name.ShouldBe(request.Name);
            company.CreatedOn.ShouldBeGreaterThan(new DateTimeOffset());
            company.CreatedById.ShouldBe(request.UserId);
            result.ShouldNotBeNull();
        }
    }
}