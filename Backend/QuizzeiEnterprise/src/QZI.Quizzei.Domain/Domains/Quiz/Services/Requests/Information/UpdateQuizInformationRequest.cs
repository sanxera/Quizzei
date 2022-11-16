namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Requests.Information
{
    public class UpdateQuizInformationRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
