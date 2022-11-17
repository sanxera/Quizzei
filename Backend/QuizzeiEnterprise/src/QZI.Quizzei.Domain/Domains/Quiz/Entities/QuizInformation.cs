using System;
using System.Collections.Generic;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Entities
{
    public class QuizInformation : Entity
    {
        public Guid QuizInfoUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public Guid UserOwnerId { get; set; }

        public ICollection<QuizInformationFile> Files { get; set; } = new List<QuizInformationFile>();

        public static QuizInformation CreateQuizInfo(string title, string description, Guid userOwner, int categoryId)
        {
            return new QuizInformation
            {
                QuizInfoUuid = Guid.NewGuid(),
                Title = title,
                Description = description,
                Active = true,
                UserOwnerId = userOwner,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin",
                CategoryId = categoryId
            };
        }

        public void UpdateQuizRate(int rate)
        {
            Points = rate;
        }
    }
}
