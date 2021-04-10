using NSubstitute;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Requests;
using Wiki.Core.Services.Contracts;
using Wiki.Core.Services.Handlers.User;
using Xunit;

namespace Wiki.Tests.User
{
    public class GetUserDetailHandlerTests : BaseTest
    {
        [Fact]
        public async Task GetUserDetail_WhenUserExists_ShouldReturnUserResponse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "Test username";
            var queryServiceMock = Substitute.For<IQueryService>();
            queryServiceMock.GetUserAsync(userName, Arg.Any<CancellationToken>()).Returns(Task.FromResult(new Core.Models.User
            {
                Id = userId,
                UserName = userName
            }));
            var request = new GetUserDetailHandlerRequest
            {
                Username = userName
            };
            var handler = new GetUserDetailHandler(queryServiceMock);

            // Act
            var userResponse = await handler.Handle(request, new CancellationToken());

            // Assert
            userResponse.ShouldNotBeNull();
            userResponse.UserId.ShouldBe(userId);
            userResponse.UserName.ShouldBe(userName);
        }

        [Fact]
        public async Task GetUserDetail_WhenUserDoesNotExists_ShouldReturnNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var userName = "Test username";
            var queryServiceMock = Substitute.For<IQueryService>();
            var request = new GetUserDetailHandlerRequest
            {
                Username = userName
            };
            var handler = new GetUserDetailHandler(queryServiceMock);

            // Act
            var userResponse = await handler.Handle(request, new CancellationToken());

            // Assert
            userResponse.ShouldBeNull();
        }
    }
}