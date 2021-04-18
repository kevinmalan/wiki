using NSubstitute;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Handlers.Project;
using Wiki.Core.Services.Contracts;
using Xunit;

namespace Wiki.Tests.Project
{
    public class CreateUserProjectScopeMapHandlerTests : BaseTest
    {
        [Fact]
        public async Task CreateUserProjectScopeMap_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var readDocumentProjectScopeId = 1;
            var createDocumentPorjectScopeId = 2;
            var editDocumentProjectScopeId = 3;
            var deleteDocumentProjectScopeId = 4;
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.ReadDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(readDocumentProjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.CreateDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(createDocumentPorjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.EditDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(editDocumentProjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.DeleteDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(deleteDocumentProjectScopeId));
            var request = new CreateUserProjectScopeMapHandlerRequest
            {
                ProjectId = 13,
                UserId = 29,
                ProjectScopeNames = new ProjectScopeName[]
                {
                    ProjectScopeName.ReadDocument,
                    ProjectScopeName.CreateDocument,
                    ProjectScopeName.EditDocument,
                    ProjectScopeName.DeleteDocument
                }
            };
            var handler = new CreateUserProjectScopeMapHandler(db, queryServiceMock);

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var userProjectScopeMaps = db.UserProjectScopeMap.ToList();
            userProjectScopeMaps.Count.ShouldBe(4);
            userProjectScopeMaps.Where(upsm => upsm.ProjectId == request.ProjectId && request.UserId == request.UserId).Count().ShouldBe(4);
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == readDocumentProjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == createDocumentPorjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == editDocumentProjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == deleteDocumentProjectScopeId).ShouldBeTrue();
        }

        [Fact]
        public async Task CreateUserProjectScopeMap_WhenMissingDeleteDocumentInRequest_ShouldCreateDbRecordWithoutDeleteDocumentProjectScopeId()
        {
            // Arrange
            var db = Db();
            var readDocumentProjectScopeId = 1;
            var createDocumentPorjectScopeId = 2;
            var editDocumentProjectScopeId = 3;
            var deleteDocumentProjectScopeId = 4;
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.ReadDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(readDocumentProjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.CreateDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(createDocumentPorjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.EditDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(editDocumentProjectScopeId));
            queryServiceMock.GetProjectScopeIdAsync(ProjectScopeName.DeleteDocument, Arg.Any<CancellationToken>()).Returns(Task.FromResult(deleteDocumentProjectScopeId));
            var request = new CreateUserProjectScopeMapHandlerRequest
            {
                ProjectId = 13,
                UserId = 29,
                ProjectScopeNames = new ProjectScopeName[]
                {
                    ProjectScopeName.ReadDocument,
                    ProjectScopeName.CreateDocument,
                    ProjectScopeName.EditDocument
                }
            };
            var handler = new CreateUserProjectScopeMapHandler(db, queryServiceMock);

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var userProjectScopeMaps = db.UserProjectScopeMap.ToList();
            userProjectScopeMaps.Count.ShouldBe(3);
            userProjectScopeMaps.Where(upsm => upsm.ProjectId == request.ProjectId && request.UserId == request.UserId).Count().ShouldBe(3);
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == readDocumentProjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == createDocumentPorjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == editDocumentProjectScopeId).ShouldBeTrue();
            userProjectScopeMaps.Any(upsm => upsm.ProjectScopeId == deleteDocumentProjectScopeId).ShouldBeFalse();
        }
    }
}