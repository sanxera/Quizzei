namespace QZI.Quizzei.Application.Shared.Services.Users.Response;

public class GetUserResponse
{
    public Guid UserUuid { get; set; }
    public string Email { get; set; } = null!;
    public string NickName { get; set; } = null!;
    public Guid RoleUuid { get; set; }
    public string RoleName { get; set; } = null!;
    public bool Admin { get; set; }
}