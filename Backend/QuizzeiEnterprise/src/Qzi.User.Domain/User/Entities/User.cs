using System;
using Qzi.User.Domain.Abstractions.Entities;

namespace Qzi.User.Domain.User.Entities
{
    public class User : Entity
    {
        public Guid UserUuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public int ProfileId { get; set; }
    }
}
