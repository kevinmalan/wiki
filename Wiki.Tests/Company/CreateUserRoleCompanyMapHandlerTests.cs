using NSubstitute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Handlers.Company;
using Wiki.Core.Services.Contracts;
using Xunit;

namespace Wiki.Tests.Company
{
    public class CreateUserRoleCompanyMapHandlerTests : BaseTest
    {
        [Fact]
        public async Task CreateUserRoleCompanyMap_WhenValidAdminRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var adminRoleId = Guid.NewGuid();
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserRoleIdAsync(UserRoleName.Admin, new CancellationToken()).Returns(adminRoleId);

            var handler = new CreateUserRoleCompanyMapHandler(db, queryServiceMock);
            var request = new CreateUserRoleCompanyMapHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserRoleName = UserRoleName.Admin
            };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var userRoleCompanyMap = db.UserRoleCompanyMap.FirstOrDefault();
            userRoleCompanyMap.ShouldNotBeNull();
            userRoleCompanyMap.CompanyId.ShouldBe(request.CompanyId);
            userRoleCompanyMap.UserId.ShouldBe(request.UserId);
            userRoleCompanyMap.UserRoleId.ShouldBe(adminRoleId);
        }

        [Fact]
        public async Task CreateUserRoleCompanyMap_WhenValidMemberRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var memberRoleId = Guid.NewGuid();
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserRoleIdAsync(UserRoleName.Member, new CancellationToken()).Returns(memberRoleId);

            var handler = new CreateUserRoleCompanyMapHandler(db, queryServiceMock);
            var request = new CreateUserRoleCompanyMapHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserRoleName = UserRoleName.Member
            };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            var userRoleCompanyMap = db.UserRoleCompanyMap.FirstOrDefault();
            userRoleCompanyMap.ShouldNotBeNull();
            userRoleCompanyMap.CompanyId.ShouldBe(request.CompanyId);
            userRoleCompanyMap.UserId.ShouldBe(request.UserId);
            userRoleCompanyMap.UserRoleId.ShouldBe(memberRoleId);
        }

        [Fact]
        public async Task CreateUserRoleCompanyMap_WhenEmptyUserRoleInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var memberRoleId = Guid.NewGuid();
            var queryServiceMock = Substitute.For<IQueryService>();

            var handler = new CreateUserRoleCompanyMapHandler(db, queryServiceMock);
            var request = new CreateUserRoleCompanyMapHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No UserRole specified in request.");
            var company = db.UserRoleCompanyMap.FirstOrDefault();
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUserRoleCompanyMap_WhenEmptyUserIdInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var memberRoleId = Guid.NewGuid();
            var queryServiceMock = Substitute.For<IQueryService>();

            var handler = new CreateUserRoleCompanyMapHandler(db, queryServiceMock);
            var request = new CreateUserRoleCompanyMapHandlerRequest
            {
                CompanyId = Guid.NewGuid(),
                UserRoleName = UserRoleName.Admin
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No UserId specified in request.");
            var company = db.UserRoleCompanyMap.FirstOrDefault();
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUserRoleCompanyMap_WhenEmptyCompanyIdInRequest_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            var memberRoleId = Guid.NewGuid();
            var queryServiceMock = Substitute.For<IQueryService>();

            var handler = new CreateUserRoleCompanyMapHandler(db, queryServiceMock);
            var request = new CreateUserRoleCompanyMapHandlerRequest
            {
                UserId = Guid.NewGuid(),
                UserRoleName = UserRoleName.Admin
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe("No CompanyId specified in request.");
            var company = db.UserRoleCompanyMap.FirstOrDefault();
            company.ShouldBeNull();
        }
    }
}