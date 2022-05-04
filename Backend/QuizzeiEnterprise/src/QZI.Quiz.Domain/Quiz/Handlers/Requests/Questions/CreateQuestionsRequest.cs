using System;
using System.Collections.Generic;

namespace QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions
{
    public class CreateQuestionsRequest
    {
        public Guid QuizUuid { get; set; }

        public IList<QuestionRequest> Questions { get; set; }

        public class QuestionRequest
        {
            public string Description { get; set; }
            public IList<QuestionOptions> Options { get; set; }
        }

        public class QuestionOptions
        {
            public string Description { get; set; }
            public bool IsChosen { get; set; }
            public bool IsCorrect { get; set; }
        }
    }
}
