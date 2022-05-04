using System;
using System.Collections.Generic;
using QZI.Quiz.Domain.Quiz.Entities.Base;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizCategory : Entity
    {
        public int QuizCategoryId { get; set; }
        public ICollection<QuizInfo> QuizInfo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public static QuizCategory CreateQuizCategory(string name)
        {
            return new QuizCategory
            {
                Description = name,
                Active = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin"
            };
        }
    }
}
