using Wiki.Common.Responses;
using MediatR;

namespace Wiki.Common.Requests
{
    public class SignInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}