using System;
using System.Collections.Generic;

namespace QZI.Quiz.Domain.Quiz.Handlers.Response
{
    public class GetQuizzesInfoByUserResponse
    {
        public IList<QuizInfoResponse> QuizzesInfoDto { get; set; } = new List<QuizInfoResponse>();
    }

    public class QuizInfoResponse
    {
        public Guid QuizInfoUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryDescription { get; set; }
    }
}
