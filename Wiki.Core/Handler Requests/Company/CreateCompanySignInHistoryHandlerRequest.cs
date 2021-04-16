using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateCompanySignInHistoryHandlerRequest : IRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}