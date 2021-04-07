using MediatR;
using Moq;
using System;
using System.Threading;
using Wiki.Common.Enums;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Services.Contracts;

namespace Wiki.Tests.Company
{
    public class BaseCompanyTest : BaseTest
    {
        protected Mock<IMediator> mediatorMock;
        protected Mock<ITokenService> tokenMock;

        public BaseCompanyTest()
        {
            mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserRoleCompanyMapHandlerRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => Unit.Value);
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateCompanySignInHistoryHandlerRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => Unit.Value);

            tokenMock = new Mock<ITokenService>();
            tokenMock.Setup(m => m.GenerateJwt(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<UserRoleName>()))
                .Returns(string.Empty);
        }
    }
}