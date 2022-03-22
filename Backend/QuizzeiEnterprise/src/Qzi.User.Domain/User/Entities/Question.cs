using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Question
    {
        public Question()
        {
            QuestionOptions = new HashSet<QuestionOption>();
        }

        public Guid QuestionUuid { get; set; }
        public string Description { get; set; }
        public Guid QuizUuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Quiz QuizUu { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
