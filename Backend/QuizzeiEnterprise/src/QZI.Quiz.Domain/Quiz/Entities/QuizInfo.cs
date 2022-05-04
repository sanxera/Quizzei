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
        public QuizCategory Category { get; set; }
        public ICollection<Question> Questions { get; set; }

        public static QuizInfo CreateQuizInfo(string title, string description, int points, QuizCategory category)
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
                Category = category
            };
        }
    }
}
