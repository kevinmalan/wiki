using NSubstitute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.HandlerRequests.Auth;
using Wiki.Core.Handlers.Company;
using Wiki.Core.Services.Contracts;
using Wiki.Core.Services.Handlers;
using Xunit;

namespace Wiki.Tests.Auth
{
    public class RegisterHandlerTests : BaseTest
    {
        [Fact]
        public async Task Register_WhenValidRequest_ShouldCreateDbRecord()
        {
            // Arrange
            var db = Db();
            var authTokenServiceMock = Substitute.For<ITokenService>();
            var handler = new RegisterHandler(authTokenServiceMock, db);
            var request = new RegisterHandlerRequest
            {
                UserName = "Test Username",
                Password = "Test123"
            };

            // Act

            await handler.Handle(request, new CancellationToken());

            // Assert
            var user = db.User.FirstOrDefault();
            user.ShouldNotBeNull();
            user.Password.ShouldNotBe(request.Password);
            BCrypt.Net.BCrypt.Verify(request.Password, user.Password).ShouldBeTrue();
            user.UserName.ShouldBe(request.UserName);
        }

        [Fact]
        public async Task Register_WhenUserAlreadyExists_ShouldThrowBadRequestException()
        {
            // Arrange
            var db = Db();
            db.User.Add(new Core.Models.User
            {
                UserName = "Test Username"
            });

            db.SaveChanges();

            var authTokenServiceMock = Substitute.For<ITokenService>();
            var handler = new RegisterHandler(authTokenServiceMock, db);
            var request = new RegisterHandlerRequest
            {
                UserName = "Test Username",
                Password = "Test123"
            };

            // Act
            var exception = await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(request, new CancellationToken()));

            // Assert
            exception.Message.ShouldBe($"The username '{request.UserName}' is already taken.");
            var users = db.User.ToList();
            users.Count.ShouldBe(1);
        }
    }
}