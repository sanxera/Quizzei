using System;
using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Search.Response
{
    public class SearchResponse
    {
        public IList<SearchQuiz> Quizzes { get; set; } = new List<SearchQuiz>();
        public IList<SearchUser> Users { get; set; } = new List<SearchUser>();
    }

    public class SearchQuiz
    {
        public Guid QuizUuid { get; set; }
        public string Title { get; set; }
    }

    public class SearchUser
    {
        public Guid UserUuid { get; set; }
        public string Name { get; set; }
    }
}
