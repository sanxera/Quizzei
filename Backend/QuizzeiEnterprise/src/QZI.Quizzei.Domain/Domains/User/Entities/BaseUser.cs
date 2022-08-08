using System;

namespace QZI.Quizzei.Domain.Domains.User.Entities
{
    public class BaseUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
