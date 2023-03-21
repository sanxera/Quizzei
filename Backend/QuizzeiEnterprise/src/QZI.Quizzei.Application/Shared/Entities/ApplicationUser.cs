using Microsoft.AspNetCore.Identity;

namespace QZI.Quizzei.Application.Shared.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string NickName { get; set; } = null!;
}