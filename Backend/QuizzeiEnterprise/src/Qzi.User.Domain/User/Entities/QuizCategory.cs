using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class QuizCategory
    {
        public QuizCategory()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
