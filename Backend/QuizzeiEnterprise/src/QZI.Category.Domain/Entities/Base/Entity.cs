using System;

namespace QZI.Category.Domain.Entities.Base
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
