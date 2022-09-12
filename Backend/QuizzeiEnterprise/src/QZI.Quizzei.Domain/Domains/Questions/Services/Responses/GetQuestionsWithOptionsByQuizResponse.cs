using System;
using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Questions.Services.Responses
{
    public class GetQuestionsWithOptionsByQuizResponse
    {
        public IList<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>();
    }

    public class QuestionResponse
    {
        public Guid QuestionUuid { get; set; }
        public string QuestionDescription { get; set; }
        public IList<QuestionOptionResponse> Options { get; set; }
    }

    public class QuestionOptionResponse
    {
        public Guid OptionUuid { get; set; }
        public string OptionDescription { get; set; }
    }
}
