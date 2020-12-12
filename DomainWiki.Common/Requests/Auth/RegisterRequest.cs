using DomainWiki.Common.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DomainWiki.Common.Requests
{
    public class RegisterRequest
    {
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Username length must be between 5 and 100 characters.")]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}