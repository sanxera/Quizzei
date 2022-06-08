using System.Collections.Generic;

namespace QZI.Quiz.Domain.Quiz.Handlers.Response
{
    public class GetQuizzesInfoByDifferentUsersResponse
    {
        public IList<QuizInfoResponse> QuizzesInfoDto { get; set; } = new List<QuizInfoResponse>();
    }
}
