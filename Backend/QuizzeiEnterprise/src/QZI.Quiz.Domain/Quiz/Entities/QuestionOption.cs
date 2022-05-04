using System;
using QZI.Quiz.Domain.Quiz.Entities.Base;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuestionOption : Entity
    {
        public Guid QuestionOptionUuid { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionUuid { get; set; }
        public Question Question { get; set; }
    }
}
