using MediatR;
using System;
using Wiki.Common.Responses;

namespace Wiki.Core.HandlerRequests.Company
{
    public class CreateCompanyHandlerRequest : IRequest<CompanySignInResponse>
    {
        public string Name { get; set; }
        public Guid UniqueUserId { get; set; }
    }
}