using System;
using System.Collections.Generic;
using QZI.Quiz.Domain.Quiz.Entities.Base;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizInfo : Entity
    {
        public Guid QuizInfoUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public Guid UserOwnerId { get; set; }
        public QuizCategory Category { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public static QuizInfo CreateQuizInfo(string title, string description, int points, Guid userOwner, int categoryId)
        {
            return new QuizInfo
            {
                QuizInfoUuid = Guid.NewGuid(),
                Title = title,
                Description = description,
                Points = points,
                Active = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin",
                CategoryId = categoryId
            };
        }
    }
}
