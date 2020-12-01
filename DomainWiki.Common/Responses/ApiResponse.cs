namespace DomainWiki.Common.Responses
{
    public class ApiResponse<T> where T : class
    {
        public T Payload { get; set; }
        public Error Error { get; set; }

        public static ApiResponse<T> Format(T payload = null, string errorMessage = null)
        {
            return new ApiResponse<T>
            {
                Payload = payload ??  (T)new object(),
                Error = errorMessage is null ? null : new Error
                {
                    Message = errorMessage
                }
            };
        }
    }
}