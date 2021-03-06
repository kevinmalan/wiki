using MediatR;
using NSubstitute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Exceptions;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Handlers.Project;
using Wiki.Core.Services.Contracts;
using Xunit;

namespace Wiki.Tests.Project
{
    public class CreatePeojectHandlerTests : BaseTest
    {
        [Fact]
        public async Task CreateProject_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var now = DateTimeOffset.UtcNow;
            var userId = 17;
            var companyId = 29;
            var mediatorMock = Substitute.For<IMediator>();
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(userId));
            queryServiceMock.GetCompanyIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(companyId));

            var request = new CreateProjectHandlerRequest
            {
                Name = "Test Project",
                UniqueCompanyId = Guid.NewGuid(),
                UniqueUserId = Guid.NewGuid()
            };
            var handler = new CreatePeojectHandler(db, mediatorMock, queryServiceMock);

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            var project = db.Project.FirstOrDefault();
            project.ShouldNotBeNull();
            project.UniqueId.ShouldBe(result.UniqueId);
            project.CreatedOn.ShouldBeGreaterThan(now);
            project.CreatedById.ShouldBe(userId);
            project.Name.ShouldBe(request.Name);
            project.CompanyId.ShouldBe(companyId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Createproject_WhenMissingNameInRequest_ShouldThrowBadRequestException(string projectName)
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var queryServiceMock = Substitute.For<IQueryService>();
            var handler = new CreatePeojectHandler(db, mediatorMock, queryServiceMock);
            var request = new CreateProjectHandlerRequest
            {
                Name = projectName,
                UniqueCompanyId = Guid.NewGuid(),
                UniqueUserId = Guid.NewGuid()
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No project name specified in request.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateProject_WhenEmptyGuidUserIdInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var queryServiceMock = Substitute.For<IQueryService>();
            var handler = new CreatePeojectHandler(db, mediatorMock, queryServiceMock);
            var request = new CreateProjectHandlerRequest
            {
                Name = "Test Project",
                UniqueCompanyId = Guid.NewGuid()
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No userId specified in request.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateProject_WhenEmptyGuidCompanyIdInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var mediatorMock = Substitute.For<IMediator>();
            var queryServiceMock = Substitute.For<IQueryService>();
            var handler = new CreatePeojectHandler(db, mediatorMock, queryServiceMock);
            var request = new CreateProjectHandlerRequest
            {
                Name = "Test Project",
                UniqueUserId = Guid.NewGuid()
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No CompanyId specified in request.");
            var company = db.Company.FirstOrDefault();
            company.ShouldBeNull();
        }
    }
}