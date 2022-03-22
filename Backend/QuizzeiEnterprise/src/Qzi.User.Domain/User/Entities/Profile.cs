using Qzi.User.Domain.Abstractions.Entities;

namespace Qzi.User.Domain.User.Entities
{
    public class Profile : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
    }
}
