using MediatR;
using System;
using Wiki.Common.Responses;

namespace Wiki.Core.Handler_Requests.Company
{
    public class SignInCompanyHandlerRequest : IRequest<SignInResponse>
    {
        public Guid UniqueCompanyId { get; set; }
        public Guid UniqueUserId { get; set; }
    }
}