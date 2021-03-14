using MediatR;
using System;
using Wiki.Common.Responses;

namespace Wiki.Core.HandlerRequests.Company
{
    public class CreateCompanyHandlerRequest : IRequest<SignInResponse>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}