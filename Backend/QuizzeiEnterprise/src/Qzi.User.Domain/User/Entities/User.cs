using System;

#nullable disable

namespace QZI.User.Domain.User.Entities
{
    public class User
    {
        public User() { }

        public Guid UserUuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int ProfileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
