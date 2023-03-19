using Microsoft.AspNetCore.Identity;

namespace QZI.Quizzei.Domain.Domains.User.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string NickName { get; set; }
}