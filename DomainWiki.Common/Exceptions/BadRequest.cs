using System;
using System.Net;

namespace DomainWiki.Common.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest(string message) : base(message)
        {
        }
    }
}