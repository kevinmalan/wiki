using MediatR;

namespace Wiki.Core.Handler_Requests.Company
{
    public class CreateCompanyUserConHandlerRequest : IRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyRoleId { get; set; }
    }
}