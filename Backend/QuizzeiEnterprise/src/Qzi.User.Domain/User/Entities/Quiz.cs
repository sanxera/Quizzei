using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            QuizProcesses = new HashSet<QuizProcess>();
        }

        public Guid QuizUuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual QuizCategory Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuizProcess> QuizProcesses { get; set; }
    }
}
