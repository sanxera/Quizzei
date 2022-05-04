using System;
using System.Collections.Generic;
using QZI.Quiz.Domain.Quiz.Entities.Base;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class Question : Entity
    {
        public Guid QuestionUuid { get; set; }
        public string Description { get; set; }
        public Guid QuizInfoUuid { get; set; }
        public QuizInfo QuizInfo { get; set; }
        public ICollection<QuestionOption> Options { get; set; }
    }
}
