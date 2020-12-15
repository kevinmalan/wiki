namespace Wiki.Common.Responses
{
    public class ApiResponse<T> where T : class
    {
        public T Payload { get; set; }
        public Error Error => null;

        public static ApiResponse<T> ToPayload(T payload = null)
        {
            return new ApiResponse<T>
            {
                Payload = payload ?? (T)new object()
            };
        }
    }

    public class ApiResponse
    {
        public class PayloadModel { }

        public PayloadModel Payload { get; set; } = new PayloadModel();
        public Error Error { get; set; }

        public static ApiResponse ToError(string errorMessage)
        {
            return new ApiResponse
            {
                Payload = null,
                Error = new Error
                {
                    Message = errorMessage
                }
            };
        }
    }
}