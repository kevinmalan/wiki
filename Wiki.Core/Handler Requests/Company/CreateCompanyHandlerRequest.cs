using MediatR;
using System;

namespace Wiki.Core.HandlerRequests.Company
{
    public class CreateCompanyHandlerRequest : IRequest
    {
        public string Name { get; set; }
        public Guid CreatorUniqueId { get; set; }
    }
}