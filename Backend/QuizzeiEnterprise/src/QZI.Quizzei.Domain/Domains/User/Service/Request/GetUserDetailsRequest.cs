using System;

namespace QZI.Quizzei.Domain.Domains.User.Service.Request;

public class GetUserDetailsRequest
{
    public Guid UserUuid { get; set; }
}