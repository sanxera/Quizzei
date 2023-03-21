namespace QZI.Quizzei.Application.UseCases.Users.CreateUser.Models.Request;

public class CreateUserRequest
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string NickName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid RoleId { get; set; }
}