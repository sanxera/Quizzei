using System;

namespace QZI.Quizzei.Domain.Domains.Questions.Handlers.Requests
{
    public class AnswerQuestionRequest
    {
        public Guid QuizProcessUuid { get; set; }
        public Guid QuestionUuid { get; set; }
        public Guid OptionUuid { get; set; }
    }
}
