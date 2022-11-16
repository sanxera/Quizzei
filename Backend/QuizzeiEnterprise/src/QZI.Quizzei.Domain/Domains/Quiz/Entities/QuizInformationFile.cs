using System;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Entities
{
    public class QuizInformationFile : Entity
    {
        public Guid QuizInfoFileUuid { get; set; }
        public string Name { get; set; }
        public Guid QuizInfoUuid { get; set; }
        public QuizInformation QuizInformation { get; set; }

        public QuizInformationFile(string name, Guid quizInfoUuid)
        {
            Name = name;
            QuizInfoUuid = quizInfoUuid;
            CreatedAt = DateTime.Now;
            CreatedBy = "Admin";
        }
    }
}
