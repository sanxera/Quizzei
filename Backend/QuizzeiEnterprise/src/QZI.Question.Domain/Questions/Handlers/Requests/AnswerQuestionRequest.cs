using System;

namespace QZI.Question.Domain.Questions.Handlers.Requests
{
    public class AnswerQuestionRequest
    {
        public Guid QuestionUuid { get; set; }
        public Guid OptionUuid { get; set; }
    }
}
