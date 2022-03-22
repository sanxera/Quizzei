using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class QuestionOption
    {
        public QuestionOption()
        {
            Answers = new HashSet<Answer>();
        }

        public Guid QuestionOptionsUuid { get; set; }
        public string Description { get; set; }
        public bool Iscorrect { get; set; }
        public Guid QuestionUuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Question QuestionUu { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
