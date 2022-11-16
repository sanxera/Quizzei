using System;
using System.ComponentModel.DataAnnotations.Schema;
using QZI.Quizzei.Domain.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Entities.Enums;

namespace QZI.Quizzei.Domain.Domains.Quiz.Entities
{
    public class QuizProcess : Entity
    {
        public Guid QuizProcessUuid { get; set; }
        public Guid QuizInfoUuid { get; set; }
        public Guid UserUuid { get; set; }
        public QuizProcessStatus Status { get; set; }

        [NotMapped]
        public QuizInformation QuizInformation { get; set; }

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
