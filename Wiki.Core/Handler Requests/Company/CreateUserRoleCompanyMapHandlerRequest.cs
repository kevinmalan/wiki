using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateUserRoleCompanyMapHandlerRequest : IRequest
    {
        public Guid UniqueUserId { get; set; }
        public Guid UniqueCompanyId { get; set; }
        public UserRoleName UserRoleName { get; set; }
    }
}