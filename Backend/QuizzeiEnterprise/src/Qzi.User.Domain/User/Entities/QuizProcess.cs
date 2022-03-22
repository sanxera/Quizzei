using System;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class QuizProcess
    {
        public Guid QuizProcessUuid { get; set; }
        public Guid QuizUuid { get; set; }
        public Guid UserUuid { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Quiz QuizUu { get; set; }
        public virtual QuizStatus StatusNavigation { get; set; }
        public virtual User UserUu { get; set; }
    }
}
