using System;

namespace QZI.Quizzei.Domain.Domains.User.Service.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
