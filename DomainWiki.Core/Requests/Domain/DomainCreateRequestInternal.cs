using MediatR;
using System;

namespace DomainWiki.Core.Requests.Domain
{
    public class DomainCreateRequestInternal : IRequest
    {
        public string Name { get; set; }
        public Guid CreatorUniqueId { get; set; }
    }
}