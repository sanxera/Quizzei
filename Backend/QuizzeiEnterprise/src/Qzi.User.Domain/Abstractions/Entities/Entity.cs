using System;

namespace QZI.User.Domain.Abstractions.Entities
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
