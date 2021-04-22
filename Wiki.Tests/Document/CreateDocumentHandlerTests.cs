using NSubstitute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Handler_Requests.Document;
using Wiki.Core.Handlers.Document;
using Wiki.Core.Services.Contracts;
using Xunit;

namespace Wiki.Tests.Document
{
    public class CreateDocumentHandlerTests : BaseTest
    {
        [Fact]
        public async Task CreateDocument_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var now = DateTimeOffset.UtcNow;
            var userId = 28;
            var projectId = 4;
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(userId));
            queryServiceMock.GetProjectIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(projectId));
            var handler = new CreateDocumentHandler(queryServiceMock, db);
            var request = new CreateDocumentHandlerRequest
            {
                Title = "doc title",
                Name = "doc name",
                Content = "doc content",
                UniqueProjectId = Guid.NewGuid(),
                UniqueUserId = Guid.NewGuid()
            };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            var doc = db.Document.FirstOrDefault();
            doc.ShouldNotBeNull();
            doc.UniqueId.ShouldBe(result.UniqueId);
            doc.Title.ShouldBe(request.Title);
            doc.Name.ShouldBe(request.Name);
            doc.Content.ShouldBe(request.Content);
            doc.CreatedOn.ShouldBeGreaterThan(now);
            doc.CreatedById.ShouldBe(userId);
            doc.ProjectId.ShouldBe(projectId);
        }
    }
}