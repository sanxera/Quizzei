using System;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizCategory
    {
        public int QuizCategoryId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
    }
}
