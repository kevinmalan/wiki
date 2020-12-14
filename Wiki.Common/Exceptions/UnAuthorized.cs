using System;

namespace Wiki.Common.Exceptions
{
    public class UnAuthorized : Exception
    {
        public UnAuthorized(string message) : base(message)
        {
        }
    }
}