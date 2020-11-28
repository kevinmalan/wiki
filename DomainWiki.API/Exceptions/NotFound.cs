using System;
using System.Net;

namespace DomainWiki.API.Exceptions
{
    public class NotFound : Exception
    {
        public HttpStatusCode Code { get; set; }

        public NotFound(string message) : base(message)
        {
            Code = HttpStatusCode.NotFound;
        }
    }
}