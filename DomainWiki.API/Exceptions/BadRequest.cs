using System;
using System.Net;

namespace DomainWiki.API.Exceptions
{
    public class BadRequest : Exception
    {
        public HttpStatusCode Code { get; set; }

        public BadRequest(string message) : base(message)
        {
            Code = HttpStatusCode.BadRequest;
        }
    }
}