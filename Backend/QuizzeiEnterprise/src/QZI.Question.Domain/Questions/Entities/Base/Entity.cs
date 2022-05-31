using System;

namespace QZI.Question.Domain.Questions.Entities.Base
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
