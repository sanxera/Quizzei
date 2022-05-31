using System;

namespace QZI.Question.Domain.Questions.Handlers.Responses
{
    public class CreateQuestionsResponse
    {
        public Guid QuizInfoUuid { get; set; }
        public bool Created { get; set; }
    }
}
