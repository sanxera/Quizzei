using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information
{
    public class GetQuizzesByCategoryResponse
    {
        public IList<QuizzesByCategory> QuizzesByCategories { get; set; } = new List<QuizzesByCategory>();
    }

    public class QuizzesByCategory
    {
        public string CategoryName { get; set; }
        public IList<QuizInfoResponse> QuizzesInfoResponses { get; set; } = new List<QuizInfoResponse>();
    }
}
