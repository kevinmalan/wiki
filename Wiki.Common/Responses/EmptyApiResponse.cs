namespace Wiki.Common.Responses
{
    public class EmptyApiResponse
    {
        public class EmptyPayloadObject { }

        public EmptyPayloadObject Payload => new EmptyPayloadObject();
        public Error Error { get; set; }
    }
}