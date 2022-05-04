using System;

namespace QZI.Quiz.Domain.Quiz.Entities.Base
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
