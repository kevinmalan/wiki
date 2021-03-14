using MediatR;
using System;
using Wiki.Common.Responses;

namespace Wiki.Core.Handler_Requests.Company
{
    public class SignInCompanyHandlerRequest : IRequest<SignInResponse>
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
    }
}