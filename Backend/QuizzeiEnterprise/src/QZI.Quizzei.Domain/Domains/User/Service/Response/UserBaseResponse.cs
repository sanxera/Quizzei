using System;

namespace QZI.Quizzei.Domain.Domains.User.Service.Response;

public class UserBaseResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string NickName { get; set; }
}