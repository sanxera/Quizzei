using System;

namespace Qzi.User.Domain.Abstractions.Entities
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
