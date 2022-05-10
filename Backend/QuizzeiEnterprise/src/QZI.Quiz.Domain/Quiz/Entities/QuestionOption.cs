using System;
using System.Collections.Generic;
using System.Linq;
using QZI.Quiz.Domain.Quiz.Entities.Base;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuestionOption : Entity
    {
        public Guid QuestionOptionUuid { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionUuid { get; set; }
        public Question Question { get; set; }

        public static List<QuestionOption> CreateAnyOptions(List<QuestionOptionsRequest> questionsRequest)
        {
            return questionsRequest.Select(CreateQuestionOption).ToList();
        }

        private static QuestionOption CreateQuestionOption(QuestionOptionsRequest request)
        {
            return new QuestionOption()
            {
                Description = request.Description,
                IsCorrect = request.IsCorrect,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin"
            };
        }
    }
}
