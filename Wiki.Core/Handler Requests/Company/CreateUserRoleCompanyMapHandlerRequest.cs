using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateUserRoleCompanyMapHandlerRequest : IRequest
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public UserRoleName UserRoleName { get; set; }
    }
}