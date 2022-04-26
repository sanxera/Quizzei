using System;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizInfo
    {
        public Guid QuizInfoUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int CategoryId { get; set; }
        public QuizCategory Category { get; set; }

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
