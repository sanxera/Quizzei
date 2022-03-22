using System;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public partial class Answer
    {
        public Guid AnswerUuid { get; set; }
        public Guid QuestionOptionUuid { get; set; }
        public Guid UserUuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual QuestionOption QuestionOptionUu { get; set; }
        public virtual User UserUu { get; set; }
    }
}
