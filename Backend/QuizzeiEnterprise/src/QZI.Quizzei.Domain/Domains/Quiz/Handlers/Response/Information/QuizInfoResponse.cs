using System;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Information
{
    public class QuizInfoResponse
    {
        public Guid QuizInfoUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryDescription { get; set; }
        public int NumberOfQuestions { get; set; }
        public string OwnerEmail { get; set; }
    }
}