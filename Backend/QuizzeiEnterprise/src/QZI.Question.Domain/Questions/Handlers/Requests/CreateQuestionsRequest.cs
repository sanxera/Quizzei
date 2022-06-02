using System.Collections.Generic;

namespace QZI.Question.Domain.Questions.Handlers.Requests
{
    public class  CreateQuestionsRequest
    {
        public IList<QuestionRequest> Questions { get; set; }
    }

    public class QuestionRequest
    {
        public string Description { get; set; }
        public IList<QuestionOptionsRequest> Options { get; set; }
    }

    public class QuestionOptionsRequest
    {
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
    }
}
