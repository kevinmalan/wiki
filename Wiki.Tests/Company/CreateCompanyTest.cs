using MediatR;
using Moq;
using NSubstitute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.HandlerRequests.Company;
using Wiki.Core.Handlers.Company;
using Wiki.Core.Services.Contracts;
using Xunit;

namespace Wiki.Tests.Company
{
    public class CreateCompanyTest : BaseTest
    {
        [Fact]
        public async Task CreateCompany_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var tokenMock = Substitute.For<ITokenService>();
            var handler = new CreateCompanyHandler(db, mediatorMock, tokenMock);
            var request = new CreateCompanyHandlerRequest
            {
                Name = "Test Company",
                UserId = Guid.NewGuid()
            };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            var company = db.Company.FirstOrDefault();
            company.ShouldNotBeNull();
            company.Name.ShouldBe(request.Name);
            company.CreatedOn.ShouldBeGreaterThan(new DateTimeOffset());
            company.CreatedById.ShouldBe(request.UserId);
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task CreateCompany_WhenMissingNameInRequest_ShouldThrowBadRequestException(string companyName)
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var tokenMock = Substitute.For<ITokenService>();
            var handler = new CreateCompanyHandler(db, mediatorMock, tokenMock);
            var request = new CreateCompanyHandlerRequest
            {
                Name = companyName,
                UserId = Guid.NewGuid()
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No name has been specified for the company.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }
    }
}