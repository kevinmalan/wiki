namespace DomainWiki.API.Exceptions
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string StatusCodeName { get; set; }
        public string Message { get; set; }
    }
}