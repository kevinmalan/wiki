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
            var mediatorMock = Substitute.For<IMediator>();
            var request = new CreateProjectHandlerRequest
            {
                Name = "Test Project",
                UniqueCompanyId = Guid.NewGuid(),
                UniqueUserId = Guid.NewGuid()
            };
            var handler = new CreatePeojectHandler(db, mediatorMock);

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var project = db.Project.FirstOrDefault();
            project.ShouldNotBeNull();
            project.CreatedOn.ShouldBeGreaterThan(now);
            project.CreatedById.ShouldBe(request.UniqueUserId);
            project.Name.ShouldBe(request.Name);
            project.CompanyId.ShouldBe(request.UniqueCompanyId);
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
            var handler = new CreatePeojectHandler(db, mediatorMock);
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
            var handler = new CreatePeojectHandler(db, mediatorMock);
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
            var handler = new CreatePeojectHandler(db, mediatorMock);
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