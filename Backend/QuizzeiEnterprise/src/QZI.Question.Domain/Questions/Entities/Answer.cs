using System;
using QZI.Question.Domain.Questions.Entities.Base;

namespace QZI.Question.Domain.Questions.Entities
{
    public class Answer : Entity
    {
        public Guid AnswerUuid { get; set; }
        public QuestionOption QuestionOption { get; set; }
        public Guid UserUuid { get; set; }
        public bool CorrectAnswer{ get; set; }

        public static Answer CreateAnswer(QuestionOption option, Guid userUuid)
        {
            return new Answer
            {
                QuestionOption = option,
                UserUuid = userUuid,
                CorrectAnswer = option.IsCorrect
            };
        }
    }
}
