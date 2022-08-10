using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Information
{
    public class GetQuizzesInfoByUserResponse
    {
        public IList<QuizInfoResponse> QuizzesInfoDto { get; set; } = new List<QuizInfoResponse>();
    }
}
