namespace Wiki.Common.Responses
{
    public class ApiResponse<T> where T : class
    {
        public T Payload { get; set; }
        public Error Error { get; set; } // Create non generic ApiResponse that handles error. The generic one will never assign errors.

        public static ApiResponse<T> Format(T payload = null, string errorMessage = null)
        {
            return new ApiResponse<T>
            {
                Payload = !string.IsNullOrEmpty(errorMessage) ? null : payload ?? (T)new object(),
                Error = string.IsNullOrEmpty(errorMessage) ? null : new Error
                {
                    Message = errorMessage
                }
            };
        }
    }
}