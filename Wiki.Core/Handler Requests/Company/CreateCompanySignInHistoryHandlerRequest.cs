using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateCompanySignInHistoryHandlerRequest : IRequest
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}