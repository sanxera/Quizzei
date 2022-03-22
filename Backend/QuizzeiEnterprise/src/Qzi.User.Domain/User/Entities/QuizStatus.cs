using System;
using System.Collections.Generic;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class QuizStatus
    {
        public QuizStatus()
        {
            QuizProcesses = new HashSet<QuizProcess>();
        }

        public int QuizStatusId { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<QuizProcess> QuizProcesses { get; set; }
    }
}
