using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateCompanySignInHistoryHandlerRequest : IRequest
    {
        public Guid UniqueUserId { get; set; }
        public Guid UniqueCompanyId { get; set; }
    }
}