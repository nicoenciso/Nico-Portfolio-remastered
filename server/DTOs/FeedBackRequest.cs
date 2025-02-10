namespace Server.DTOs
{
    public class FeedbackRequest
    {
        public required string Email { get; set; }
        public required string Rating { get; set; }
    }
}