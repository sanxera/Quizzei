using System;
using System.Collections.Generic;

namespace QZI.Quiz.Domain.Quiz.Entities
{
    public class QuizCategory
    {
        public int QuizCategoryId { get; set; }
        public ICollection<QuizInfo> QuizInfo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
