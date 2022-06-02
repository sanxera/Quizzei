using System;
using QZI.Quiz.Domain.Quiz.Entities.Base;
using QZI.Quiz.Domain.Quiz.Entities.Enums;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizProcess : Entity
    {
        public Guid QuizProcessUuid { get; set; }
        public Guid QuizInfoUuid { get; set; }
        public Guid UserUuid { get; set; }
        public QuizProcessStatus Status { get; set; }

        public static QuizProcess CreateQuizProcess(Guid quizUuid, Guid userUuid)
        {
            return new QuizProcess
            {
                QuizInfoUuid = quizUuid,
                UserUuid = userUuid,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin",
                Status = QuizProcessStatus.Started
            };
        }
    }
}
