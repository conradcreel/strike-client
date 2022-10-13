namespace StrikeClient
{
    public class StrikeApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public Exception? Exception { get; set; }
    }
}
