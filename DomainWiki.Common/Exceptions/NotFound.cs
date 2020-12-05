using System;

namespace DomainWiki.Common.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string message) : base(message)
        {
        }
    }
}