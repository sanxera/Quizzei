﻿using System;

namespace QZI.Quizzei.Domain.Domains.User.Request
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
