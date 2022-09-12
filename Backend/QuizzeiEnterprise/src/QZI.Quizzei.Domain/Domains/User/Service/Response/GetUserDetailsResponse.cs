using System;

namespace QZI.Quizzei.Domain.Domains.User.Service.Response
{
    public class GetUserDetailsResponse
    {
        public Guid UserUuid { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public Guid RoleUuid { get; set; }
        public string RoleName { get; set; }
    }
}
