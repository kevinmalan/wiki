using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateUserRoleCompanyMapHandlerRequest : IRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public UserRoleName UserRoleName { get; set; }
    }
}