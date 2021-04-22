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
    public class CreateCompanyHandlerTests : BaseTest
    {
        [Fact]
        public async Task CreateCompany_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var now = DateTimeOffset.UtcNow;
            var userId = 17;
            var mediatorMock = Substitute.For<IMediator>();
            var tokenMock = Substitute.For<ITokenService>();
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(userId));

            var handler = new CreateCompanyHandler(db, mediatorMock, tokenMock, queryServiceMock);
            var request = new CreateCompanyHandlerRequest
            {
                Name = "Test Company",
                UniqueUserId = Guid.NewGuid()
            };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            var company = db.Company.FirstOrDefault();
            company.ShouldNotBeNull();
            company.UniqueId.ShouldBe((Guid)result.UniqueId);
            company.Name.ShouldBe(request.Name);
            company.CreatedOn.ShouldBeGreaterThan(now);
            company.CreatedById.ShouldBe(userId);
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
            var queryServiceMock = Substitute.For<IQueryService>();
            var handler = new CreateCompanyHandler(db, mediatorMock, tokenMock, queryServiceMock);
            var request = new CreateCompanyHandlerRequest
            {
                Name = companyName,
                UniqueUserId = Guid.NewGuid()
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No company name specified in request.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateCompany_WhenEmptyGuidUserIdInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var tokenMock = Substitute.For<ITokenService>();
            var queryServiceMock = Substitute.For<IQueryService>();
            var handler = new CreateCompanyHandler(db, mediatorMock, tokenMock, queryServiceMock);
            var request = new CreateCompanyHandlerRequest
            {
                Name = "Test Company",
                UniqueUserId = Guid.Empty
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No UniqueUserId specified in request.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }
    }
}